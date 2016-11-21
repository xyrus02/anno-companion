using System.Diagnostics;
using Newtonsoft.Json;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Good.DisplayName}")]
	class BuildingInput
	{
		[JsonConstructor]
		public BuildingInput()
		{

		}
		public BuildingInput(Good good)
		{
			Good = good;
		}

		[JsonRequired]
		public Good Good { get; set; }
	}
}