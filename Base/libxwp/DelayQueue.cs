using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class DelayQueue<T> : IDisposable
	{
		private readonly ConcurrentQueue<T> mItemQueue;
		private readonly Timer mTimer;
		private readonly object mLock;

		private bool mIsDisposed;
		private bool mIsDelayEnabled;

		~DelayQueue()
		{
			Dispose(false);
		}
		public DelayQueue(TimeSpan interval)
		{
			mItemQueue = new ConcurrentQueue<T>();
			mTimer = new Timer(OnTimerTick, null, TimeSpan.Zero, interval);
			mLock = new object();
		}

		public Action<IList<T>> Callback { get; set; }

		public void Enqueue(T item)
		{
			if (IsDelayEnabled)
			{
				lock (mLock)
				{
					mItemQueue.Enqueue(item);
				}
			}
			else
			{
				Callback?.Invoke(new List<T> { item });
			}
		}
		public void Enqueue(IEnumerable<T> items)
		{
			if (IsDelayEnabled)
			{
				lock (mLock)
				{
					items?.Foreach(x => mItemQueue.Enqueue(x));
				}
			}
			else
			{
				Callback?.Invoke(items?.ToList() ?? new List<T>());
			}
		}

		public bool IsDelayEnabled
		{
			get { return mIsDelayEnabled; }
			set
			{
				if (!value)
				{
					Flush();
				}
				mIsDelayEnabled = value;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		public void Flush()
		{
			var itemsInQueue = new List<T>();
			lock (mLock)
			{
				while (!mItemQueue.IsEmpty)
				{
					T item;
					mItemQueue.TryDequeue(out item);
					itemsInQueue.Add(item);
				}
			}

			Callback?.Invoke(itemsInQueue);
		}

		private void OnTimerTick(object state)
		{
			Flush();
		}
		private void Dispose(bool disposing)
		{
			if (mIsDisposed)
			{
				return;
			}

			if (disposing)
			{
				Flush();
				mTimer.Dispose();
			}

			mIsDisposed = true;
		}
	}
}