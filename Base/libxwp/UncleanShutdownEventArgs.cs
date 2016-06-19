using System;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class UncleanShutdownEventArgs
	{
		private readonly Exception mException;

		public UncleanShutdownEventArgs([NotNull] Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}

			mException = exception;
		}

		[NotNull]
		public Exception Exception => mException;
	}
}