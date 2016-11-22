using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Serialization;
using XyrusWorx.IO;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public class Repository : IDataProvider, IInstancePoolFactory, IIconResolverFactory
	{
		private readonly ObjectDependencyGraph<PersistedNode> mSchema;
		private readonly List<JsonConverter> mConverters;

		private IInstancePool mInstancePool;
		private IIconResolver mResolver;

		public Repository(params Assembly[] searchAssemblies)
		{
			mInstancePool = new JsonReferenceResolver();

			mSchema = PersistedNode.GetSchema(searchAssemblies ?? new Assembly[0]);
			mConverters = PersistedNode.GetConverters(searchAssemblies ?? new Assembly[0]);
		}

		[CanBeNull]
		public T Get<T>(StringKey key) where T : Persistable
		{
			if (key.IsEmpty)
			{
				return default(T);
			}

			return mInstancePool.Resolve(key).CastTo<T>();
		}

		[NotNull]
		public IEnumerable<T> GetAll<T>() where T : Persistable
		{
			return mInstancePool.GetAll<T>();
		}

		[NotNull]
		public IInstancePool GetInstancePool()
		{
			return mInstancePool;
		}

		[NotNull]
		public IIconResolver GetIconResolver()
		{
			return mResolver ?? (mResolver = new IconResolver(mSchema));
		}

		public void Clear()
		{
			mInstancePool.Clear();
		}
		public void Import(IBlobStore source)
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
									var instance = Persistable.Deserialize(key, implementation, reader, instancePool, mConverters);

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
		public void Export(IBlobStore target)
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
							instance.Serialize(writer, mConverters);
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