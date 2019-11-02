using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public class BuildingRestriction : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 2)]
		public string DisplayName { get; set; }
	}
}