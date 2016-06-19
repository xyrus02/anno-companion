using System;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class FloatConstraint : Constraint
	{
		private float mMinimum = float.NegativeInfinity;
		private float mMaximum = float.PositiveInfinity;
		private bool mIsDiscrete;

		public FloatConstraint() { }
		public FloatConstraint(float min, float max)
		{
			mMinimum = min;
			mMaximum = max;
		}

		public bool IsDiscrete
		{
			get { return mIsDiscrete; }
			set
			{
				if (Equals(value, mIsDiscrete))
				{
					return;
				}

				mIsDiscrete = value;

				if (value)
				{
					mMinimum = IntrinsicMath.Round(mMinimum, 0);
					mMaximum = IntrinsicMath.Round(mMaximum, 0);
				}

				OnPropertyChanged();
			}
		}

		public float Minimum
		{
			get { return mMinimum; }
			set
			{
				if (Equals(value, mMinimum))
				{
					return;
				}

				mMinimum = mIsDiscrete ? IntrinsicMath.Round(value, 0) : value;

				if (mMinimum - mMaximum > (mIsDiscrete ? 1 : float.Epsilon))
				{
					var swap = mMinimum;
					mMinimum = mMaximum;
					mMaximum = swap;
				}

				OnPropertyChanged();
			}
		}
		public float Maximum
		{
			get { return mMaximum; }
			set
			{
				if (Equals(value, mMaximum))
				{
					return;
				}

				mMaximum = mIsDiscrete ? IntrinsicMath.Round(value, 0) : value;

				if (mMinimum - mMaximum > (mIsDiscrete ? 1 : float.Epsilon))
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
			var source = (float)(value?.ToString().TryDeserializeNumericValue() ?? 0d);
			return mIsDiscrete 
				? IntrinsicMath.Round(Math.Max(mMinimum, Math.Min(source, mMaximum)), 0) 
				: Math.Max(mMinimum, Math.Min(source, mMaximum));
		}
	}
}