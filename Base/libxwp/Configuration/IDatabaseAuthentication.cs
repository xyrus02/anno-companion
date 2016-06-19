using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public interface IDatabaseAuthentication
	{
		void Read([NotNull] IKeyedConfigurationProvider provider, IDictionary<string, string> keyMappings = null);
	}
}