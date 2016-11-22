using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Good.DisplayName,nq}")]
	class BuildingOutput : Model
	{
		[JsonConstructor]
		public BuildingOutput()
		{
			
		}
		public BuildingOutput(Good good, double outputPerMinute)
		{
			Good = good;
		}

		[JsonProperty(Required = Required.Always, Order = 1)]
		public Good Good { get; set; }

		[JsonProperty(Order = 2)]
		public double OutputPerMinute { get; set; }
	}
}