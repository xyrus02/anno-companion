namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ProvisionCapacity
	{
		public ProvisionCapacity()
		{

		}
		public ProvisionCapacity(int count, PopulationGroup populationGroup) : this()
		{
			Count = count;
			PopulationGroup = populationGroup;
		}

		public int Count { get; set; }

		public PopulationGroup PopulationGroup { get; set; }
	}
}