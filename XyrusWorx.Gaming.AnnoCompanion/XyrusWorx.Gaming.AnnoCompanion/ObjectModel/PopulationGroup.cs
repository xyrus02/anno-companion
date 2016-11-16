namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class PopulationGroup
	{
		public string Key { get; set; }

		public string DisplayName { get; set; }

		public int Tier { get; set; }

		public Factions Faction { get; set; }
	}
}