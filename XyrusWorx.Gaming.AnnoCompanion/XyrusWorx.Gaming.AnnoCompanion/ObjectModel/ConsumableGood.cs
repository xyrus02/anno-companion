namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ConsumableGood
	{
		public string Key { get; set; }

		public string DisplayName { get; set; }

		public PopulationRequirement UnlockThreshold { get; set; }

		public PopulationGroup[] RequiredBy { get; set; }
	}
}