using System.Diagnostics;
using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Good.DisplayName}")]
	class BuildingOutput
	{
		[JsonConstructor]
		public BuildingOutput()
		{
			
		}
		public BuildingOutput(Good good)
		{
			Good = good;
		}

		[JsonRequired]
		public Good Good { get; set; }
	}
}