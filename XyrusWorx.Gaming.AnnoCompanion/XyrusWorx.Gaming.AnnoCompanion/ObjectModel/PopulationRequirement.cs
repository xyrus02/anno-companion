namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class PopulationRequirement
	{
		public PopulationRequirement()
		{
			
		}
		public PopulationRequirement(int count, PopulationGroup populationGroup) : this()
		{
			Count = count;
			PopulationGroup = populationGroup;
		}

		public int Count { get; set; }

		public PopulationGroup PopulationGroup { get; set; }
	}
}