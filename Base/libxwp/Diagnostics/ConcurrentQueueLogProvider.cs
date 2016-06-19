using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public class ConcurrentQueueLogProvider : IScopedLogProvider
	{
		private readonly object mFetchLock = new object();

		private readonly ConcurrentQueue<LogItem> mItemsQueue;
		private readonly Collection<IScopedLogProvider> mAttachedLogs;
		private readonly Scope mScope;

		public ConcurrentQueueLogProvider()
		{
			mAttachedLogs = new Collection<IScopedLogProvider>();
			mItemsQueue = new ConcurrentQueue<LogItem>();

			mScope = new Scope();
			mScope.Entering += OnScopeEntering;
			mScope.Leaving += OnScopeLeaving;

#if DEBUG
			AcceptsDebugMessages = true;
#else
			AcceptsDebugMessages = false;
#endif
		}

		public void WriteDebug(string message, params object[] parameters)
		{
			if (!AcceptsDebugMessages)
			{
				return;
			}

			Enqueue(CreateItem(message, parameters, LogItemType.Debug));
		}
		public void WriteError(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}

			exception.Unroll().Foreach(x => WriteError($"{x.Message}\r\n{x.StackTrace}"));
		}

		public void WriteLine(string message, params object[] parameters) => Enqueue(CreateItem(message, parameters, LogItemType.Notice));
		public void WriteWarning(string message, params object[] parameters) => Enqueue(CreateItem(message, parameters, LogItemType.Warning));
		public void WriteError(string message, params object[] parameters) => Enqueue(CreateItem(message, parameters, LogItemType.Error));

		public void Attach(IScopedLogProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException(nameof(provider));
			}

			mAttachedLogs.Add(provider);
		}
		public bool Detach(IScopedLogProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException(nameof(provider));
			}

			return mAttachedLogs.Remove(provider);
		}
		public void ClearAttachedLogs()
		{
			mAttachedLogs.Clear();
		}

		public Scope Scope
		{
			get { return mScope; }
		}
		public IList<LogItem> GetQueuedItems()
		{
			lock (mFetchLock)
			{
				var items = new List<LogItem>();
				LogItem currentItem;

				while (mItemsQueue.TryDequeue(out currentItem))
				{
					items.Add(currentItem);
				}

				return items;
			}
		}

		public bool AcceptsDebugMessages { get; set; }
		public bool IsEmpty => mItemsQueue.IsEmpty;

		private LogItem CreateItem(string message, object[] parameters, LogItemType type)
		{
			var item = new LogItem
			{
				Message = string.IsNullOrWhiteSpace(message) || (parameters?.Length ?? 0) == 0 ? message : string.Format(message, parameters ?? new object[0]),
				Scope = mScope.State?.ToString(),
				Timestamp = DateTime.Now,
				Type = type
			};

			return item;
		}
		private void Enqueue(LogItem item)
		{
			lock (mFetchLock)
			{
				mItemsQueue.Enqueue(item);
			}
		}

		private void OnScopeEntering(object sender, EventArgs e)
		{
			foreach (var item in mAttachedLogs)
			{
				item.Scope.Enter(Scope.State);
			}
		}
		private void OnScopeLeaving(object sender, EventArgs e)
		{
			foreach (var item in mAttachedLogs)
			{
				item.Scope.Dispose();
			}
		}
	}
}