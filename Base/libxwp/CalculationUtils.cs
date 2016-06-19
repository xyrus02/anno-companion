using System;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public static class CalculationUtils
	{
		public static Float2 AdjustSize(this Float2 f, float? maxWidth, float? maxHeight)
		{
			if (!maxWidth.HasValue && !maxHeight.HasValue)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (Math.Abs(f.y) < double.Epsilon || Math.Abs(f.x) < double.Epsilon)
			{
				throw new ArgumentOutOfRangeException();
			}

			float? widthScale = null;
			float? heightScale = null;

			if (maxWidth.HasValue)
			{
				widthScale = maxWidth.Value / f.x;
			}
			if (maxHeight.HasValue)
			{
				heightScale = maxHeight.Value / f.y;
			}

			var scale = IntrinsicMath.Min(
				(widthScale ?? heightScale).GetValueOrDefault(1), 
				(heightScale ?? widthScale).GetValueOrDefault(1));

			return new Float2(
				IntrinsicMath.Floor(f.x * scale), 
				IntrinsicMath.Ceil(f.y * scale));
		}

		
	}
}
