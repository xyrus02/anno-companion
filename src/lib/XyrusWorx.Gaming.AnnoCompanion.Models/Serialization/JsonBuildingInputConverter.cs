﻿using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models.Serialization
{
	[UsedImplicitly]
	class JsonBuildingInputConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(BuildingInput);

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var input = value as BuildingInput;
			var token = new JValue(input?.Input?.Key);

			token.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var context = serializer.ReferenceResolver.CastTo<IInstancePool>();
			if (context != null)
			{
				var depletable = context.Resolve(reader.Value?.ToString().NormalizeNull().TryTransform(x => new StringKey(x)) ?? new StringKey());
				return new BuildingInput(depletable as Depletable);
			}

			return existingValue;
		}
	}
}