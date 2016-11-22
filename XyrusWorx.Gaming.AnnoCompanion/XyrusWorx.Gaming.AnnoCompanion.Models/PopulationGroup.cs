using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public class PopulationGroup : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 1)]
		public string DisplayName { get; set; }

		[JsonProperty(Required = Required.Always, Order = 2)]
		public Fraction Fraction { get; set; }

		[JsonProperty(Required = Required.Always, Order = 3)]
		public int Tier { get; set; }
	}
}