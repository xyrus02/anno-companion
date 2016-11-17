﻿using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class ConstructionMaterials
	{
		public static readonly ConstructionMaterial Wood;
		public static readonly ConstructionMaterial Tools;
		public static readonly ConstructionMaterial Stone;
		public static readonly ConstructionMaterial Glass;
		public static readonly ConstructionMaterial Mosaic;

		static ConstructionMaterials()
		{
			Wood = new ConstructionMaterial
			{
				Key = "Wood",
				DisplayName = "Holz",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants)
			};

			Tools = new ConstructionMaterial
			{
				Key = "Tools",
				DisplayName = "Werkzeug",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens)
			};

			Stone = new ConstructionMaterial
			{
				Key = "Stone",
				DisplayName = "Steine",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens)
			};

			Glass = new ConstructionMaterial
			{
				Key = "Glass",
				DisplayName = "Glas",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians)
			};

			Mosaic = new ConstructionMaterial
			{
				Key = "Mosaic",
				DisplayName = "Mosaik",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads)
			};
		}

		[CanBeNull]
		public static ConstructionMaterial GetByKey(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}

			var field = typeof(ConstructionMaterials).GetField(key, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (ConstructionMaterial)field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<ConstructionMaterial> GetAll()
		{
			foreach (var field in typeof(ConstructionMaterials).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (ConstructionMaterial)field.GetValue(null);
			}
		}
	}
}