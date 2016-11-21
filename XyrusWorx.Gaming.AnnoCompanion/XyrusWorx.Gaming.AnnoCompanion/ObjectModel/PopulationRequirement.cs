using System.Diagnostics;
using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Count} citizen(s) of {PopulationGroup}")]
	class PopulationRequirement
	{
		[JsonConstructor]
		public PopulationRequirement()
		{
			
		}
		public PopulationRequirement(int count, PopulationGroup populationGroup) : this()
		{
			Count = count;
			PopulationGroup = populationGroup;
		}

		[JsonRequired]
		public int Count { get; set; }

		[JsonRequired]
		public PopulationGroup PopulationGroup { get; set; }
	}
}