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
	public struct Uint3 : IVectorType, IVectorType<uint>
	{
		public uint x, y, z;

		object[] IVectorType.GetComponents() => new object[] { x, y, z };
		uint[] IVectorType<uint>.GetComponents() => new[] { x, y, z };
		Type IVectorType.ComponentType => typeof(uint);

		public Uint3(uint x = 0, uint y = 0, uint z = 0)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Uint3(Uint2 xy, uint z = 0) : this(xy.x, xy.y, z)
		{
		}
		public Uint3(uint x, Uint2 yz) : this(x, yz.x, yz.y)
		{
		}
		public Uint3(Uint3 xyz) : this(xyz.x, xyz.y, xyz.z)
		{
		}

		public static Uint3 operator +(uint a, Uint3 b)
		{
			return new Uint3(a + b.x, a + b.y, a + b.z);
		}
		public static Uint3 operator -(uint a, Uint3 b)
		{
			return new Uint3(a - b.x, a - b.y, a - b.z);
		}
		public static Uint3 operator *(uint a, Uint3 b)
		{
			return new Uint3(a * b.x, a * b.y, a * b.z);
		}
		public static Uint3 operator /(uint a, Uint3 b)
		{
			return new Uint3(a / b.x, a / b.y, a / b.z);
		}

		public static Uint3 operator +(Uint3 a, uint b)
		{
			return new Uint3(a.x + b, a.y + b, a.z + b);
		}
		public static Uint3 operator -(Uint3 a, uint b)
		{
			return new Uint3(a.x - b, a.y - b, a.z - b);
		}
		public static Uint3 operator *(Uint3 a, uint b)
		{
			return new Uint3(a.x * b, a.y * b, a.z * b);
		}
		public static Uint3 operator /(Uint3 a, uint b)
		{
			return new Uint3(a.x / b, a.y / b, a.z / b);
		}

		public static Uint3 operator +(Uint3 a, Uint3 b)
		{
			return new Uint3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static Uint3 operator -(Uint3 a, Uint3 b)
		{
			return new Uint3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static Uint3 operator *(Uint3 a, Uint3 b)
		{
			return new Uint3(a.x * b.x, a.y * b.y, a.z * b.z);
		}
		public static Uint3 operator /(Uint3 a, Uint3 b)
		{
			return new Uint3(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		public Uint2 xy => new Uint2(x, y);
		public Uint2 yx => new Uint2(y, x);
		public Uint2 yz => new Uint2(y, z);
		public Uint2 zy => new Uint2(z, y);
		public Uint2 xz => new Uint2(x, z);
		public Uint2 zx => new Uint2(z, x);

		public static Uint3 Zero => new Uint3(0);

		public override string ToString() => $"{x}, {y}, {z}";
	}
}