using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Count} {PopulationGroup.DisplayName,nq}")]
	class ProvisionCapacity : Model
	{
		[JsonConstructor]
		public ProvisionCapacity()
		{

		}
		public ProvisionCapacity(int count, PopulationGroup populationGroup) : this()
		{
			Count = count;
			PopulationGroup = populationGroup;
		}

		[JsonProperty(Order = 1)]
		public int Count { get; set; } = 1;

		[JsonProperty(Required = Required.Always, Order = 2)]
		public PopulationGroup PopulationGroup { get; set; }
	}
}