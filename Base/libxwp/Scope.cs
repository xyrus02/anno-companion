using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class Scope : IDisposable
	{
		private readonly Stack<object> mStateStack = new Stack<object>();
		private readonly object mLock = new object();

		private readonly Action mOnEnter;
		private readonly Action mOnLeave;

		public Scope() { }
		public Scope(Action onEnter, Action onLeave)
		{
			mOnEnter = onEnter;
			mOnLeave = onLeave;
		}

		[NotNull] public Scope Enter(object state = null)
		{
			lock (mLock)
			{
				mStateStack.Push(state);
				Entering?.Invoke(this, new EventArgs());
				mOnEnter?.Invoke();
				OnEntered();
			}
			
			return this;
		}
		[NotNull] public Scope Leave()
		{
			Dispose();
			return this;
		}

		public void Dispose()
		{
			lock (mLock)
			{
				if (mStateStack.Count <= 0)
				{
					return;
				}

				OnLeave();
				Leaving?.Invoke(this, new EventArgs());
				mOnLeave?.Invoke();
				mStateStack.Pop();
			}
		}

		[CanBeNull]
		public object State
		{
			get
			{
				lock (mLock)
				{
					return IsInScope ? mStateStack.Peek() : null;
				}
			}
		}

		public bool IsInScope
		{
			get
			{
				lock (mLock)
				{
					return mStateStack.Count > 0;
				}
			}
		}

		[NotNull]
		public IEnumerable Stack
		{
			get
			{
				lock (mLock)
				{
					return mStateStack.ToArray();
				}
			}
		}

		public event EventHandler Entering;
		public event EventHandler Leaving;

		protected virtual void OnEntered()
		{
		}
		protected virtual void OnLeave()
		{
			
		}
	}

	[PublicAPI]
	public class Scope<T> : Scope
	{
		[NotNull]
		public Scope Enter(T state = default(T))
		{
			return base.Enter(state);
		}

		public new T State
		{
			get { return (T) base.State; }
		}
	}
}