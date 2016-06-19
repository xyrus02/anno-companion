using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{x}, {y}, {z}, {w}")]
	public struct Byte4
	{
		public byte x, y, z, w;

		public Byte4(byte x = 0, byte y = 0, byte z = 0, byte w = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		public Byte4(Byte2 xy, byte z = 0, byte w = 0) : this(xy.x, xy.y, z, w)
		{
		}
		public Byte4(byte x, Byte2 yz, byte w = 0) : this(x, yz.x, yz.y, w)
		{
		}
		public Byte4(byte x, byte y, Byte2 zw) : this(x, y, zw.x, zw.y)
		{
		}
		public Byte4(Byte3 xyz, byte w = 0) : this(xyz.x, xyz.y, xyz.z, w)
		{
		}
		public Byte4(Byte2 xy, Byte2 zw) : this(xy.x, xy.y, zw.x, zw.y)
		{
		}
		public Byte4(byte x, Byte3 yzw) : this(x, yzw.x, yzw.y, yzw.z)
		{
		}
		public Byte4(Byte4 xyzw) : this(xyzw.x, xyzw.y, xyzw.z, xyzw.w)
		{
		}

		public static Byte4 operator +(byte a, Byte4 b)
		{
			return new Byte4((byte)(a + b.x), (byte)(a + b.y), (byte)(a + b.z), (byte)(a + b.w));
		}
		public static Byte4 operator -(byte a, Byte4 b)
		{
			return new Byte4((byte)(a - b.x), (byte)(a - b.y), (byte)(a - b.z), (byte)(a - b.w));
		}
		public static Byte4 operator *(byte a, Byte4 b)
		{
			return new Byte4((byte)(a * b.x), (byte)(a * b.y), (byte)(a * b.z), (byte)(a * b.w));
		}
		public static Byte4 operator /(byte a, Byte4 b)
		{
			return new Byte4((byte)(a / b.x), (byte)(a / b.y), (byte)(a / b.z), (byte)(a / b.w));
		}

		public static Byte4 operator +(Byte4 a, byte b)
		{
			return new Byte4((byte)(a.x + b), (byte)(a.y + b), (byte)(a.z + b), (byte)(a.w + b));
		}
		public static Byte4 operator -(Byte4 a, byte b)
		{
			return new Byte4((byte)(a.x - b), (byte)(a.y - b), (byte)(a.z - b), (byte)(a.w + b));
		}
		public static Byte4 operator *(Byte4 a, byte b)
		{
			return new Byte4((byte)(a.x * b), (byte)(a.y * b), (byte)(a.z * b), (byte)(a.w + b));
		}
		public static Byte4 operator /(Byte4 a, byte b)
		{
			return new Byte4((byte)(a.x / b), (byte)(a.y / b), (byte)(a.z / b), (byte)(a.w + b));
		}

		public static Byte4 operator +(Byte4 a, Byte4 b)
		{
			return new Byte4((byte)(a.x + b.x), (byte)(a.y + b.y), (byte)(a.z + b.z), (byte)(a.w + b.w));
		}
		public static Byte4 operator -(Byte4 a, Byte4 b)
		{
			return new Byte4((byte)(a.x - b.x), (byte)(a.y - b.y), (byte)(a.z - b.z), (byte)(a.w - b.w));
		}
		public static Byte4 operator *(Byte4 a, Byte4 b)
		{
			return new Byte4((byte)(a.x * b.x), (byte)(a.y * b.y), (byte)(a.z * b.z), (byte)(a.w * b.w));
		}
		public static Byte4 operator /(Byte4 a, Byte4 b)
		{
			return new Byte4((byte)(a.x / b.x), (byte)(a.y / b.y), (byte)(a.z / b.z), (byte)(a.w / b.w));
		}

		public Byte2 xy => new Byte2(x, y);
		public Byte2 xz => new Byte2(x, z);
		public Byte2 xw => new Byte2(x, w);
		public Byte2 yx => new Byte2(y, x);
		public Byte2 yz => new Byte2(y, z);
		public Byte2 yw => new Byte2(y, w);
		public Byte2 zx => new Byte2(z, x);
		public Byte2 zy => new Byte2(z, y);
		public Byte2 zw => new Byte2(z, w);
		public Byte2 wx => new Byte2(w, x);
		public Byte2 wy => new Byte2(w, y);
		public Byte2 wz => new Byte2(w, z);

		public Byte3 xyz => new Byte3(x, y, z);
		public Byte3 xyw => new Byte3(x, y, w);
		public Byte3 xzy => new Byte3(x, z, y);
		public Byte3 xzw => new Byte3(x, z, w);
		public Byte3 xwy => new Byte3(x, w, y);
		public Byte3 xwz => new Byte3(x, w, z);
		public Byte3 yxz => new Byte3(y, x, z);
		public Byte3 yxw => new Byte3(y, x, w);
		public Byte3 yzx => new Byte3(y, z, x);
		public Byte3 yzw => new Byte3(y, z, w);
		public Byte3 ywx => new Byte3(y, w, x);
		public Byte3 ywz => new Byte3(y, w, z);
		public Byte3 zxy => new Byte3(z, x, y);
		public Byte3 zxw => new Byte3(z, x, w);
		public Byte3 zyx => new Byte3(z, y, x);
		public Byte3 zyw => new Byte3(z, y, w);
		public Byte3 zwx => new Byte3(z, w, x);
		public Byte3 zwy => new Byte3(z, w, y);
		public Byte3 wxy => new Byte3(w, x, y);
		public Byte3 wxz => new Byte3(w, x, z);
		public Byte3 wyx => new Byte3(w, y, x);
		public Byte3 wyz => new Byte3(w, y, z);
		public Byte3 wzx => new Byte3(w, z, x);
		public Byte3 wzy => new Byte3(w, z, y);

		public static Byte4 Zero => new Byte4(0);

		public override string ToString() => $"{x}, {y}, {z}, {w}";
	}
}