using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{DisplayName,nq}")]
	abstract class Depletable : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 1)]
		public string DisplayName { get; set; }
	}
}