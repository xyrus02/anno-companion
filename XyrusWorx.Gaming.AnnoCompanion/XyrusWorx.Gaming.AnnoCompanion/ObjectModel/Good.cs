using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	abstract class Good : IndexedObject
	{
		public string DisplayName { get; set; }

		public PopulationRequirement UnlockThreshold { get; set; }

		public double CommonTradeValue { get; set; }

		public double CommonProductionCost { get; set; }
	}
}