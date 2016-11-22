using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[KeyClass]
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public abstract class Building : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 1)]
		public string DisplayName { get; set; }

		[JsonProperty(Order = 2)]
		public BuildingRestriction Restrictions { get; set; }

		[JsonProperty(Required = Required.Always, Order = 3)]
		public PopulationRequirement UnlockThreshold { get; set; }
	}
}