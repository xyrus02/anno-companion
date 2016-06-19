using System;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class DefaultPropertyImplementationAttribute : Attribute
	{
		public DefaultPropertyImplementationAttribute([NotNull] Type forType)
		{
			if (forType == null)
			{
				throw new ArgumentNullException(nameof(forType));
			}
			ForType = forType;
		}

		[NotNull]
		public Type ForType { get; }
	}
}