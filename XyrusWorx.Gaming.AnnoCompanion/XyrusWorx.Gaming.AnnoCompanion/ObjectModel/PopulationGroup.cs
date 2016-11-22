using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{DisplayName}")]
	class PopulationGroup : Persistable
	{
		[JsonRequired]
		public string DisplayName { get; set; }

		[JsonRequired]
		public int Tier { get; set; }

		[JsonRequired]
		public Factions Faction { get; set; }
	}
}