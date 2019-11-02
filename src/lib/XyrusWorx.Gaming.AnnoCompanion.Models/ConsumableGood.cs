using JetBrains.Annotations;
using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	public class ConsumableGood : Good
	{
		[JsonProperty(Required = Required.Always, Order = 4)]
		public ProvisionCapacity[] ProvisionCapacities { get; set; }
	}
}