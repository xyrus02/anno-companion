﻿using System.Diagnostics;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	class Building : Persistable
	{
		public string DisplayName { get; set; }

		public BuildingRestrictions Restrictions { get; set; } = BuildingRestrictions.None;

		public BuildingInput[] Input { get; set; }
		public BuildingOutput Output { get; set; }

		public double ActiveCostPerMinute { get; set; }
		public double InactiveCostPerMinute { get; set; }
		public double ProductionPerMinute { get; set; }
	}
}