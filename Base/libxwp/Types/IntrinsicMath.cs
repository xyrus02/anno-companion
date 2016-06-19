using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class IntrinsicMath
	{
		[StructLayout(LayoutKind.Explicit)]
		[SuppressMessage("ReSharper", "InconsistentNaming")]
		struct fiu
		{
			[FieldOffset(0)]
			public float f;

			[FieldOffset(0)]
			public int tmp;
		}

		private static float Exec(Func<double, double> f, float x) => (float)f(x);
		private static float Exec(Func<double, double, double> f, float x, float y) => (float)f(x, y);
		private static float Exec(Func<double, double, double, double> f, float x, float y, float z) => (float)f(x, y, z);

		private static Float2 Exec(Func<double, double> f, Float2 x) => new Float2((float)f(x.x), (float)f(x.y));
		private static Float2 Exec(Func<double, double, double> f, Float2 x, Float2 y) => new Float2((float)f(x.x, y.x), (float)f(x.y, y.y));
		private static Float2 Exec(Func<double, double, double, double> f, Float2 x, Float2 y, Float2 z) => new Float2((float)f(x.x, y.x, z.x), (float)f(x.y, y.y, z.y));

		private static Float3 Exec(Func<double, double> f, Float3 x) => new Float3((float)f(x.x), (float)f(x.y), (float)f(x.z));
		private static Float3 Exec(Func<double, double, double> f, Float3 x, Float3 y) => new Float3((float)f(x.x, y.x), (float)f(x.y, y.y), (float)f(x.z, y.z));
		private static Float3 Exec(Func<double, double, double, double> f, Float3 x, Float3 y, Float3 z) => new Float3((float)f(x.x, y.x, z.x), (float)f(x.y, y.y, z.y), (float)f(x.z, y.z, z.z));

		private static Float4 Exec(Func<double, double> f, Float4 x) => new Float4((float)f(x.x), (float)f(x.y), (float)f(x.z), (float)f(x.w));
		private static Float4 Exec(Func<double, double, double> f, Float4 x, Float4 y) => new Float4((float)f(x.x, y.x), (float)f(x.y, y.y), (float)f(x.z, y.z), (float)f(x.w, y.w));
		private static Float4 Exec(Func<double, double, double, double> f, Float4 x, Float4 y, Float4 z) => new Float4((float)f(x.x, y.x, z.x), (float)f(x.y, y.y, z.y), (float)f(x.z, y.z, z.z), (float)f(x.w, y.w, z.w));

		private static double ClampCore(double a, double b, double c) => a < b ? b : a > c ? c : a;
		private static double RoundCore(double a, double b) => Math.Round(a, (int)b);
		private static double Log2Core(double a) => Math.Log(a, 2);

		private static double SignCore(double a) => Math.Sign(a);

		public static float Acos(float x) => Exec(Math.Acos, x);
		public static float Asin(float x) => Exec(Math.Asin, x);
		public static float Atan(float x) => Exec(Math.Atan, x);

		public static Float2 Acos(Float2 x) => Exec(Math.Acos, x);
		public static Float2 Asin(Float2 x) => Exec(Math.Asin, x);
		public static Float2 Atan(Float2 x) => Exec(Math.Atan, x);

		public static Float3 Acos(Float3 x) => Exec(Math.Acos, x);
		public static Float3 Asin(Float3 x) => Exec(Math.Asin, x);
		public static Float3 Atan(Float3 x) => Exec(Math.Atan, x);

		public static Float4 Acos(Float4 x) => Exec(Math.Acos, x);
		public static Float4 Asin(Float4 x) => Exec(Math.Asin, x);
		public static Float4 Atan(Float4 x) => Exec(Math.Atan, x);

		public static float  Atan2(float y, float x) => Exec(Math.Atan2, y, x);
		public static Float2 Atan2(Float2 y, Float2 x) => Exec(Math.Atan2, y, x);
		public static Float3 Atan2(Float3 y, Float3 x) => Exec(Math.Atan2, y, x);
		public static Float4 Atan2(Float4 y, Float4 x) => Exec(Math.Atan2, y, x);

		public static float Abs  (float x) => Exec(Math.Abs, x);
		public static float Ceil (float x) => Exec(Math.Ceiling, x);
		public static float Floor(float x) => Exec(Math.Floor, x);
		public static float Clamp(float x, float min, float max) => Exec(ClampCore, x, min, max);
		public static float Round(float x, float y) => Exec(RoundCore, x, y);
		public static float Trunc(float x) => (int)x;

		public static Float2 Abs  (Float2 x) => Exec(Math.Abs, x);
		public static Float2 Ceil (Float2 x) => Exec(Math.Ceiling, x);
		public static Float2 Floor(Float2 x) => Exec(Math.Floor, x);
		public static Float2 Clamp(Float2 x, Float2 min, Float2 max) => Exec(ClampCore, x, min, max);
		public static Float2 Round(Float2 x, Float2 y) => Exec(RoundCore, x, y);
		public static Float2 Trunc(Float2 x) => new Float2((int)x.x, (int)x.y);

		public static Float3 Abs  (Float3 x) => Exec(Math.Abs, x);
		public static Float3 Ceil (Float3 x) => Exec(Math.Ceiling, x);
		public static Float3 Floor(Float3 x) => Exec(Math.Floor, x);
		public static Float3 Clamp(Float3 x, Float3 min, Float3 max) => Exec(ClampCore, x, min, max);
		public static Float3 Round(Float3 x, Float3 y) => Exec(RoundCore, x, y);
		public static Float3 Trunc(Float3 x) => new Float3((int)x.x, (int)x.y, (int)x.z);

		public static Float4 Abs  (Float4 x) => Exec(Math.Abs, x);
		public static Float4 Ceil (Float4 x) => Exec(Math.Ceiling, x);
		public static Float4 Floor(Float4 x) => Exec(Math.Floor, x);
		public static Float4 Clamp(Float4 x, Float4 min, Float4 max) => Exec(ClampCore, x, min, max);
		public static Float4 Round(Float4 x, Float4 y) => Exec(RoundCore, x, y);
		public static Float4 Trunc(Float4 x) => new Float4((int)x.x, (int)x.y, (int)x.z, (int)x.w);

		public static float Cos(float x) => Exec(Math.Cos, x);
		public static float Sin(float x) => Exec(Math.Sin, x);
		public static float Tan(float x) => Exec(Math.Tan, x);

		public static float Cosh(float x) => Exec(Math.Cosh, x);
		public static float Sinh(float x) => Exec(Math.Sinh, x);
		public static float Tanh(float x) => Exec(Math.Tanh, x);

		public static float Exp  (float x) => Exec(Math.Exp, x);
		public static float Log  (float x) => Exec(Math.Log, x);
		public static float Log2  (float x) =>Exec(Log2Core, x);
		public static float Log10(float x) => Exec(Math.Log10, x);

		public static Float2 Cos(Float2 x) => Exec(Math.Cos, x);
		public static Float2 Sin(Float2 x) => Exec(Math.Sin, x);
		public static Float2 Tan(Float2 x) => Exec(Math.Tan, x);

		public static Float2 Cosh(Float2 x) => Exec(Math.Cosh, x);
		public static Float2 Sinh(Float2 x) => Exec(Math.Sinh, x);
		public static Float2 Tanh(Float2 x) => Exec(Math.Tanh, x);

		public static Float2 Exp  (Float2 x) => Exec(Math.Exp, x);
		public static Float2 Log  (Float2 x) => Exec(Math.Log, x);
		public static Float2 Log2 (Float2 x) => Exec(Log2Core, x);
		public static Float2 Log10(Float2 x) => Exec(Math.Log10, x);

		public static Float3 Cos(Float3 x) => Exec(Math.Cos, x);
		public static Float3 Sin(Float3 x) => Exec(Math.Sin, x);
		public static Float3 Tan(Float3 x) => Exec(Math.Tan, x);

		public static Float3 Cosh(Float3 x) => Exec(Math.Cosh, x);
		public static Float3 Sinh(Float3 x) => Exec(Math.Sinh, x);
		public static Float3 Tanh(Float3 x) => Exec(Math.Tanh, x);

		public static Float3 Exp  (Float3 x) => Exec(Math.Exp, x);
		public static Float3 Log  (Float3 x) => Exec(Math.Log, x);
		public static Float3 Log2 (Float3 x) => Exec(Log2Core, x);
		public static Float3 Log10(Float3 x) => Exec(Math.Log10, x);

		public static Float4 Cos(Float4 x) => Exec(Math.Cos, x);
		public static Float4 Sin(Float4 x) => Exec(Math.Sin, x);
		public static Float4 Tan(Float4 x) => Exec(Math.Tan, x);

		public static Float4 Cosh(Float4 x) => Exec(Math.Cosh, x);
		public static Float4 Sinh(Float4 x) => Exec(Math.Sinh, x);
		public static Float4 Tanh(Float4 x) => Exec(Math.Tanh, x);

		public static Float4 Exp  (Float4 x) => Exec(Math.Exp, x);
		public static Float4 Log  (Float4 x) => Exec(Math.Log, x);
		public static Float4 Log2 (Float4 x) => Exec(Log2Core, x);
		public static Float4 Log10(Float4 x) => Exec(Math.Log10, x);

		public static float Min(float x, float y) => Exec(Math.Min, x, y);
		public static float Max(float x, float y) => Exec(Math.Max, x, y);

		public static float Pow (float x, float y) => Exec(Math.Pow, x, y);
		public static float Sign(float x) => Exec(SignCore, x);

		public static Float2 Min(Float2 x, Float2 y) => Exec(Math.Min, x, y);
		public static Float2 Max(Float2 x, Float2 y) => Exec(Math.Max, x, y);

		public static Float2 Pow (Float2 x, Float2 y) => Exec(Math.Pow, x, y);
		public static Float2 Sign(Float2 x) => Exec(SignCore, x);

		public static Float3 Min(Float3 x, Float3 y) => Exec(Math.Min, x, y);
		public static Float3 Max(Float3 x, Float3 y) => Exec(Math.Max, x, y);

		public static Float3 Pow (Float3 x, Float3 y) => Exec(Math.Pow, x, y);
		public static Float3 Sign(Float3 x) => Exec(SignCore, x);

		public static Float4 Min(Float4 x, Float4 y) => Exec(Math.Min, x, y);
		public static Float4 Max(Float4 x, Float4 y) => Exec(Math.Max, x, y);

		public static Float4 Pow (Float4 x, Float4 y) => Exec(Math.Pow, x, y);
		public static Float4 Sign(Float4 x) => Exec(SignCore, x);

		public static float Sqrt (float x) => Exec(Math.Sqrt, x);
		public static float Rsqrt(float x)
		{
			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if (x == 0) return 0;

			fiu union;
			union.tmp = 0;
			union.f = x;
			union.tmp -= 1 << 23; // x - 2 ^ m
			union.tmp >>= 1;      // x / 2
			union.tmp += 1 << 29; // x + ((b + 1) / 2) * 2 ^ m
			return union.f;
		}

		public static Float2 Sqrt (Float2 x) => Exec(Math.Sqrt, x);
		public static Float2 Rsqrt(Float2 x) => new Float2(Rsqrt(x.x), Rsqrt(x.y));

		public static Float3 Sqrt (Float3 x) => Exec(Math.Sqrt, x);
		public static Float3 Rsqrt(Float3 x) => new Float3(Rsqrt(x.x), Rsqrt(x.y), Rsqrt(x.z));

		public static Float4 Sqrt (Float4 x) => Exec(Math.Sqrt, x);
		public static Float4 Rsqrt(Float4 x) => new Float4(Rsqrt(x.x), Rsqrt(x.y), Rsqrt(x.z), Rsqrt(x.w));

		public static float Lerp(float x, float y, float s)
		{
			return x + s*(y - x);
		}

		public static float Dot(Float2 x, Float2 y) => x.x*y.x + x.y*y.y;
		public static float Dot(Float3 x, Float3 y) => x.x*y.x + x.y*y.y + x.z*y.z;
		public static float Dot(Float4 x, Float4 y) => x.x*y.x + x.y*y.y + x.z*y.z + x.w*y.w;

		public static Float2 Lerp(Float2 x, Float2 y, float s) => new Float2(
			Smoothstep(x.x, y.x, s),
			Smoothstep(x.y, y.y, s));

		public static Float3 Lerp(Float3 x, Float3 y, float s) => new Float3(
			Smoothstep(x.x, y.x, s),
			Smoothstep(x.y, y.y, s),
			Smoothstep(x.z, y.z, s));

		public static Float4 Lerp(Float4 x, Float4 y, float s) => new Float4(
			Smoothstep(x.x, y.x, s),
			Smoothstep(x.y, y.y, s),
			Smoothstep(x.z, y.z, s),
			Smoothstep(x.w, y.w, s));

		public static float Smoothstep(float edge0, float edge1, float x)
		{
			x = Clamp((x - edge0) / (edge1 - edge0), 0, 1);
			return x * x * (3 - 2 * x);
		}

		public static Float2 Smoothstep(Float2 edge0, Float2 edge1, float x) => new Float2(
			Smoothstep(edge0.x, edge1.x, x),
			Smoothstep(edge0.y, edge1.y, x));

		public static Float3 Smoothstep(Float3 edge0, Float3 edge1, float x) => new Float3(
			Smoothstep(edge0.x, edge1.x, x),
			Smoothstep(edge0.y, edge1.y, x),
			Smoothstep(edge0.z, edge1.z, x));

		public static Float4 Smoothstep(Float4 edge0, Float4 edge1, float x) => new Float4(
			Smoothstep(edge0.x, edge1.x, x),
			Smoothstep(edge0.y, edge1.y, x),
			Smoothstep(edge0.z, edge1.z, x),
			Smoothstep(edge0.w, edge1.w, x));
	}
}