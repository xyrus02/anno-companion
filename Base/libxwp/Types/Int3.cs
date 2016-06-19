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
	public struct Int3 : IVectorType, IVectorType<int>
	{
		public int x, y, z;

		object[] IVectorType.GetComponents() => new object[] { x, y, z };
		int[] IVectorType<int>.GetComponents() => new[] { x, y, z };
		Type IVectorType.ComponentType => typeof(int);

		public Int3(int x = 0, int y = 0, int z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Int3(Int2 xy, int z = 0) : this(xy.x, xy.y, z)
		{
		}
		public Int3(int x, Int2 yz) : this(x, yz.x, yz.y)
		{
		}
		public Int3(Int3 xyz) : this(xyz.x, xyz.y, xyz.z)
		{
		}

		public static Int3 operator +(int a, Int3 b)
		{
			return new Int3(a + b.x, a + b.y, a + b.z);
		}
		public static Int3 operator -(int a, Int3 b)
		{
			return new Int3(a - b.x, a - b.y, a - b.z);
		}
		public static Int3 operator *(int a, Int3 b)
		{
			return new Int3(a * b.x, a * b.y, a * b.z);
		}
		public static Int3 operator /(int a, Int3 b)
		{
			return new Int3(a / b.x, a / b.y, a / b.z);
		}

		public static Int3 operator +(Int3 a, int b)
		{
			return new Int3(a.x + b, a.y + b, a.z + b);
		}
		public static Int3 operator -(Int3 a, int b)
		{
			return new Int3(a.x - b, a.y - b, a.z - b);
		}
		public static Int3 operator *(Int3 a, int b)
		{
			return new Int3(a.x * b, a.y * b, a.z * b);
		}
		public static Int3 operator /(Int3 a, int b)
		{
			return new Int3(a.x / b, a.y / b, a.z / b);
		}

		public static Int3 operator +(Int3 a, Int3 b)
		{
			return new Int3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static Int3 operator -(Int3 a, Int3 b)
		{
			return new Int3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static Int3 operator *(Int3 a, Int3 b)
		{
			return new Int3(a.x * b.x, a.y * b.y, a.z * b.z);
		}
		public static Int3 operator /(Int3 a, Int3 b)
		{
			return new Int3(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public Int2 xy => new Int2(x, y);
		public Int2 yx => new Int2(y, x);
		public Int2 yz => new Int2(y, z);
		public Int2 zy => new Int2(z, y);
		public Int2 xz => new Int2(x, z);
		public Int2 zx => new Int2(z, x);

		public static Int3 Zero => new Int3(0);

		public override string ToString() => $"{x}, {y}, {z}";
	}
}