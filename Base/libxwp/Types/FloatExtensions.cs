using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, StructLayout(LayoutKind.Sequential)]
	public static class FloatExtensions
	{
		public static byte ToByte(this float x)
		{
			return (byte) (int) (Math.Max(0, Math.Min(x, 1))*255);
		}
	}
}