using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JetBrains.Annotations;
using XyrusWorx.IO;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	class IconResolver : IIconResolver
	{
		private readonly ObjectDependencyGraph<PersistedNode> mSchema;
		private readonly Dictionary<StringKeySequence, ImageSource> mCache;
		private readonly List<IBlobStore> mStores;

		internal IconResolver([NotNull] ObjectDependencyGraph<PersistedNode> schema)
		{
			if (schema == null)
			{
				throw new ArgumentNullException(nameof(schema));
			}

			mSchema = schema;
			mStores = new List<IBlobStore>();
			mCache = new Dictionary<StringKeySequence, ImageSource>();
		}

		public void AddExternalDataSource(IBlobStore store)
		{
			if (store == null)
			{
				throw new ArgumentNullException(nameof(store));
			}

			mStores.Add(store);
		}

		public ImageSource GetIcon<T>(StringKey key)
		{
			var category = PersistedNode.GetContainerKey(typeof(T));

			return GetIcon(key, category);
		}
		public ImageSource GetIcon(StringKey key, StringKey category)
		{
			if (key.IsEmpty || category.IsEmpty)
			{
				return null;
			}

			var compositeKey = new StringKeySequence(category, key);
			if (mCache.ContainsKey(compositeKey))
			{
				return mCache[compositeKey];
			}

			foreach (var store in mStores.AsEnumerable().Reverse())
			{
				if (!store.HasChildStore(category))
				{
					continue;
				}

				var categoryStore = store.GetChildStore(category, true);
				if (!categoryStore.ContainsKey(key.RawData))
				{
					continue;
				}

				try
				{
					using (var binaryData = categoryStore.Open(key).Read())
					{
						var decoder = new PngBitmapDecoder(binaryData.BaseStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
						if (!decoder.Frames.Any())
						{
							continue;
						}

						var frame = (ImageSource)decoder.Frames.First();
						var frozenSource = (ImageSource) frame.GetAsFrozen();

						mCache.Add(compositeKey, frozenSource);
						return frozenSource;
					}
				}
				catch
				{
					// ignore
				}
			}

			return null;
		}
	}
}