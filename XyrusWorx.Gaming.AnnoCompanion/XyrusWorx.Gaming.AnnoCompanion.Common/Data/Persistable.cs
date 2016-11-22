using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Serialization;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[DebuggerDisplay("{Key}"), PublicAPI]
	public abstract class Persistable : Model
	{
		[JsonIgnore]
		public string Key { get; set; }

		public void Serialize([NotNull] TextWriter target, [NotNull] IEnumerable<JsonConverter> converters)
		{
			if (target == null)
			{
				throw new ArgumentNullException(nameof(target));
			}

			if (converters == null)
			{
				throw new ArgumentNullException(nameof(converters));
			}

			var jsonSerializer = GetSerializer(GetType());

			jsonSerializer.ReferenceResolver = new JsonReferenceResolver();
			jsonSerializer.Converters.AddRange(converters);
			jsonSerializer.Serialize(target, this);
		}

		internal static T Deserialize<T>(StringKey key, [NotNull] TextReader source, [NotNull] IInstancePool references, [NotNull] IEnumerable<JsonConverter> converters) where T: Persistable
		{
			return (T) Deserialize(key, typeof(T), source, references, converters);
		}
		internal static Persistable Deserialize(StringKey key, [NotNull] Type type, [NotNull] TextReader source, [NotNull] IInstancePool references, [NotNull] IEnumerable<JsonConverter> converters)
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

			if (converters == null)
			{
				throw new ArgumentNullException(nameof(converters));
			}

			if (!type.IsSubclassOf(typeof(Persistable)))
			{
				throw new ArgumentOutOfRangeException(nameof(type));
			}

			var jsonSerializer = GetSerializer(type);

			jsonSerializer.ReferenceResolver = references as IReferenceResolver;
			jsonSerializer.Converters.AddRange(converters);

			var obj = (Persistable)jsonSerializer.Deserialize(new JsonTextReader(source), type);

			obj.Key = key.RawData;

			return obj;
		}

		private static JsonSerializer GetSerializer(Type rootType)
		{
			var jsonSerializer = new JsonSerializer();

			jsonSerializer.Converters.Add(new JsonIndexedObjectConverter(rootType));
			jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
			jsonSerializer.Formatting = Formatting.Indented;

			return jsonSerializer;
		}
	}
}