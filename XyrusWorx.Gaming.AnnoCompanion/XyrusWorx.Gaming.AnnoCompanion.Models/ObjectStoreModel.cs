using System;
using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{DisplayName,nq}")]
	public abstract class ObjectStoreModel : Persistable
	{
		[JsonProperty(Required = Required.Always, Order = 2)]
		public string DisplayName { get; set; }

		[JsonIgnore]
		public IBlobStore IconStore { get; set; }

		public void Load([NotNull] IDataProvider dataProvider)
		{
			if (dataProvider == null)
			{
				throw new ArgumentNullException(nameof(dataProvider));
			}

			LoadOverride(dataProvider);
		}

		protected abstract void LoadOverride([NotNull] IDataProvider dataProvider);
	}
}