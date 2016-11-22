using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[KeyClass]
	[DebuggerDisplay("{DisplayName,nq}")]
	abstract class Building : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 1)]
		public string DisplayName { get; set; }

		[JsonProperty(Order = 2)]
		public BuildingRestrictions Restrictions { get; set; } = BuildingRestrictions.None;

		[JsonProperty(Required = Required.Always, Order = 3)]
		public PopulationRequirement UnlockThreshold { get; set; }
	}
}