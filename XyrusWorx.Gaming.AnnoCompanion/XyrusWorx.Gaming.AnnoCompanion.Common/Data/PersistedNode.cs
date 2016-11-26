using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Collections;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[DebuggerDisplay("{Key}")]
	class PersistedNode
	{
		private PersistedNode([NotNull] Type key)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}

			Key = key;
			ConcreteTypes = new HashSet<Type>();
			Dependencies = new HashSet<Type>();
		}

		[NotNull]
		public Type Key { get; }

		[NotNull]
		public HashSet<Type> ConcreteTypes { get; }

		[NotNull]
		public HashSet<Type> Dependencies { get; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((PersistedNode) obj);
		}
		public override int GetHashCode()
		{
			return Key.GetHashCode();
		}

		public static bool operator ==(PersistedNode left, PersistedNode right)
		{
			return Equals(left, right);
		}
		public static bool operator !=(PersistedNode left, PersistedNode right)
		{
			return !Equals(left, right);
		}

		public static StringKey GetContainerKey([NotNull] Type elementType)
		{
			if (elementType == null)
			{
				throw new ArgumentNullException(nameof(elementType));
			}

			if (elementType.Name.EndsWith("y"))
			{
				var n = elementType.Name.Substring(0, elementType.Name.Length - 1);
				return n + "ies";
			}

			return elementType.Name + "s"; // cheap ass pluralization :-)
		}

		[NotNull]
		public static ObjectDependencyGraph<PersistedNode> GetSchema(params Assembly[] searchAssemblies)
		{
			var schema = new ObjectDependencyGraph<PersistedNode>();

			var types =
				from assembly in searchAssemblies
				from type in assembly.GetTypes()

				where type.IsSubclassOf(typeof(Persistable))
				where !type.IsAbstract && !type.IsInterface

				select type;

			var composedTypeArray = types.ToArray();
			var typeToInfoDictionary = new Dictionary<Type, PersistedNode>();

			foreach (var type in composedTypeArray)
			{
				var currentHierarchyLevel = type;
				var keyType = type;

				while (currentHierarchyLevel != null && currentHierarchyLevel != typeof(Persistable) && currentHierarchyLevel != typeof(object))
				{
					if (currentHierarchyLevel.GetCustomAttribute<KeyClassAttribute>(false) != null)
					{
						keyType = currentHierarchyLevel;
						break;
					}

					currentHierarchyLevel = currentHierarchyLevel.BaseType;
				}

				var info = typeToInfoDictionary.GetValueByKeyOrDefault(keyType);
				if (info == null)
				{
					typeToInfoDictionary.Add(keyType, info = new PersistedNode(keyType));
				}

				var transientDependencies =
					from property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
					from dependency in GetTransientDependencies(property.PropertyType)
					select dependency;

				info.ConcreteTypes.Add(type);

				foreach (var dependency in transientDependencies)
				{
					info.Dependencies.Add(dependency);
				}

				schema.Register(info);
				typeToInfoDictionary.AddOrUpdate(keyType, info);
			}

			foreach (var type in typeToInfoDictionary.Keys)
			{
				var info = typeToInfoDictionary[type];
				var dependencyNode = schema.Element(info);

				foreach (var dependency in info.Dependencies)
				{
					var dependencyInfo = typeToInfoDictionary.GetValueByKeyOrDefault(dependency);
					if (dependencyInfo == null || dependencyInfo.Key == dependency)
					{
						continue;
					}

					dependencyNode.DependsOn(dependencyInfo);
				}
			}

			return schema;
		}

		[NotNull]
		public static List<JsonConverter> GetConverters(params Assembly[] searchAssemblies)
		{
			var types =
				from assembly in searchAssemblies
				from type in assembly.GetTypes()

				where type.IsSubclassOf(typeof(JsonConverter))
				where !type.IsAbstract && !type.IsInterface
				
				let parameterlessConstructors = 
					from constructor in type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
					let parameters = constructor.GetParameters()
					where parameters.Length == 0
					select parameters

				where parameterlessConstructors.Any()

				select type;

			return new List<JsonConverter>(
				from type in types
				let instance = (JsonConverter)Activator.CreateInstance(type)
				select instance);
		}

		private static IEnumerable<Type> GetTransientDependencies(Type type)
		{
			if (type.IsPrimitive || type.IsEnum || type == typeof(string))
			{
				yield break;
			}

			if (type.IsSubclassOf(typeof(Persistable)))
			{
				yield return type;
			}

			if (type.IsArray)
			{
				var elementType = type.GetElementType();
				if (elementType != null && elementType != type)
				{
					foreach (var dependency in GetTransientDependencies(elementType))
					{
						yield return dependency;
					}
				}

				yield break;
			}

			var currentHierarchyLevel = type;
			var properties = new HashSet<PropertyInfo>(new ExpressionComparer<PropertyInfo>(x => x.Name));

			while (currentHierarchyLevel != null && currentHierarchyLevel != typeof(object))
			{
				var typeProperties = currentHierarchyLevel.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (var property in typeProperties)
				{
					if (property.GetCustomAttribute<JsonIgnoreAttribute>() != null)
					{
						continue;
					}

					if (property.PropertyType == type)
					{
						continue;
					}

					properties.Add(property);
				}
				
				currentHierarchyLevel = currentHierarchyLevel.BaseType;
			}

			foreach (var property in properties)
			{
				foreach (var dependency in GetTransientDependencies(property.PropertyType))
				{
					yield return dependency;
				}
			}
		}
		private bool Equals(PersistedNode other)
		{
			return Key == other.Key;
		}
	}
}