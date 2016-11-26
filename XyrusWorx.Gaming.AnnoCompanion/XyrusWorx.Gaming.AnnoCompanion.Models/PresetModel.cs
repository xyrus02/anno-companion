using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public class PresetModel : ObjectStoreModel
	{
		[JsonIgnore]
		public IModelGenerator Generator { get; set; }

		protected override void LoadOverride(IDataProvider dataProvider)
		{
			var instancePool = dataProvider.CastTo<IInstancePoolFactory>()?.GetInstancePool();
			if (instancePool != null)
			{
				Generator?.Generate(instancePool);
			}
		}
	}
}