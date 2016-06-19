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
	public struct Int2 : IVectorType, IVectorType<int>
	{
		public int x, y;

		object[] IVectorType.GetComponents() => new object[] { x, y };
		int[] IVectorType<int>.GetComponents() => new[] { x, y };
		Type IVectorType.ComponentType => typeof(int);

		public Int2(int x = 0, int y = 0)
		{
			this.x = x;
			this.y = y;
		}
		public Int2(Int2 xy) : this(xy.x, xy.y)
		{
		}

		public static Int2 operator +(int a, Int2 b)
		{
			return new Int2(a + b.x, a + b.y);
		}
		public static Int2 operator -(int a, Int2 b)
		{
			return new Int2(a - b.x, a - b.y);
		}
		public static Int2 operator *(int a, Int2 b)
		{
			return new Int2(a * b.x, a * b.y);
		}
		public static Int2 operator /(int a, Int2 b)
		{
			return new Int2(a / b.x, a / b.y);
		}

		public static Int2 operator +(Int2 a, int b)
		{
			return new Int2(a.x + b, a.y + b);
		}
		public static Int2 operator -(Int2 a, int b)
		{
			return new Int2(a.x - b, a.y - b);
		}
		public static Int2 operator *(Int2 a, int b)
		{
			return new Int2(a.x * b, a.y * b);
		}
		public static Int2 operator /(Int2 a, int b)
		{
			return new Int2(a.x / b, a.y / b);
		}

		public static Int2 operator +(Int2 a, Int2 b)
		{
			return new Int2(a.x + b.x, a.y + b.y);
		}
		public static Int2 operator -(Int2 a, Int2 b)
		{
			return new Int2(a.x - b.x, a.y - b.y);
		}
		public static Int2 operator *(Int2 a, Int2 b)
		{
			return new Int2(a.x * b.x, a.y * b.y);
		}
		public static Int2 operator /(Int2 a, Int2 b)
		{
			return new Int2(a.x / b.x, a.y / b.y);
		}

		public static Int2 Zero => new Int2(0);

		public override string ToString() => $"{x}, {y}";
	}
}