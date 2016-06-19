using System;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class IntConstraint : Constraint
	{
		private int mMinimum = int.MinValue;
		private int mMaximum = int.MaxValue;

		public IntConstraint() { }
		public IntConstraint(int min, int max)
		{
			mMinimum = min;
			mMaximum = max;
		}

		public int Minimum
		{
			get { return mMinimum; }
			set
			{
				if (Equals(value, mMinimum))
				{
					return;
				}

				mMinimum = value;

				if (mMaximum < mMinimum)
				{
					var swap = mMinimum;
					mMinimum = mMaximum;
					mMaximum = swap;
				}

				OnPropertyChanged();
			}
		}
		public int Maximum
		{
			get { return mMaximum; }
			set
			{
				if (Equals(value, mMaximum))
				{
					return;
				}

				mMaximum = value;

				if (mMaximum < mMinimum)
				{
					var swap = mMinimum;
					mMinimum = mMaximum;
					mMaximum = swap;
				}

				OnPropertyChanged();
			}
		}

		public override object Enforce(object value)
		{
			var source = value?.ToString().TryDeserialize<int>() ?? 0;
			return Math.Max(mMinimum, Math.Min(source, mMaximum));
		}
	}
}