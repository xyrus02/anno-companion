using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{x}, {y}")]
	public struct Float2 : IVectorType, IVectorType<float>
	{
		public float x, y;

		object[] IVectorType.GetComponents() => new object[] {x, y};
		float[] IVectorType<float>.GetComponents() => new [] {x, y};
		Type IVectorType.ComponentType => typeof(float);

		public Float2(float x) : this(x, 0)
		{
		}
		public Float2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		public Float2(Int2 xy) : this(xy.x, xy.y)
		{
		}

		public static Float2 operator +(float a, Float2 b)
		{
			return new Float2(a + b.x, a + b.y);
		}
		public static Float2 operator -(float a, Float2 b)
		{
			return new Float2(a - b.x, a - b.y);
		}
		public static Float2 operator *(float a, Float2 b)
		{
			return new Float2(a * b.x, a * b.y);
		}
		public static Float2 operator /(float a, Float2 b)
		{
			return new Float2(a / b.x, a / b.y);
		}

		public static Float2 operator +(Float2 a, float b)
		{
			return new Float2(a.x + b, a.y + b);
		}
		public static Float2 operator -(Float2 a, float b)
		{
			return new Float2(a.x - b, a.y - b);
		}
		public static Float2 operator *(Float2 a, float b)
		{
			return new Float2(a.x * b, a.y * b);
		}
		public static Float2 operator /(Float2 a, float b)
		{
			return new Float2(a.x / b, a.y / b);
		}

		public static Float2 operator +(Float2 a, Float2 b)
		{
			return new Float2(a.x + b.x, a.y + b.y);
		}
		public static Float2 operator -(Float2 a, Float2 b)
		{
			return new Float2(a.x - b.x, a.y - b.y);
		}
		public static Float2 operator *(Float2 a, Float2 b)
		{
			return new Float2(a.x * b.x, a.y * b.y);
		}
		public static Float2 operator /(Float2 a, Float2 b)
		{
			return new Float2(a.x / b.x, a.y / b.y);
		}

		public float RadiusSquared() => x * x + y * y;
		public float Radius() => (float)Math.Sqrt(x * x + y * y);

		public static Float2 Zero => new Float2(0);

		public static bool operator ==(Float2 a, Float2 b) => 
			Math.Abs(a.x - b.x) < float.Epsilon && 
			Math.Abs(a.y - b.y) < float.Epsilon;
		public static bool operator !=(Float2 a, Float2 b) =>
			Math.Abs(a.x - b.x) > float.Epsilon &&
			Math.Abs(a.y - b.y) > float.Epsilon;

		public Byte2 ToByte2()
		{
			return new Byte2(
				(byte)(int)(Math.Max(0, Math.Min(x, 1)) * 255),
				(byte)(int)(Math.Max(0, Math.Min(y, 1)) * 255));
		}

		public override string ToString() => $"{x}, {y}";
	}
}