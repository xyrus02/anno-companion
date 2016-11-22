using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Serialization;
using XyrusWorx.Gaming.AnnoCompanion.Static;
using XyrusWorx.IO;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	class Repository : IDataProvider
	{
		private readonly ObjectDependencyGraph<PersistedNode> mSchema;
		private readonly IInstancePool mInstancePool;

		public Repository()
		{
			mInstancePool = new JsonReferenceResolver();
			mSchema = PersistedNode.GetSchema(typeof(Persistable).Assembly);
		}

		[CanBeNull]
		public T Get<T>(StringKey key) where T : Persistable
		{
			return mInstancePool.Resolve(key).CastTo<T>();
		}

		[NotNull]
		public IEnumerable<T> GetAll<T>() where T : Persistable
		{
			return mInstancePool.GetAll<T>();
		}

		[NotNull]
		public IInstancePool InstancePool => mInstancePool;

		[Obsolete]
		public void LoadStatic()
		{
			Fertilities.GetAll().Foreach(x => mInstancePool.Register(x));
			WaterResources.GetAll().Foreach(x => mInstancePool.Register(x));
			MountainResources.GetAll().Foreach(x => mInstancePool.Register(x));
			ConstructionMaterials.GetAll().Foreach(x => mInstancePool.Register(x));
			WarfareMaterials.GetAll().Foreach(x => mInstancePool.Register(x));
			RawMaterials.GetAll().Foreach(x => mInstancePool.Register(x));
			ConsumableGoods.GetAll().Foreach(x => mInstancePool.Register(x));
			Buildings.GetAll().Foreach(x => mInstancePool.Register(x));
			ProductionChains.GetAll().Foreach(x => mInstancePool.Register(x));
			PopulationGroups.GetAll().Foreach(x => mInstancePool.Register(x));
		}

		public void Clear()
		{
			mInstancePool.Clear();
		}

		public void Import([NotNull] IBlobStore source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var container = source;
			var instancePool = mInstancePool;

			foreach (var keyTypePartition in mSchema.GetPartitionsByDependencyDepth())
			{
				foreach (var keyType in keyTypePartition)
				{
					foreach (var implementation in keyType.ConcreteTypes)
					{
						var section = PersistedNode.GetContainerKey(implementation);
						var sectionContainer = container.GetChildStore(section);

						foreach (var leaf in sectionContainer.Keys.Where(x => x.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase)))
						{
							using (var reader = sectionContainer.Open(leaf).AsText().Read())
							{
								var key = Path.GetFileNameWithoutExtension(leaf);

								try
								{
									var instance = Persistable.Deserialize(key, implementation, reader, instancePool);

									mInstancePool.Register(instance);
								}
								catch (Exception exception)
								{
									throw new InvalidDataException($"Object \"{key}\" ({section}): {exception.Message}", exception);
								}
							}
						}
					}
				}
			}
		}
		public void Export([NotNull] IBlobStore target)
		{
			if (target == null)
			{
				throw new ArgumentNullException(nameof(target));
			}

			var container = target;
			var instancePool = mInstancePool;

			foreach (var type in mSchema.GetKnownElements().SelectMany(x => x.ConcreteTypes))
			{
				var section = PersistedNode.GetContainerKey(type);
				var sectionContainer = container.GetChildStore(section);

				foreach (var instance in instancePool.GetAll(type))
				{
					var key = new StringKey($"{instance.Key}.json");

					using (var writer = sectionContainer.Open(key).AsText().Write())
					{
						try
						{
							instance.Serialize(writer);
						}
						catch (Exception exception)
						{
							throw new InvalidDataException($"Object \"{instance.Key}\" ({section}): {exception.Message}", exception);
						}
					}
				}
			}
		}
	}
}