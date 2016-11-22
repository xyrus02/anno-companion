﻿using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{DisplayName,nq}")]
	class PopulationGroup : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 1)]
		public string DisplayName { get; set; }

		[JsonProperty(Order = 2)]
		public Faction Faction { get; set; } = Faction.Unspecified;

		[JsonProperty(Required = Required.Always, Order = 3)]
		public int Tier { get; set; }
	}
}