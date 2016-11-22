using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Serialization
{
	class JsonFactionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Faction);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var input = value as Faction?;
			var token = new JValue(input?.ToString());

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return existingValue?.ToString().TryDeserialize(objectType);
		}
	}
}