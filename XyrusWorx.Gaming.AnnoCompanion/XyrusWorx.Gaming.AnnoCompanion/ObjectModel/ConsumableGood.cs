using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	class ConsumableGood : Good
	{
		public PopulationGroup[] ConsumingPopulationGroups { get; set; }
	}
}