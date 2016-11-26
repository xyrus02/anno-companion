using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	public class ProfileModel : ObjectStoreModel
	{
		[JsonProperty(Required = Required.Always, Order = 3)]
		public PresetModel BasedOn { get; set; }

		[JsonIgnore]
		public IBlobStore DataStore { get; set; }

		protected override void LoadOverride(IDataProvider dataProvider)
		{
			if (DataStore != null)
			{
				dataProvider.Import(DataStore);
			}
		}
	}
}