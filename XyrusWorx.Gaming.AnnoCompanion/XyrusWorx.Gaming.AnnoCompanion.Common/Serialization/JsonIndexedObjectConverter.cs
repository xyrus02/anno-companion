using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Serialization
{
	class JsonIndexedObjectConverter : JsonConverter
	{
		private readonly Type mRootType;

		public JsonIndexedObjectConverter(Type rootType)
		{
			mRootType = rootType;
		}

		public override bool CanConvert(Type objectType) => objectType.IsSubclassOf(typeof(Persistable)) && mRootType != objectType;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var io = value as Persistable;
			var token = new JValue(io?.Key);

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var context = serializer.ReferenceResolver.CastTo<JsonReferenceResolver>();
			if (context != null)
			{
				return context.Resolve(reader.Value?.ToString().NormalizeNull().TryTransform(x => new StringKey(x)) ?? new StringKey());
			}

			return existingValue;
		}
	}
}