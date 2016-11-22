using System;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XyrusWorx.Gaming.AnnoCompanion.Serialization;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[DebuggerDisplay("{Key}")]
	abstract class Persistable : Model
	{
		[JsonIgnore]
		public string Key { get; set; }

		public void Serialize([NotNull] TextWriter target)
		{
			if (target == null)
			{
				throw new ArgumentNullException(nameof(target));
			}

			var jsonSerializer = GetSerializer(GetType());

			jsonSerializer.ReferenceResolver = new JsonReferenceResolver();
			jsonSerializer.Serialize(target, this);
		}

		internal static T Deserialize<T>(StringKey key, [NotNull] TextReader source, [NotNull] IInstancePool references) where T: Persistable
		{
			return (T) Deserialize(key, typeof(T), source, references);
		}
		internal static Persistable Deserialize(StringKey key, [NotNull] Type type, [NotNull] TextReader source, [NotNull] IInstancePool references)
		{
			if (key.IsEmpty)
			{
				throw new ArgumentNullException(nameof(key));
			}

			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (references == null)
			{
				throw new ArgumentNullException(nameof(references));
			}

			if (!type.IsSubclassOf(typeof(Persistable)))
			{
				throw new ArgumentOutOfRangeException(nameof(type));
			}

			var jsonSerializer = GetSerializer(type);

			jsonSerializer.ReferenceResolver = references as IReferenceResolver;

			var obj = (Persistable)jsonSerializer.Deserialize(new JsonTextReader(source), type);

			obj.Key = key.RawData;

			return obj;
		}

		private static JsonSerializer GetSerializer(Type rootType)
		{
			var jsonSerializer = new JsonSerializer();

			jsonSerializer.Converters.Add(new JsonIndexedObjectConverter(rootType));
			jsonSerializer.Converters.Add(new JsonBuildingInputConverter());
			jsonSerializer.Converters.Add(new JsonBuildingRestrictionsConverter());
			jsonSerializer.Converters.Add(new JsonFactionConverter());
			jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
			jsonSerializer.Formatting = Formatting.Indented;

			return jsonSerializer;
		}
	}
}