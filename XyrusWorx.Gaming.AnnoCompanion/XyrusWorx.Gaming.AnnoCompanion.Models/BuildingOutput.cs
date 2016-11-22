using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{Good.DisplayName,nq}")]
	public class BuildingOutput : Model
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