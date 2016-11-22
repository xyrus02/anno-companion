using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{Building.DisplayName,nq}")]
	public class ProductionChainComponent : Model
	{
		[JsonConstructor]
		public ProductionChainComponent()
		{
		}
		public ProductionChainComponent(int count, ProductionBuilding building, double ratio = 1.0) : this()
		{
			Count = count;
			Building = building;
			Ratio = ratio;
		}

		[JsonProperty(Required = Required.Always, Order = 1)]
		public ProductionBuilding Building { get; set; }

		[JsonProperty(Order = 2)]
		public int Count { get; set; } = 1;

		[JsonProperty(Order = 3)]
		public double Ratio { get; set; } = 1.0;
	}
}