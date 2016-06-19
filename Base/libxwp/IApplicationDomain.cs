using System.Diagnostics;
using JetBrains.Annotations;
using XW.Configuration;
using XW.Diagnostics;

namespace XW
{
	[PublicAPI]
	public interface IApplicationDomain
	{
		IScopedLogProvider Log { get; }
		IKeyedConfigurationProvider RoamingConfiguration { get; }
		IVersionInfo VersionInfo { get; }

		void Initialize();
		void Shutdown();

		event UncleanShutdownEventHandler UncleanShutdown;
	}
}