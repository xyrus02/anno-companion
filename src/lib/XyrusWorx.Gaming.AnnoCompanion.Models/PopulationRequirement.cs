using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{Count} {PopulationGroup.DisplayName,nq}")]
	public class PopulationRequirement : Model
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

		[JsonProperty(Order = 1)]
		public int Count { get; set; } = 1;

		[JsonProperty(Required = Required.Always, Order = 2)]
		public PopulationGroup PopulationGroup { get; set; }
	}
}