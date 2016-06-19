using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public abstract class LogProvider : IScopedLogProvider, IDisposable
	{
		private readonly Collection<IScopedLogProvider> mAttachedLogs;
		private bool mIsDisposed;

		~LogProvider()
		{
			Dispose(false);
		}
		protected LogProvider()
		{
			mAttachedLogs = new Collection<IScopedLogProvider>();

			Scope = new Scope();
			Scope.Entering += OnScopeEntering;
			Scope.Leaving += OnScopeLeaving;

			ScopeBlacklist = new Collection<object>();
			IsNullScopeAllowed = true;

#if DEBUG
			AcceptsDebugMessages = true;
#else
			AcceptsDebugMessages = false;
#endif
		}

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

		public bool AcceptsDebugMessages { get; set; }

		public void WriteDebug(string message, params object[] parameters)
		{
			if (!AcceptsDebugMessages)
			{
				return;
			}

			Write(LogItemType.Debug, message, parameters);
		}
		public void WriteLine(string message, params object[] parameters)
		{
			Write(LogItemType.Notice, message, parameters);
		}
		public void WriteWarning(string message, params object[] parameters)
		{
			Write(LogItemType.Warning, message, parameters);
		}
		public void WriteError(string message, params object[] parameters)
		{
			Write(LogItemType.Error, message, parameters);
		}
		public void WriteError(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}

			exception.Unroll().Foreach(x => WriteError($"{x.Message}\r\n{x.StackTrace}"));
		}

		public Scope Scope { get; }
		public event LogWrittenEventHandler LogWritten;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected Collection<object> ScopeBlacklist { get; }
		protected bool IsNullScopeAllowed { get; set; }

		protected void Dispose(bool disposing)
		{
			if (mIsDisposed)
			{
				return;
			}

			if (disposing)
			{
				try
				{
					CleanupOverride();
				}
				catch
				{
					// ignored
				}
			}

			mIsDisposed = true;
		}

		protected virtual string FormatOverride([NotNull] string message, [CanBeNull] object scope, LogItemType type, DateTime timestamp)
		{
			return message;
		}
		protected virtual void WriteOverride([NotNull] string data)
		{
		}
		protected virtual void CleanupOverride() { }

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

		private void Write(LogItemType type, string message, params object[] parameters)
		{
			
			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			if (!IsNullScopeAllowed && Scope.State == null)
			{
				return;
			}

			if (ScopeBlacklist.Contains(Scope.State ?? new object()))
			{
				return;
			}

			var now = DateTime.Now;
			var data = FormatOverride(parameters.Length == 0 ? message : string.Format(message, parameters), Scope.State, type, now);

			WriteOverride(data);

			foreach (var attachedLog in mAttachedLogs)
			{
				switch (type)
				{
					case LogItemType.Notice:
						attachedLog.WriteLine(message, parameters);
						break;
					case LogItemType.Warning:
						attachedLog.WriteWarning(message, parameters);
						break;
					case LogItemType.Error:
						attachedLog.WriteError(message, parameters);
						break;
					case LogItemType.Debug:
						attachedLog.WriteDebug(message, parameters);
						break;
				}
			}

			LogWritten?.Invoke(this, new LogWrittenEventArgs(new LogItem
			{
				Message = string.Format(message, parameters),
				Scope = Scope.State?.ToString(),
				Type = type,
				Timestamp = now
			}));
		}
	}
}