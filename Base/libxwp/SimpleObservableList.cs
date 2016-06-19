using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class SimpleObservableList<T> : IList<T>
	{
		private readonly List<T> mData;
		private readonly Scope mSuspendNotificationScope;

		public SimpleObservableList()
		{
			mSuspendNotificationScope = new Scope(onLeave: () => ChangeAction?.Invoke(), onEnter:null);
			mData = new List<T>();
		}
		public SimpleObservableList(IEnumerable<T> source)
		{
			mSuspendNotificationScope = new Scope(onLeave: () => ChangeAction?.Invoke(), onEnter: null);
			mData = new List<T>(source);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => mData.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => mData.GetEnumerator();

		public void Add(T item)
		{
			if (AllowReentrancy || !mSuspendNotificationScope.IsInScope)
			{
				AddAction?.Invoke(item);
				mData.Add(item);
				ChangeAction?.Invoke();
			}
		}
		public void Insert(int index, T item)
		{
			if (AllowReentrancy || !mSuspendNotificationScope.IsInScope)
			{
				AddAction?.Invoke(item);
				mData.Insert(index, item);
				ChangeAction?.Invoke();
			}
		}
		public void Clear()
		{
			if (AllowReentrancy || !mSuspendNotificationScope.IsInScope)
			{
				if (RemoveAction != null)
				{
					mData.Foreach(RemoveAction);
				}

				mData.Clear();

				ChangeAction?.Invoke();
			}
		}
		public bool Remove(T item)
		{
			if (AllowReentrancy || !mSuspendNotificationScope.IsInScope)
			{
				RemoveAction?.Invoke(item);
			}

			var result = mData.Remove(item);
			if (result && (AllowReentrancy || !mSuspendNotificationScope.IsInScope))
			{
				ChangeAction?.Invoke();
			}
			return result;
		}
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}

			var item = mData.ElementAt(index);
			if (AllowReentrancy || !mSuspendNotificationScope.IsInScope)
			{
				RemoveAction?.Invoke(item);
				mData.RemoveAt(index);
				ChangeAction?.Invoke();
			}
		}
		public bool Contains(T item) => mData.Contains(item);
		public void CopyTo(T[] array, int arrayIndex) => mData.CopyTo(array, arrayIndex);
		public int IndexOf(T item) => mData.IndexOf(item);

		public T this[int index]
		{
			get { return mData[index]; }
			set
			{
				var old = mData[index];
				if (AllowReentrancy || !mSuspendNotificationScope.IsInScope)
				{
					RemoveAction?.Invoke(old);
					AddAction?.Invoke(value);
					mData[index] = value;
					ChangeAction?.Invoke();
				}
			}
		}
		public int Count => mData.Count;
		public bool IsReadOnly => false;

		public bool AllowReentrancy { get; set; }

		public Scope SuspendNotificationScope => mSuspendNotificationScope;
		public Action ChangeAction { get; set; }

		public Action<T> AddAction { get; set; }
		public Action<T> RemoveAction { get; set; }
	}
}