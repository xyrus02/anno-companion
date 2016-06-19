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
	public struct Uint4 : IVectorType, IVectorType<uint>
	{
		public uint x, y, z, w;

		object[] IVectorType.GetComponents() => new object[] { x, y, z, w };
		uint[] IVectorType<uint>.GetComponents() => new[] { x, y, z, w };
		Type IVectorType.ComponentType => typeof(uint);

		public Uint4(uint x = 0, uint y = 0, uint z = 0, uint w = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		public Uint4(Uint2 xy, uint z = 0, uint w = 0) : this(xy.x, xy.y, z, w)
		{
		}
		public Uint4(uint x, Uint2 yz, uint w = 0) : this(x, yz.x, yz.y, w)
		{
		}
		public Uint4(uint x, uint y, Uint2 zw) : this(x, y, zw.x, zw.y)
		{
		}
		public Uint4(Uint3 xyz, uint w = 0) : this(xyz.x, xyz.y, xyz.z, w)
		{
		}
		public Uint4(Uint2 xy, Uint2 zw) : this(xy.x, xy.y, zw.x, zw.y)
		{
		}
		public Uint4(uint x, Uint3 yzw) : this(x, yzw.x, yzw.y, yzw.z)
		{
		}
		public Uint4(Uint4 xyzw) : this(xyzw.x, xyzw.y, xyzw.z, xyzw.w)
		{
		}

		public static Uint4 operator +(uint a, Uint4 b)
		{
			return new Uint4(a + b.x, a + b.y, a + b.z, a + b.w);
		}
		public static Uint4 operator -(uint a, Uint4 b)
		{
			return new Uint4(a - b.x, a - b.y, a - b.z, a - b.w);
		}
		public static Uint4 operator *(uint a, Uint4 b)
		{
			return new Uint4(a * b.x, a * b.y, a * b.z, a * b.w);
		}
		public static Uint4 operator /(uint a, Uint4 b)
		{
			return new Uint4(a / b.x, a / b.y, a / b.z, a / b.w);
		}

		public static Uint4 operator +(Uint4 a, uint b)
		{
			return new Uint4(a.x + b, a.y + b, a.z + b, a.w + b);
		}
		public static Uint4 operator -(Uint4 a, uint b)
		{
			return new Uint4(a.x - b, a.y - b, a.z - b, a.w + b);
		}
		public static Uint4 operator *(Uint4 a, uint b)
		{
			return new Uint4(a.x * b, a.y * b, a.z * b, a.w + b);
		}
		public static Uint4 operator /(Uint4 a, uint b)
		{
			return new Uint4(a.x / b, a.y / b, a.z / b, a.w + b);
		}

		public static Uint4 operator +(Uint4 a, Uint4 b)
		{
			return new Uint4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}
		public static Uint4 operator -(Uint4 a, Uint4 b)
		{
			return new Uint4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}
		public static Uint4 operator *(Uint4 a, Uint4 b)
		{
			return new Uint4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}
		public static Uint4 operator /(Uint4 a, Uint4 b)
		{
			return new Uint4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		}

		public Uint2 xy => new Uint2(x, y);
		public Uint2 xz => new Uint2(x, z);
		public Uint2 xw => new Uint2(x, w);
		public Uint2 yx => new Uint2(y, x);
		public Uint2 yz => new Uint2(y, z);
		public Uint2 yw => new Uint2(y, w);
		public Uint2 zx => new Uint2(z, x);
		public Uint2 zy => new Uint2(z, y);
		public Uint2 zw => new Uint2(z, w);
		public Uint2 wx => new Uint2(w, x);
		public Uint2 wy => new Uint2(w, y);
		public Uint2 wz => new Uint2(w, z);

		public Uint3 xyz => new Uint3(x, y, z);
		public Uint3 xyw => new Uint3(x, y, w);
		public Uint3 xzy => new Uint3(x, z, y);
		public Uint3 xzw => new Uint3(x, z, w);
		public Uint3 xwy => new Uint3(x, w, y);
		public Uint3 xwz => new Uint3(x, w, z);
		public Uint3 yxz => new Uint3(y, x, z);
		public Uint3 yxw => new Uint3(y, x, w);
		public Uint3 yzx => new Uint3(y, z, x);
		public Uint3 yzw => new Uint3(y, z, w);
		public Uint3 ywx => new Uint3(y, w, x);
		public Uint3 ywz => new Uint3(y, w, z);
		public Uint3 zxy => new Uint3(z, x, y);
		public Uint3 zxw => new Uint3(z, x, w);
		public Uint3 zyx => new Uint3(z, y, x);
		public Uint3 zyw => new Uint3(z, y, w);
		public Uint3 zwx => new Uint3(z, w, x);
		public Uint3 zwy => new Uint3(z, w, y);
		public Uint3 wxy => new Uint3(w, x, y);
		public Uint3 wxz => new Uint3(w, x, z);
		public Uint3 wyx => new Uint3(w, y, x);
		public Uint3 wyz => new Uint3(w, y, z);
		public Uint3 wzx => new Uint3(w, z, x);
		public Uint3 wzy => new Uint3(w, z, y);

		public static Uint4 Zero => new Uint4(0);

		public override string ToString() => $"{x}, {y}, {z}, {w}";
	}
}