using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public sealed class IntegratedSecurityAuthentication : IDatabaseAuthentication
	{
		public void Read(IKeyedConfigurationProvider provider, IDictionary<string, string> keyMappings = null)
		{
		}
	}
}