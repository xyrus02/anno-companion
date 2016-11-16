namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class PopulationGroup : IndexedObject
	{
		public string DisplayName { get; set; }

		public int Tier { get; set; }

		public Factions Faction { get; set; }
	}
}