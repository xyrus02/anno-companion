using System.Diagnostics;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	class Building : IndexedObject
	{
		public string DisplayName { get; set; }

		public BuildingLocation Location { get; set; }

		public Good[] Input { get; set; }

		public Good Output { get; set; }

		public double ActiveCostPerMinute { get; set; }

		public double InactiveCostPerMinute { get; set; }

		public double ProductionPerMinute { get; set; }
	}
}