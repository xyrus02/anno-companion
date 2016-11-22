using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Serialization
{
	class JsonBuildingOutputConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(BuildingOutput);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var output = value as BuildingOutput;
			var token = new JValue(output?.Good?.Key);

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var context = serializer.ReferenceResolver.CastTo<JsonReferenceResolver>();
			if (context != null)
			{
				var good = context.Resolve(reader.Value?.ToString().NormalizeNull().TryTransform(x => new StringKey(x)) ?? new StringKey());
				return new BuildingOutput(good as Good);
			}

			return existingValue;
		}
	}
}