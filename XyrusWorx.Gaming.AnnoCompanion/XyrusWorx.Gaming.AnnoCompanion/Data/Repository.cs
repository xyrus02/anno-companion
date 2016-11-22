using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Serialization;
using XyrusWorx.IO;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	class Repository : IDataProvider
	{
		private readonly JsonReferenceResolver mData;
		private readonly ObjectDependencyGraph mSchema;

		public Repository()
		{
			mData = new JsonReferenceResolver();
			mSchema = GetSchema();
		}

		[CanBeNull]
		public T Get<T>(StringKey key) where T : Persistable
		{
			return mData.Resolve(key).CastTo<T>();
		}

		[NotNull]
		public IEnumerable<T> GetAll<T>() where T : Persistable
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

			var container = new FileSystemStore(sourcePath, isReadOnly: true);
			var instancePool = mData;

			foreach (var typePartition in mSchema.GetPartitionsByDependencyDepth())
			{
				foreach (var type in typePartition.OfType<Type>())
				{
					var section = GetContainerKey(type);
					var sectionContainer = container.GetChildStore(section);

					foreach (var leaf in sectionContainer.Keys.Where(x => x.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase)))
					{
						using (var reader = sectionContainer.Open(leaf).AsText().Read())
						{
							var key = Path.GetFileNameWithoutExtension(leaf);
							var instance = Persistable.Deserialize(key, type, reader, instancePool);

							mData.Register(instance);
						}
					}
				}
			}
		}
		public void Export([NotNull] string targetPath)
		{
			if (targetPath == null)
			{
				throw new ArgumentNullException(nameof(targetPath));
			}

			var container = new FileSystemStore(targetPath);
			var instancePool = mData;

			foreach (var type in mSchema.GetKnownElements().OfType<Type>())
			{
				var section = GetContainerKey(type);
				var sectionContainer = container.GetChildStore(section);

				foreach (var instance in instancePool.GetAll(type))
				{
					var key = new StringKey($"{instance.Key}.json");

					using (var writer = sectionContainer.Open(key).AsText().Write())
					{
						instance.Serialize(writer);
					}
				}
			}
		}

		private static StringKey GetContainerKey(Type elementType)
		{
			return elementType.Name + "s"; // cheap ass pluralization :-)
		}
		private static ObjectDependencyGraph GetSchema()
		{
			var schema = new ObjectDependencyGraph();

			var types =
				from type in typeof(Persistable).Assembly.GetTypes()

				where type.IsSubclassOf(typeof(Persistable))
				where !type.IsAbstract && !type.IsInterface

				let dependencies =
					from property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
					from dependency in GetTransientDependencies(property.PropertyType)
					select dependency

				select new
				{
					Type = type,
					Dependencies = new HashSet<Type>(dependencies)
				};

			var composedTypeArray = types.ToArray();

			foreach (var type in composedTypeArray)
			{
				schema.Register(type.Type);
			}

			foreach (var type in composedTypeArray)
			{
				var dep = schema.Element(type.Type);

				foreach (var dependency in type.Dependencies)
				{
					dep.DependsOn(dependency);
				}
			}

			return schema;
		}
		private static IEnumerable<Type> GetTransientDependencies(Type type)
		{
			if (type.IsPrimitive || type == typeof(string))
			{
				yield break;
			}

			if (type.IsSubclassOf(typeof(Persistable)) && !type.IsAbstract && !type.IsInterface)
			{
				yield return type;
			}

			var t = type;
			var properties = new HashSet<PropertyInfo>(new ExpressionComparer<PropertyInfo>(x => x.Name));

			while (t != null && t != typeof(object))
			{
				var typeProperties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

				typeProperties.Foreach(x => properties.Add(x));
				t = t.BaseType;
			}

			foreach (var property in properties)
			{
				foreach (var dependency in GetTransientDependencies(property.PropertyType))
				{
					yield return dependency;
				}
			}
		}
	}
}