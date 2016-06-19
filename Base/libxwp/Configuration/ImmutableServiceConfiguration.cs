using System;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class ImmutableServiceConfiguration : ServiceConfiguration
	{
		public ImmutableServiceConfiguration([NotNull] ServiceConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			base.Hostname = configuration.Hostname;
			base.Port = configuration.Port;
			base.Protocol = configuration.Protocol;
		}

		public new string Hostname => base.Hostname;
		public new ushort Port => base.Port;
		public new ServiceProtocol Protocol => base.Protocol;
	}
}