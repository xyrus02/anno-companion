using System;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{Key}")]
	abstract class IndexedObject
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

			jsonSerializer.Serialize(target, this);
		}

		public static T Deserialize<T>(StringKey key, [NotNull] TextReader source, [NotNull] JsonReferenceResolver context) where T: IndexedObject
		{
			if (key.IsEmpty)
			{
				throw new ArgumentNullException(nameof(key));
			}

			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			var jsonSerializer = GetSerializer(typeof(T));

			jsonSerializer.ReferenceResolver = context;

			var obj = jsonSerializer.Deserialize<T>(new JsonTextReader(source));

			obj.Key = key.RawData;

			return obj;
		}

		private static JsonSerializer GetSerializer(Type rootType)
		{
			var jsonSerializer = new JsonSerializer();

			jsonSerializer.Converters.Add(new JsonIndexedObjectConverter(rootType));
			jsonSerializer.Converters.Add(new JsonBuildingInputConverter());
			jsonSerializer.Converters.Add(new JsonBuildingOutputConverter());
			jsonSerializer.Converters.Add(new JsonBuildingRestrictionsConverter());
			jsonSerializer.Converters.Add(new JsonFactionConverter());
			jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
			jsonSerializer.ReferenceResolver = new JsonReferenceResolver();
			jsonSerializer.Formatting = Formatting.Indented;

			return jsonSerializer;
		}
	}
}