using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public abstract class Depletable : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 1)]
		public string DisplayName { get; set; }
	}
}