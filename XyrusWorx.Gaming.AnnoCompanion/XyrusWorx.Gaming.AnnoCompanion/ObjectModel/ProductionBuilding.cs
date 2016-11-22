using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ProductionBuilding : Building
	{
		[JsonProperty(Required = Required.Always, Order = 4)]
		public BuildingInput[] Input { get; set; }

		[JsonProperty(Required = Required.Always, Order = 5)]
		public BuildingOutput Output { get; set; }

		[JsonProperty(Order = 6)]
		public double ActiveCostPerMinute { get; set; }

		[JsonProperty(Order = 7)]
		public double InactiveCostPerMinute { get; set; }
	}
}