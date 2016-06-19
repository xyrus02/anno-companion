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
	public struct Uint2 : IVectorType, IVectorType<uint>
	{
		public uint x, y;

		object[] IVectorType.GetComponents() => new object[] { x, y };
		uint[] IVectorType<uint>.GetComponents() => new[] { x, y };
		Type IVectorType.ComponentType => typeof (uint);

		public Uint2(uint x = 0, uint y = 0)
		{
			this.x = x;
			this.y = y;
		}
		public Uint2(Uint2 xy) : this(xy.x, xy.y)
		{
		}

		public static Uint2 operator +(uint a, Uint2 b)
		{
			return new Uint2(a + b.x, a + b.y);
		}
		public static Uint2 operator -(uint a, Uint2 b)
		{
			return new Uint2(a - b.x, a - b.y);
		}
		public static Uint2 operator *(uint a, Uint2 b)
		{
			return new Uint2(a * b.x, a * b.y);
		}
		public static Uint2 operator /(uint a, Uint2 b)
		{
			return new Uint2(a / b.x, a / b.y);
		}

		public static Uint2 operator +(Uint2 a, uint b)
		{
			return new Uint2(a.x + b, a.y + b);
		}
		public static Uint2 operator -(Uint2 a, uint b)
		{
			return new Uint2(a.x - b, a.y - b);
		}
		public static Uint2 operator *(Uint2 a, uint b)
		{
			return new Uint2(a.x * b, a.y * b);
		}
		public static Uint2 operator /(Uint2 a, uint b)
		{
			return new Uint2(a.x / b, a.y / b);
		}

		public static Uint2 operator +(Uint2 a, Uint2 b)
		{
			return new Uint2(a.x + b.x, a.y + b.y);
		}
		public static Uint2 operator -(Uint2 a, Uint2 b)
		{
			return new Uint2(a.x - b.x, a.y - b.y);
		}
		public static Uint2 operator *(Uint2 a, Uint2 b)
		{
			return new Uint2(a.x * b.x, a.y * b.y);
		}
		public static Uint2 operator /(Uint2 a, Uint2 b)
		{
			return new Uint2(a.x / b.x, a.y / b.y);
		}

		public static Uint2 Zero => new Uint2(0);

		public override string ToString() => $"{x}, {y}";
	}
}