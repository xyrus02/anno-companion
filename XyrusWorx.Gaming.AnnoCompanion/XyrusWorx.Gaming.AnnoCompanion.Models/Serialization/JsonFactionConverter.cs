using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XyrusWorx.Gaming.AnnoCompanion.Models.Serialization
{
	class JsonFactionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Fraction);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var input = value as Fraction?;
			var token = new JValue(input?.ToString());

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return reader.Value?.ToString().TryDeserialize(objectType);
		}
	}
}