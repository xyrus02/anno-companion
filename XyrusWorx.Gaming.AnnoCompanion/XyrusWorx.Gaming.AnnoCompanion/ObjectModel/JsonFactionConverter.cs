﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class JsonFactionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Factions);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var input = value as Factions?;
			var token = new JValue(input?.ToString());

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return existingValue?.ToString().TryDeserialize(objectType);
		}
	}
}