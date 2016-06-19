using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{x}, {y}, {z}")]
	public struct Float3 : IVectorType, IVectorType<float>
	{
		public float x, y, z;

		object[] IVectorType.GetComponents() => new object[] { x, y, z };
		float[] IVectorType<float>.GetComponents() => new[] { x, y, z };
		Type IVectorType.ComponentType => typeof(float);

		public Float3(float x = 0, float y = 0, float z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Float3(Float2 xy, float z = 0) : this(xy.x, xy.y, z)
		{
		}
		public Float3(float x, Float2 yz) : this(x, yz.x, yz.y)
		{
		}
		public Float3(Float3 xyz) : this(xyz.x, xyz.y, xyz.z)
		{
		}

		public static Float3 operator +(float a, Float3 b)
		{
			return new Float3(a + b.x, a + b.y, a + b.z);
		}
		public static Float3 operator -(float a, Float3 b)
		{
			return new Float3(a - b.x, a - b.y, a - b.z);
		}
		public static Float3 operator *(float a, Float3 b)
		{
			return new Float3(a * b.x, a * b.y, a * b.z);
		}
		public static Float3 operator /(float a, Float3 b)
		{
			return new Float3(a / b.x, a / b.y, a / b.z);
		}

		public static Float3 operator +(Float3 a, float b)
		{
			return new Float3(a.x + b, a.y + b, a.z + b);
		}
		public static Float3 operator -(Float3 a, float b)
		{
			return new Float3(a.x - b, a.y - b, a.z - b);
		}
		public static Float3 operator *(Float3 a, float b)
		{
			return new Float3(a.x * b, a.y * b, a.z * b);
		}
		public static Float3 operator /(Float3 a, float b)
		{
			return new Float3(a.x / b, a.y / b, a.z / b);
		}

		public static Float3 operator +(Float3 a, Float3 b)
		{
			return new Float3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static Float3 operator -(Float3 a, Float3 b)
		{
			return new Float3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static Float3 operator *(Float3 a, Float3 b)
		{
			return new Float3(a.x * b.x, a.y * b.y, a.z * b.z);
		}
		public static Float3 operator /(Float3 a, Float3 b)
		{
			return new Float3(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public Float2 xy => new Float2(x, y);
		public Float2 yx => new Float2(y, x);
		public Float2 yz => new Float2(y, z);
		public Float2 zy => new Float2(z, y);
		public Float2 xz => new Float2(x, z);
		public Float2 zx => new Float2(z, x);

		public static Float3 Zero => new Float3(0);

		public static bool operator ==(Float3 a, Float3 b) =>
			Math.Abs(a.x - b.x) < float.Epsilon &&
			Math.Abs(a.y - b.y) < float.Epsilon &&
			Math.Abs(a.z - b.z) < float.Epsilon;
		public static bool operator !=(Float3 a, Float3 b) =>
			Math.Abs(a.x - b.x) > float.Epsilon &&
			Math.Abs(a.y - b.y) > float.Epsilon &&
			Math.Abs(a.z - b.z) > float.Epsilon;

		public Byte3 ToByte3()
		{
			return new Byte3(
				(byte)(int)(Math.Max(0, Math.Min(x, 1)) * 255),
				(byte)(int)(Math.Max(0, Math.Min(y, 1)) * 255),
				(byte)(int)(Math.Max(0, Math.Min(z, 1)) * 255));
		}

		public override string ToString() => $"{x}, {y}, {z}";
	}
}