using System.Diagnostics;
using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{DisplayName}")]
	abstract class Good : IndexedObject
	{
		[JsonRequired]
		public string DisplayName { get; set; }

		public double TradeValue { get; set; }
		public double ProductionCost { get; set; }

		[JsonRequired]
		public PopulationRequirement UnlockThreshold { get; set; }
	}
}