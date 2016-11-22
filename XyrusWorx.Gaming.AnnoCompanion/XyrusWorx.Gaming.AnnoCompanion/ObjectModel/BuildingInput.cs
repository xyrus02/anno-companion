using System.Diagnostics;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Input.DisplayName,nq}")]
	class BuildingInput : Model
	{
		[JsonConstructor]
		public BuildingInput()
		{

		}
		public BuildingInput(Depletable input)
		{
			Input = input;
		}

		[JsonProperty(Required = Required.Always)]
		public Depletable Input { get; set; }
	}
}