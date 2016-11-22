using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
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
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants),

				TradeValue = 4,
				ProductionCost = 3.33
			};

			Tools = new ConstructionMaterial
			{
				Key = "Tools",
				DisplayName = "Werkzeug",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 36,
				ProductionCost = 27.5
			};

			Stone = new ConstructionMaterial
			{
				Key = "Stone",
				DisplayName = "Steine",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),

				TradeValue = 8,
				ProductionCost = 10
			};

			Glass = new ConstructionMaterial
			{
				Key = "Glass",
				DisplayName = "Glas",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				TradeValue = 68,
				ProductionCost = 26.25
			};

			Mosaic = new ConstructionMaterial
			{
				Key = "Mosaic",
				DisplayName = "Mosaik",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				TradeValue = 46,
				ProductionCost = 32.5
			};
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