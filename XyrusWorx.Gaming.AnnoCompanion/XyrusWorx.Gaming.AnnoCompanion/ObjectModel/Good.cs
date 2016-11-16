namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	abstract class Good : IndexedObject
	{
		public string DisplayName { get; set; }

		public PopulationRequirement UnlockThreshold { get; set; }
	}
}