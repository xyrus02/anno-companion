using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[DebuggerDisplay("{x}, {y}")]
	public struct Byte2
	{
		public byte x, y;

		public Byte2(byte x = 0, byte y = 0)
		{
			this.x = x;
			this.y = y;
		}
		public Byte2(Byte2 xy) : this(xy.x, xy.y)
		{
		}

		public static Byte2 operator +(byte a, Byte2 b)
		{
			return new Byte2((byte)(a + b.x), (byte)(a + b.y));
		}
		public static Byte2 operator -(byte a, Byte2 b)
		{
			return new Byte2((byte)(a - b.x), (byte)(a - b.y));
		}
		public static Byte2 operator *(byte a, Byte2 b)
		{
			return new Byte2((byte)(a * b.x), (byte)(a * b.y));
		}
		public static Byte2 operator /(byte a, Byte2 b)
		{
			return new Byte2((byte)(a / b.x), (byte)(a / b.y));
		}

		public static Byte2 operator +(Byte2 a, byte b)
		{
			return new Byte2((byte)(a.x + b), (byte)(a.y + b));
		}
		public static Byte2 operator -(Byte2 a, byte b)
		{
			return new Byte2((byte)(a.x - b), (byte)(a.y - b));
		}
		public static Byte2 operator *(Byte2 a, byte b)
		{
			return new Byte2((byte)(a.x * b), (byte)(a.y * b));
		}
		public static Byte2 operator /(Byte2 a, byte b)
		{
			return new Byte2((byte)(a.x / b), (byte)(a.y / b));
		}

		public static Byte2 operator +(Byte2 a, Byte2 b)
		{
			return new Byte2((byte)(a.x + b.x), (byte)(a.y + b.y));
		}
		public static Byte2 operator -(Byte2 a, Byte2 b)
		{
			return new Byte2((byte)(a.x - b.x), (byte)(a.y - b.y));
		}
		public static Byte2 operator *(Byte2 a, Byte2 b)
		{
			return new Byte2((byte)(a.x * b.x), (byte)(a.y * b.y));
		}
		public static Byte2 operator /(Byte2 a, Byte2 b)
		{
			return new Byte2((byte)(a.x / b.x), (byte)(a.y / b.y));
		}

		public static Byte2 Zero => new Byte2(0);

		public override string ToString() => $"{x}, {y}";
	}
}