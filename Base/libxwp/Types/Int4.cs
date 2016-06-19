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
	public struct Int4 : IVectorType, IVectorType<int>
	{
		public int x, y, z, w;

		object[] IVectorType.GetComponents() => new object[] { x, y, z, w };
		int[] IVectorType<int>.GetComponents() => new[] { x, y, z, w };
		Type IVectorType.ComponentType => typeof(int);

		public Int4(int x = 0, int y = 0, int z = 0, int w = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		public Int4(Int2 xy, int z = 0, int w = 0) : this(xy.x, xy.y, z, w)
		{
		}
		public Int4(int x, Int2 yz, int w = 0) : this(x, yz.x, yz.y, w)
		{
		}
		public Int4(int x, int y, Int2 zw) : this(x, y, zw.x, zw.y)
		{
		}
		public Int4(Int3 xyz, int w = 0) : this(xyz.x, xyz.y, xyz.z, w)
		{
		}
		public Int4(Int2 xy, Int2 zw) : this(xy.x, xy.y, zw.x, zw.y)
		{
		}
		public Int4(int x, Int3 yzw) : this(x, yzw.x, yzw.y, yzw.z)
		{
		}
		public Int4(Int4 xyzw) : this(xyzw.x, xyzw.y, xyzw.z, xyzw.w)
		{
		}

		public static Int4 operator +(int a, Int4 b)
		{
			return new Int4(a + b.x, a + b.y, a + b.z, a + b.w);
		}
		public static Int4 operator -(int a, Int4 b)
		{
			return new Int4(a - b.x, a - b.y, a - b.z, a - b.w);
		}
		public static Int4 operator *(int a, Int4 b)
		{
			return new Int4(a * b.x, a * b.y, a * b.z, a * b.w);
		}
		public static Int4 operator /(int a, Int4 b)
		{
			return new Int4(a / b.x, a / b.y, a / b.z, a / b.w);
		}

		public static Int4 operator +(Int4 a, int b)
		{
			return new Int4(a.x + b, a.y + b, a.z + b, a.w + b);
		}
		public static Int4 operator -(Int4 a, int b)
		{
			return new Int4(a.x - b, a.y - b, a.z - b, a.w + b);
		}
		public static Int4 operator *(Int4 a, int b)
		{
			return new Int4(a.x * b, a.y * b, a.z * b, a.w + b);
		}
		public static Int4 operator /(Int4 a, int b)
		{
			return new Int4(a.x / b, a.y / b, a.z / b, a.w + b);
		}

		public static Int4 operator +(Int4 a, Int4 b)
		{
			return new Int4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}
		public static Int4 operator -(Int4 a, Int4 b)
		{
			return new Int4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}
		public static Int4 operator *(Int4 a, Int4 b)
		{
			return new Int4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}
		public static Int4 operator /(Int4 a, Int4 b)
		{
			return new Int4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		}

		public Int2 xy => new Int2(x, y);
		public Int2 xz => new Int2(x, z);
		public Int2 xw => new Int2(x, w);
		public Int2 yx => new Int2(y, x);
		public Int2 yz => new Int2(y, z);
		public Int2 yw => new Int2(y, w);
		public Int2 zx => new Int2(z, x);
		public Int2 zy => new Int2(z, y);
		public Int2 zw => new Int2(z, w);
		public Int2 wx => new Int2(w, x);
		public Int2 wy => new Int2(w, y);
		public Int2 wz => new Int2(w, z);

		public Int3 xyz => new Int3(x, y, z);
		public Int3 xyw => new Int3(x, y, w);
		public Int3 xzy => new Int3(x, z, y);
		public Int3 xzw => new Int3(x, z, w);
		public Int3 xwy => new Int3(x, w, y);
		public Int3 xwz => new Int3(x, w, z);
		public Int3 yxz => new Int3(y, x, z);
		public Int3 yxw => new Int3(y, x, w);
		public Int3 yzx => new Int3(y, z, x);
		public Int3 yzw => new Int3(y, z, w);
		public Int3 ywx => new Int3(y, w, x);
		public Int3 ywz => new Int3(y, w, z);
		public Int3 zxy => new Int3(z, x, y);
		public Int3 zxw => new Int3(z, x, w);
		public Int3 zyx => new Int3(z, y, x);
		public Int3 zyw => new Int3(z, y, w);
		public Int3 zwx => new Int3(z, w, x);
		public Int3 zwy => new Int3(z, w, y);
		public Int3 wxy => new Int3(w, x, y);
		public Int3 wxz => new Int3(w, x, z);
		public Int3 wyx => new Int3(w, y, x);
		public Int3 wyz => new Int3(w, y, z);
		public Int3 wzx => new Int3(w, z, x);
		public Int3 wzy => new Int3(w, z, y);

		public static Int4 Zero => new Int4(0);

		public override string ToString() => $"{x}, {y}, {z}, {w}";
	}
}