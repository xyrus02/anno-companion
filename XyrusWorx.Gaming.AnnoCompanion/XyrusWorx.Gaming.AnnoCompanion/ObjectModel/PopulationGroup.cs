using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Faction} tier {Tier}")]
	class PopulationGroup : IndexedObject
	{
		public string DisplayName { get; set; }

		public int Tier { get; set; }

		public Factions Faction { get; set; }
	}
}