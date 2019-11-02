using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[KeyClass]
	[PublicAPI]
	public abstract class Good : Depletable
	{
		[JsonProperty(Order = 2)]
		public double TradeValue { get; set; }

		[JsonProperty(Order = 3)]
		public double ProductionCost { get; set; }
	}
}