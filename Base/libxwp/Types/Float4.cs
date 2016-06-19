using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{x}, {y}, {z}, {w}")]
	public struct Float4 : IVectorType, IVectorType<float>
	{
		public float x, y, z, w;

		object[] IVectorType.GetComponents() => new object[] { x, y, z, w };
		float[] IVectorType<float>.GetComponents() => new[] { x, y, z, w };
		Type IVectorType.ComponentType => typeof(float);

		public Float4(float x = 0, float y = 0, float z = 0, float w = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		public Float4(Float2 xy, float z = 0, float w = 0) : this(xy.x, xy.y, z, w)
		{
		}
		public Float4(float x, Float2 yz, float w = 0) : this(x, yz.x, yz.y, w)
		{
		}
		public Float4(float x, float y, Float2 zw) : this(x, y, zw.x, zw.y)
		{
		}
		public Float4(Float3 xyz, float w = 0) : this(xyz.x, xyz.y, xyz.z, w)
		{
		}
		public Float4(Float2 xy, Float2 zw) : this(xy.x, xy.y, zw.x, zw.y)
		{
		}
		public Float4(float x, Float3 yzw) : this(x, yzw.x, yzw.y, yzw.z)
		{
		}
		public Float4(Float4 xyzw) : this(xyzw.x, xyzw.y, xyzw.z, xyzw.w)
		{
		}

		public static Float4 operator +(float a, Float4 b)
		{
			return new Float4(a + b.x, a + b.y, a + b.z, a + b.w);
		}
		public static Float4 operator -(float a, Float4 b)
		{
			return new Float4(a - b.x, a - b.y, a - b.z, a - b.w);
		}
		public static Float4 operator *(float a, Float4 b)
		{
			return new Float4(a * b.x, a * b.y, a * b.z, a * b.w);
		}
		public static Float4 operator /(float a, Float4 b)
		{
			return new Float4(a / b.x, a / b.y, a / b.z, a / b.w);
		}

		public static Float4 operator +(Float4 a, float b)
		{
			return new Float4(a.x + b, a.y + b, a.z + b, a.w + b);
		}
		public static Float4 operator -(Float4 a, float b)
		{
			return new Float4(a.x - b, a.y - b, a.z - b, a.w + b);
		}
		public static Float4 operator *(Float4 a, float b)
		{
			return new Float4(a.x * b, a.y * b, a.z * b, a.w + b);
		}
		public static Float4 operator /(Float4 a, float b)
		{
			return new Float4(a.x / b, a.y / b, a.z / b, a.w + b);
		}

		public static Float4 operator +(Float4 a, Float4 b)
		{
			return new Float4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}
		public static Float4 operator -(Float4 a, Float4 b)
		{
			return new Float4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}
		public static Float4 operator *(Float4 a, Float4 b)
		{
			return new Float4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}
		public static Float4 operator /(Float4 a, Float4 b)
		{
			return new Float4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		}

		public Float2 xy => new Float2(x, y);
		public Float2 xz => new Float2(x, z);
		public Float2 xw => new Float2(x, w);
		public Float2 yx => new Float2(y, x);
		public Float2 yz => new Float2(y, z);
		public Float2 yw => new Float2(y, w);
		public Float2 zx => new Float2(z, x);
		public Float2 zy => new Float2(z, y);
		public Float2 zw => new Float2(z, w);
		public Float2 wx => new Float2(w, x);
		public Float2 wy => new Float2(w, y);
		public Float2 wz => new Float2(w, z);

		public Float3 xyz => new Float3(x, y, z);
		public Float3 xyw => new Float3(x, y, w);
		public Float3 xzy => new Float3(x, z, y);
		public Float3 xzw => new Float3(x, z, w);
		public Float3 xwy => new Float3(x, w, y);
		public Float3 xwz => new Float3(x, w, z);
		public Float3 yxz => new Float3(y, x, z);
		public Float3 yxw => new Float3(y, x, w);
		public Float3 yzx => new Float3(y, z, x);
		public Float3 yzw => new Float3(y, z, w);
		public Float3 ywx => new Float3(y, w, x);
		public Float3 ywz => new Float3(y, w, z);
		public Float3 zxy => new Float3(z, x, y);
		public Float3 zxw => new Float3(z, x, w);
		public Float3 zyx => new Float3(z, y, x);
		public Float3 zyw => new Float3(z, y, w);
		public Float3 zwx => new Float3(z, w, x);
		public Float3 zwy => new Float3(z, w, y);
		public Float3 wxy => new Float3(w, x, y);
		public Float3 wxz => new Float3(w, x, z);
		public Float3 wyx => new Float3(w, y, x);
		public Float3 wyz => new Float3(w, y, z);
		public Float3 wzx => new Float3(w, z, x);
		public Float3 wzy => new Float3(w, z, y);

		public static Float4 Zero => new Float4(0);

		public static bool operator ==(Float4 a, Float4 b) =>
			Math.Abs(a.x - b.x) < float.Epsilon &&
			Math.Abs(a.y - b.y) < float.Epsilon &&
			Math.Abs(a.z - b.z) < float.Epsilon &&
			Math.Abs(a.w - b.w) < float.Epsilon;
		public static bool operator !=(Float4 a, Float4 b) =>
			Math.Abs(a.x - b.x) > float.Epsilon &&
			Math.Abs(a.y - b.y) > float.Epsilon &&
			Math.Abs(a.z - b.z) > float.Epsilon &&
			Math.Abs(a.w - b.w) > float.Epsilon;

		public Byte4 ToByte4()
		{
			return new Byte4(
				(byte)(int)(Math.Max(0, Math.Min(x, 1)) * 255),
				(byte)(int)(Math.Max(0, Math.Min(y, 1)) * 255),
				(byte)(int)(Math.Max(0, Math.Min(z, 1)) * 255),
				(byte)(int)(Math.Max(0, Math.Min(w, 1)) * 255));
		}

		public override string ToString() => $"{x}, {y}, {z}, {w}";
	}
}