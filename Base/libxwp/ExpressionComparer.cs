using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class ExpressionComparer<T> : IEqualityComparer<T>
	{
		private readonly Func<T, object> mExpression;

		public ExpressionComparer([NotNull] Expression<Func<T, object>> expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException(nameof(expression));
			}

			mExpression = expression.Compile();
		}

		public bool Equals(T x, T y)
		{
			var a = x == null ? null : mExpression(x);
			var b = y == null ? null : mExpression(y);

			return Equals(a, b);
		}
		public int GetHashCode(T obj)
		{
			return obj == null ? 0 : mExpression(obj)?.GetHashCode() ?? 0;
		}
	}
}