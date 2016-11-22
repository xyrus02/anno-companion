using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{DisplayName}")]
	abstract class Good : Persistable
	{
		[JsonRequired]
		public string DisplayName { get; set; }

		public double TradeValue { get; set; }
		public double ProductionCost { get; set; }

		[JsonRequired]
		public PopulationRequirement UnlockThreshold { get; set; }
	}
}