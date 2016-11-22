using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ConsumableGood : Good
	{
		[JsonProperty(Required = Required.Always, Order = 4)]
		public ProvisionCapacity[] ProvisionCapacities { get; set; }
	}
}