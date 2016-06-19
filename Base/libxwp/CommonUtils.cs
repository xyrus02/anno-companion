using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public static class CommonUtils
	{
		public static T UnboxTo<T>([CanBeNull] this object instance) 
		{
			return instance is T ? (T)instance : default(T);
		}

		public static T? UnboxToOrNull<T>([CanBeNull] this object instance) where T: struct
		{
			return instance as T?;
		}

		[CanBeNull]
		public static T CastTo<T>([CanBeNull] this object instance) where T : class
		{
			return instance as T;
		}

		public static bool HasFlag(this int value, int flag)
		{
			return (value & flag) == flag;
		}

		[NotNull]
		public static IEnumerable<Exception> Unroll([NotNull] this Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}

			var list = new List<Exception> { exception };

			while (exception.InnerException != null)
			{
				list.Insert(0, exception.InnerException);
				exception = exception.InnerException;
			}

			return list;
		}

		public static TOut? TransformOrNull<TIn, TOut>(this TIn? value, Func<TIn, TOut> transform)
			where TIn : struct
			where TOut : struct
		{
			return value.HasValue ? transform(value.Value) : (TOut?) null;
		}

		[Pure]
		public static double GetNumericValue(this object parameter)
		{
			return parameter == null ? 0.0d : parameter as double? ?? (
				(parameter is int) ? (double)(int)parameter :
				(parameter is uint) ? (double)(uint)parameter :
				(parameter is short) ? (double)(short)parameter :
				(parameter is ushort) ? (double)(ushort)parameter :
				(parameter is long) ? (double)(long)parameter :
				(parameter is ulong) ? (double)(ulong)parameter :
				(parameter is float) ? (double)(float)parameter :
				(parameter is decimal) ? (double)(decimal)parameter :
				(parameter is byte) ? (double)(byte)parameter :
				(parameter is sbyte) ? (double)(sbyte)parameter :
				(parameter is string) ? parameter.ToString().TryDeserializeNumericValue() :
				0.0d);
		}
	}
}