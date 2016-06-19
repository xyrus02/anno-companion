using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{_m00}, {_m10}, | {_m01}, {_m11}, || {_m20} {_m21}")]
	public struct Float3x2 : IMatrixType, IMatrixType<float>
	{
		public float _m00, _m01, _m10, _m11, _m20, _m21;

		object[] IVectorType.GetComponents() => new object[] {_m00, _m01, _m10, _m11, _m20, _m21 };
		float[] IVectorType<float>.GetComponents() => new[] { _m00, _m01, _m10, _m11, _m20, _m21 };
		Type IVectorType.ComponentType => typeof(float);

		public Float3x2(
			float m00, float m01, 
			float m10, float m11,
			float m20, float m21)
		{
			_m00 = m00;
			_m01 = m01;
			_m10 = m10;
			_m11 = m11;
			_m20 = m20;
			_m21 = m21;
		}

		public override string ToString() => $"{_m00}, {_m10}, | {_m01}, {_m11}, || {_m20} {_m21}";

		public static Float3x3 operator +(Float3x2 a, Float3x2 b)
		{
			return new Float3x3(
				a._m00 + b._m00, a._m01 + b._m01,
				a._m10 + b._m10, a._m11 + b._m11,
				a._m20 + b._m20, a._m21 + b._m21);
		}
		public static Float3x3 operator -(Float3x2 a, Float3x2 b)
		{
			return new Float3x3(
				a._m00 - b._m00, a._m01 - b._m01,
				a._m10 - b._m10, a._m11 - b._m11,
				a._m20 - b._m20, a._m21 - b._m21);
		}
		public static Float3x3 operator *(Float3x2 a, float b)
		{
			return new Float3x3(
				a._m00 + b, a._m01 + b,
				a._m10 + b, a._m11 + b,
				a._m20 + b, a._m21 + b);
		}
		public static Float2   operator *(Float3x2 a, Float2 b)
		{
			return new Float2(
				a._m00 * b.x + a._m10 * b.y + a._m20,
				a._m01 * b.x + a._m11 * b.y + a._m21);
		}

		public float[] this[byte i]
		{
			get
			{
				switch (i)
				{
					case 0: return new[] { _m00, _m01 };
					case 1: return new[] { _m10, _m11 };
					case 2: return new[] { _m20, _m21 };
				}

				throw new IndexOutOfRangeException();
			}
		}

		public static Float3x2 Zero => new Float3x2();
		public static Float3x2 Identity => new Float3x2(1, 0, 0, 1, 0, 0);

		#region 2-element permutations
		public Float2 _m00_m01 => new Float2(_m00, _m01);
		public Float2 _m00_m10 => new Float2(_m00, _m10);
		public Float2 _m00_m11 => new Float2(_m00, _m11);
		public Float2 _m00_m20 => new Float2(_m00, _m20);
		public Float2 _m00_m21 => new Float2(_m00, _m21);
		public Float2 _m01_m00 => new Float2(_m01, _m00);
		public Float2 _m01_m10 => new Float2(_m01, _m10);
		public Float2 _m01_m11 => new Float2(_m01, _m11);
		public Float2 _m01_m20 => new Float2(_m01, _m20);
		public Float2 _m01_m21 => new Float2(_m01, _m21);
		public Float2 _m10_m00 => new Float2(_m10, _m00);
		public Float2 _m10_m01 => new Float2(_m10, _m01);
		public Float2 _m10_m11 => new Float2(_m10, _m11);
		public Float2 _m10_m20 => new Float2(_m10, _m20);
		public Float2 _m10_m21 => new Float2(_m10, _m21);
		public Float2 _m11_m00 => new Float2(_m11, _m00);
		public Float2 _m11_m01 => new Float2(_m11, _m01);
		public Float2 _m11_m10 => new Float2(_m11, _m10);
		public Float2 _m11_m20 => new Float2(_m11, _m20);
		public Float2 _m11_m21 => new Float2(_m11, _m21);
		public Float2 _m20_m00 => new Float2(_m20, _m00);
		public Float2 _m20_m01 => new Float2(_m20, _m01);
		public Float2 _m20_m10 => new Float2(_m20, _m10);
		public Float2 _m20_m11 => new Float2(_m20, _m11);
		public Float2 _m20_m21 => new Float2(_m20, _m21);
		public Float2 _m21_m00 => new Float2(_m21, _m00);
		public Float2 _m21_m01 => new Float2(_m21, _m01);
		public Float2 _m21_m10 => new Float2(_m21, _m10);
		public Float2 _m21_m11 => new Float2(_m21, _m11);
		public Float2 _m21_m20 => new Float2(_m21, _m20);
		#endregion
		#region 3-element permutations
		public Float3 _m00_m01_m10 => new Float3(_m00, _m01, _m10);
		public Float3 _m00_m01_m11 => new Float3(_m00, _m01, _m11);
		public Float3 _m00_m01_m20 => new Float3(_m00, _m01, _m20);
		public Float3 _m00_m01_m21 => new Float3(_m00, _m01, _m21);
		public Float3 _m00_m10_m01 => new Float3(_m00, _m10, _m01);
		public Float3 _m00_m10_m11 => new Float3(_m00, _m10, _m11);
		public Float3 _m00_m10_m20 => new Float3(_m00, _m10, _m20);
		public Float3 _m00_m10_m21 => new Float3(_m00, _m10, _m21);
		public Float3 _m00_m11_m01 => new Float3(_m00, _m11, _m01);
		public Float3 _m00_m11_m10 => new Float3(_m00, _m11, _m10);
		public Float3 _m00_m11_m20 => new Float3(_m00, _m11, _m20);
		public Float3 _m00_m11_m21 => new Float3(_m00, _m11, _m21);
		public Float3 _m00_m20_m01 => new Float3(_m00, _m20, _m01);
		public Float3 _m00_m20_m10 => new Float3(_m00, _m20, _m10);
		public Float3 _m00_m20_m11 => new Float3(_m00, _m20, _m11);
		public Float3 _m00_m20_m21 => new Float3(_m00, _m20, _m21);
		public Float3 _m00_m21_m01 => new Float3(_m00, _m21, _m01);
		public Float3 _m00_m21_m10 => new Float3(_m00, _m21, _m10);
		public Float3 _m00_m21_m11 => new Float3(_m00, _m21, _m11);
		public Float3 _m00_m21_m20 => new Float3(_m00, _m21, _m20);
		public Float3 _m01_m00_m10 => new Float3(_m01, _m00, _m10);
		public Float3 _m01_m00_m11 => new Float3(_m01, _m00, _m11);
		public Float3 _m01_m00_m20 => new Float3(_m01, _m00, _m20);
		public Float3 _m01_m00_m21 => new Float3(_m01, _m00, _m21);
		public Float3 _m01_m10_m00 => new Float3(_m01, _m10, _m00);
		public Float3 _m01_m10_m11 => new Float3(_m01, _m10, _m11);
		public Float3 _m01_m10_m20 => new Float3(_m01, _m10, _m20);
		public Float3 _m01_m10_m21 => new Float3(_m01, _m10, _m21);
		public Float3 _m01_m11_m00 => new Float3(_m01, _m11, _m00);
		public Float3 _m01_m11_m10 => new Float3(_m01, _m11, _m10);
		public Float3 _m01_m11_m20 => new Float3(_m01, _m11, _m20);
		public Float3 _m01_m11_m21 => new Float3(_m01, _m11, _m21);
		public Float3 _m01_m20_m00 => new Float3(_m01, _m20, _m00);
		public Float3 _m01_m20_m10 => new Float3(_m01, _m20, _m10);
		public Float3 _m01_m20_m11 => new Float3(_m01, _m20, _m11);
		public Float3 _m01_m20_m21 => new Float3(_m01, _m20, _m21);
		public Float3 _m01_m21_m00 => new Float3(_m01, _m21, _m00);
		public Float3 _m01_m21_m10 => new Float3(_m01, _m21, _m10);
		public Float3 _m01_m21_m11 => new Float3(_m01, _m21, _m11);
		public Float3 _m01_m21_m20 => new Float3(_m01, _m21, _m20);
		public Float3 _m10_m00_m01 => new Float3(_m10, _m00, _m01);
		public Float3 _m10_m00_m11 => new Float3(_m10, _m00, _m11);
		public Float3 _m10_m00_m20 => new Float3(_m10, _m00, _m20);
		public Float3 _m10_m00_m21 => new Float3(_m10, _m00, _m21);
		public Float3 _m10_m01_m00 => new Float3(_m10, _m01, _m00);
		public Float3 _m10_m01_m11 => new Float3(_m10, _m01, _m11);
		public Float3 _m10_m01_m20 => new Float3(_m10, _m01, _m20);
		public Float3 _m10_m01_m21 => new Float3(_m10, _m01, _m21);
		public Float3 _m10_m11_m00 => new Float3(_m10, _m11, _m00);
		public Float3 _m10_m11_m01 => new Float3(_m10, _m11, _m01);
		public Float3 _m10_m11_m20 => new Float3(_m10, _m11, _m20);
		public Float3 _m10_m11_m21 => new Float3(_m10, _m11, _m21);
		public Float3 _m10_m20_m00 => new Float3(_m10, _m20, _m00);
		public Float3 _m10_m20_m01 => new Float3(_m10, _m20, _m01);
		public Float3 _m10_m20_m11 => new Float3(_m10, _m20, _m11);
		public Float3 _m10_m20_m21 => new Float3(_m10, _m20, _m21);
		public Float3 _m10_m21_m00 => new Float3(_m10, _m21, _m00);
		public Float3 _m10_m21_m01 => new Float3(_m10, _m21, _m01);
		public Float3 _m10_m21_m11 => new Float3(_m10, _m21, _m11);
		public Float3 _m10_m21_m20 => new Float3(_m10, _m21, _m20);
		public Float3 _m11_m00_m01 => new Float3(_m11, _m00, _m01);
		public Float3 _m11_m00_m10 => new Float3(_m11, _m00, _m10);
		public Float3 _m11_m00_m20 => new Float3(_m11, _m00, _m20);
		public Float3 _m11_m00_m21 => new Float3(_m11, _m00, _m21);
		public Float3 _m11_m01_m00 => new Float3(_m11, _m01, _m00);
		public Float3 _m11_m01_m10 => new Float3(_m11, _m01, _m10);
		public Float3 _m11_m01_m20 => new Float3(_m11, _m01, _m20);
		public Float3 _m11_m01_m21 => new Float3(_m11, _m01, _m21);
		public Float3 _m11_m10_m00 => new Float3(_m11, _m10, _m00);
		public Float3 _m11_m10_m01 => new Float3(_m11, _m10, _m01);
		public Float3 _m11_m10_m20 => new Float3(_m11, _m10, _m20);
		public Float3 _m11_m10_m21 => new Float3(_m11, _m10, _m21);
		public Float3 _m11_m20_m00 => new Float3(_m11, _m20, _m00);
		public Float3 _m11_m20_m01 => new Float3(_m11, _m20, _m01);
		public Float3 _m11_m20_m10 => new Float3(_m11, _m20, _m10);
		public Float3 _m11_m20_m21 => new Float3(_m11, _m20, _m21);
		public Float3 _m11_m21_m00 => new Float3(_m11, _m21, _m00);
		public Float3 _m11_m21_m01 => new Float3(_m11, _m21, _m01);
		public Float3 _m11_m21_m10 => new Float3(_m11, _m21, _m10);
		public Float3 _m11_m21_m20 => new Float3(_m11, _m21, _m20);
		public Float3 _m20_m00_m01 => new Float3(_m20, _m00, _m01);
		public Float3 _m20_m00_m10 => new Float3(_m20, _m00, _m10);
		public Float3 _m20_m00_m11 => new Float3(_m20, _m00, _m11);
		public Float3 _m20_m00_m21 => new Float3(_m20, _m00, _m21);
		public Float3 _m20_m01_m00 => new Float3(_m20, _m01, _m00);
		public Float3 _m20_m01_m10 => new Float3(_m20, _m01, _m10);
		public Float3 _m20_m01_m11 => new Float3(_m20, _m01, _m11);
		public Float3 _m20_m01_m21 => new Float3(_m20, _m01, _m21);
		public Float3 _m20_m10_m00 => new Float3(_m20, _m10, _m00);
		public Float3 _m20_m10_m01 => new Float3(_m20, _m10, _m01);
		public Float3 _m20_m10_m11 => new Float3(_m20, _m10, _m11);
		public Float3 _m20_m10_m21 => new Float3(_m20, _m10, _m21);
		public Float3 _m20_m11_m00 => new Float3(_m20, _m11, _m00);
		public Float3 _m20_m11_m01 => new Float3(_m20, _m11, _m01);
		public Float3 _m20_m11_m10 => new Float3(_m20, _m11, _m10);
		public Float3 _m20_m11_m21 => new Float3(_m20, _m11, _m21);
		public Float3 _m20_m21_m00 => new Float3(_m20, _m21, _m00);
		public Float3 _m20_m21_m01 => new Float3(_m20, _m21, _m01);
		public Float3 _m20_m21_m10 => new Float3(_m20, _m21, _m10);
		public Float3 _m20_m21_m11 => new Float3(_m20, _m21, _m11);
		public Float3 _m21_m00_m01 => new Float3(_m21, _m00, _m01);
		public Float3 _m21_m00_m10 => new Float3(_m21, _m00, _m10);
		public Float3 _m21_m00_m11 => new Float3(_m21, _m00, _m11);
		public Float3 _m21_m00_m20 => new Float3(_m21, _m00, _m20);
		public Float3 _m21_m01_m00 => new Float3(_m21, _m01, _m00);
		public Float3 _m21_m01_m10 => new Float3(_m21, _m01, _m10);
		public Float3 _m21_m01_m11 => new Float3(_m21, _m01, _m11);
		public Float3 _m21_m01_m20 => new Float3(_m21, _m01, _m20);
		public Float3 _m21_m10_m00 => new Float3(_m21, _m10, _m00);
		public Float3 _m21_m10_m01 => new Float3(_m21, _m10, _m01);
		public Float3 _m21_m10_m11 => new Float3(_m21, _m10, _m11);
		public Float3 _m21_m10_m20 => new Float3(_m21, _m10, _m20);
		public Float3 _m21_m11_m00 => new Float3(_m21, _m11, _m00);
		public Float3 _m21_m11_m01 => new Float3(_m21, _m11, _m01);
		public Float3 _m21_m11_m10 => new Float3(_m21, _m11, _m10);
		public Float3 _m21_m11_m20 => new Float3(_m21, _m11, _m20);
		public Float3 _m21_m20_m00 => new Float3(_m21, _m20, _m00);
		public Float3 _m21_m20_m01 => new Float3(_m21, _m20, _m01);
		public Float3 _m21_m20_m10 => new Float3(_m21, _m20, _m10);
		public Float3 _m21_m20_m11 => new Float3(_m21, _m20, _m11);
		#endregion
	}
}