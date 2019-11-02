using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public class Fraction : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 2)]
		public string DisplayName { get; set; }

		[JsonProperty(Order = 3)]
		public bool Passive { get; set; }

		[JsonProperty(Order = 4)]
		public int SortOrder { get; set; }
	}
}