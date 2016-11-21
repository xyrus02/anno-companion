using System.Diagnostics;
using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{DisplayName}")]
	class PopulationGroup : IndexedObject
	{
		[JsonRequired]
		public string DisplayName { get; set; }

		[JsonRequired]
		public int Tier { get; set; }

		[JsonRequired]
		public Factions Faction { get; set; }
	}
}