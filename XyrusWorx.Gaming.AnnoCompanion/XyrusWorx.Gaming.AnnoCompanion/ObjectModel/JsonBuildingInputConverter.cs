using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class JsonBuildingInputConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(BuildingInput);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var input = value as BuildingInput;
			var token = new JValue(input?.Good?.Key);

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var context = serializer.ReferenceResolver.CastTo<JsonReferenceResolver>();
			if (context != null)
			{
				var good = context.Resolve(existingValue?.ToString().NormalizeNull().TryTransform(x => new StringKey(x)) ?? new StringKey());
				return new BuildingInput(good as Good);
			}

			return existingValue;
		}
	}
}