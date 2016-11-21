using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Collections;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class Repository
	{
		private readonly JsonReferenceResolver mData;

		public Repository()
		{
			mData = new JsonReferenceResolver();
		}

		[CanBeNull]
		public T GetByKey<T>(StringKey key) where T : IndexedObject
		{
			return mData.Resolve(key).CastTo<T>();
		}

		[NotNull]
		public IEnumerable<T> GetAll<T>() where T : IndexedObject
		{
			return mData.GetAll<T>();
		}

		public void Clear()
		{
			mData.Clear();
		}
		public void LoadStatic()
		{
			ConstructionMaterials.GetAll().Foreach(x => mData.Register(x));
			WarfareMaterials.GetAll().Foreach(x => mData.Register(x));
			RawMaterials.GetAll().Foreach(x => mData.Register(x));
			ConsumableGoods.GetAll().Foreach(x => mData.Register(x));
			Buildings.GetAll().Foreach(x => mData.Register(x));
			ProductionChains.GetAll().Foreach(x => mData.Register(x));
		}

		public void Import([NotNull] string sourcePath)
		{
			if (sourcePath == null)
			{
				throw new ArgumentNullException(nameof(sourcePath));
			}

			var container = GetContainer(sourcePath);

			foreach (var file in container.RawMaterials.GetChildStoreKeys())
			{
				using (var reader = container.RawMaterials.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<RawMaterial>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}

			foreach (var file in container.ConstructionMaterials.GetChildStoreKeys())
			{
				using (var reader = container.ConstructionMaterials.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<ConstructionMaterial>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}

			foreach (var file in container.WarfareMaterials.GetChildStoreKeys())
			{
				using (var reader = container.WarfareMaterials.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<WarfareMaterial>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}

			foreach (var file in container.ConsumableGoods.GetChildStoreKeys())
			{
				using (var reader = container.ConsumableGoods.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<ConsumableGood>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}

			foreach (var file in container.PopulationGroups.GetChildStoreKeys())
			{
				using (var reader = container.PopulationGroups.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<PopulationGroup>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}

			foreach (var file in container.Buildings.GetChildStoreKeys())
			{
				using (var reader = container.Buildings.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<Building>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}

			foreach (var file in container.ProductionChains.GetChildStoreKeys())
			{
				using (var reader = container.ProductionChains.Open(file).AsText().Read())
				{
					var obj = IndexedObject.Deserialize<ProductionChain>(Path.GetFileNameWithoutExtension(file.RawData), reader, mData);
					mData.Register(obj);
				}
			}
		}
		public void Export([NotNull] string targetPath)
		{
			if (targetPath == null)
			{
				throw new ArgumentNullException(nameof(targetPath));
			}

			var container = GetContainer(targetPath);

			foreach (var good in GetAll<ConstructionMaterial>())
			{
				using (var writer = container.ConstructionMaterials.Open(good.Key + ".json").AsText().Write())
				{
					good.Serialize(writer);
				}
			}

			foreach (var good in GetAll<WarfareMaterial>())
			{
				using (var writer = container.WarfareMaterials.Open(good.Key + ".json").AsText().Write())
				{
					good.Serialize(writer);
				}
			}

			foreach (var good in GetAll<RawMaterial>())
			{
				using (var writer = container.RawMaterials.Open(good.Key + ".json").AsText().Write())
				{
					good.Serialize(writer);
				}
			}

			foreach (var good in GetAll<ConsumableGood>())
			{
				using (var writer = container.ConsumableGoods.Open(good.Key + ".json").AsText().Write())
				{
					good.Serialize(writer);
				}
			}

			foreach (var building in GetAll<Building>())
			{
				using (var writer = container.Buildings.Open(building.Key + ".json").AsText().Write())
				{
					building.Serialize(writer);
				}
			}

			foreach (var chain in GetAll<ProductionChain>())
			{
				using (var writer = container.ProductionChains.Open(chain.Key + ".json").AsText().Write())
				{
					chain.Serialize(writer);
				}
			}
		}

		private Container GetContainer(string targetPath)
		{
			var rootContainer = new FileSystemStore(targetPath);

			var goods = rootContainer.GetChildStore("Goods");
			var buildings = rootContainer.GetChildStore("Buildings");
			var productionChains = rootContainer.GetChildStore("ProductionChains");
			var populationGroups = rootContainer.GetChildStore("PopulationGroups");

			var container = new Container
			{
				Goods = goods,
				Buildings = buildings,
				ProductionChains = productionChains,
				PopulationGroups = populationGroups,

				ConstructionMaterials = goods.GetChildStore("ConstructionMaterials"),
				RawMaterials = goods.GetChildStore("RawMaterials"),
				WarfareMaterials = goods.GetChildStore("WarfareMaterials"),
				ConsumableGoods = goods.GetChildStore("ConsumableGoods")
			};

			return container;
		}

		struct Container
		{
			public IBlobStore Goods;
			public IBlobStore Buildings;
			public IBlobStore ProductionChains;
			public IBlobStore PopulationGroups;

			public IBlobStore ConstructionMaterials;
			public IBlobStore RawMaterials;
			public IBlobStore WarfareMaterials;
			public IBlobStore ConsumableGoods;
		}
	}

	static class ConstructionMaterials
	{
		public static readonly ConstructionMaterial Wood;
		public static readonly ConstructionMaterial Tools;
		public static readonly ConstructionMaterial Stone;
		public static readonly ConstructionMaterial Glass;
		public static readonly ConstructionMaterial Mosaic;

		static ConstructionMaterials()
		{
			Wood = new ConstructionMaterial
			{
				Key = "Wood",
				DisplayName = "Holz",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants),

				TradeValue = 4,
				ProductionCost = 3.33
			};

			Tools = new ConstructionMaterial
			{
				Key = "Tools",
				DisplayName = "Werkzeug",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 36,
				ProductionCost = 27.5
			};

			Stone = new ConstructionMaterial
			{
				Key = "Stone",
				DisplayName = "Steine",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),

				TradeValue = 8,
				ProductionCost = 10
			};

			Glass = new ConstructionMaterial
			{
				Key = "Glass",
				DisplayName = "Glas",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				TradeValue = 68,
				ProductionCost = 26.25
			};

			Mosaic = new ConstructionMaterial
			{
				Key = "Mosaic",
				DisplayName = "Mosaik",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				TradeValue = 46,
				ProductionCost = 32.5
			};
		}

		[CanBeNull]
		public static ConstructionMaterial GetByKey(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}

			var field = typeof(ConstructionMaterials).GetField(key, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (ConstructionMaterial)field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<ConstructionMaterial> GetAll()
		{
			foreach (var field in typeof(ConstructionMaterials).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (ConstructionMaterial)field.GetValue(null);
			}
		}
	}
}