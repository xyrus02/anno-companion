using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{x}, {y}, {z}")]
	public struct Byte3
	{
		public byte x, y, z;

		public Byte3(byte x = 0, byte y = 0, byte z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Byte3(Byte2 xy, byte z = 0) : this(xy.x, xy.y, z)
		{
		}
		public Byte3(byte x, Byte2 yz) : this(x, yz.x, yz.y)
		{
		}
		public Byte3(Byte3 xyz) : this(xyz.x, xyz.y, xyz.z)
		{
		}

		public static Byte3 operator +(byte a, Byte3 b)
		{
			return new Byte3((byte)(a + b.x), (byte)(a + b.y), (byte)(a + b.z));
		}
		public static Byte3 operator -(byte a, Byte3 b)
		{
			return new Byte3((byte)(a - b.x), (byte)(a - b.y), (byte)(a - b.z));
		}
		public static Byte3 operator *(byte a, Byte3 b)
		{
			return new Byte3((byte)(a * b.x), (byte)(a * b.y), (byte)(a * b.z));
		}
		public static Byte3 operator /(byte a, Byte3 b)
		{
			return new Byte3((byte)(a / b.x), (byte)(a / b.y), (byte)(a / b.z));
		}

		public static Byte3 operator +(Byte3 a, byte b)
		{
			return new Byte3((byte)(a.x + b), (byte)(a.y + b), (byte)(a.z + b));
		}
		public static Byte3 operator -(Byte3 a, byte b)
		{
			return new Byte3((byte)(a.x - b), (byte)(a.y - b), (byte)(a.z - b));
		}
		public static Byte3 operator *(Byte3 a, byte b)
		{
			return new Byte3((byte)(a.x * b), (byte)(a.y * b), (byte)(a.z * b));
		}
		public static Byte3 operator /(Byte3 a, byte b)
		{
			return new Byte3((byte)(a.x / b), (byte)(a.y / b), (byte)(a.z / b));
		}

		public static Byte3 operator +(Byte3 a, Byte3 b)
		{
			return new Byte3((byte)(a.x + b.x), (byte)(a.y + b.y), (byte)(a.z + b.z));
		}
		public static Byte3 operator -(Byte3 a, Byte3 b)
		{
			return new Byte3((byte)(a.x - b.x), (byte)(a.y - b.y), (byte)(a.z - b.z));
		}
		public static Byte3 operator *(Byte3 a, Byte3 b)
		{
			return new Byte3((byte)(a.x * b.x), (byte)(a.y * b.y), (byte)(a.z * b.z));
		}
		public static Byte3 operator /(Byte3 a, Byte3 b)
		{
			return new Byte3((byte)(a.x / b.x), (byte)(a.y / b.y), (byte)(a.z / b.z));
		}

		public Byte2 xy => new Byte2(x, y);
		public Byte2 yx => new Byte2(y, x);
		public Byte2 yz => new Byte2(y, z);
		public Byte2 zy => new Byte2(z, y);
		public Byte2 xz => new Byte2(x, z);
		public Byte2 zx => new Byte2(z, x);

		public static Byte3 Zero => new Byte3(0);

		public override string ToString() => $"{x}, {y}, {z}";
	}
}