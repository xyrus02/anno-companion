using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{Input.DisplayName,nq}")]
	public class BuildingInput : Model
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