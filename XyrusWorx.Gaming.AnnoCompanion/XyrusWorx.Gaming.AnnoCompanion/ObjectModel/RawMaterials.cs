using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class RawMaterials
	{
		public static readonly RawMaterial Salt;
		public static readonly RawMaterial Hemp;
		public static readonly RawMaterial Brine;
		public static readonly RawMaterial IronOre;
		public static readonly RawMaterial Iron;
		public static readonly RawMaterial Flour;
		public static readonly RawMaterial Coal;
		public static readonly RawMaterial Wheat;
		public static readonly RawMaterial Herbs;
		public static readonly RawMaterial Potash;
		public static readonly RawMaterial Paper;
		public static readonly RawMaterial Furs;
		public static readonly RawMaterial Barrels;
		public static readonly RawMaterial CopperOre;
		public static readonly RawMaterial Brass;
		public static readonly RawMaterial Grapes;
		public static readonly RawMaterial Cattle;
		public static readonly RawMaterial RoseOil;
		public static readonly RawMaterial Beeswax;
		public static readonly RawMaterial Candles;
		public static readonly RawMaterial CoffeeBeans;
		public static readonly RawMaterial GoldOre;
		public static readonly RawMaterial Indigo;
		public static readonly RawMaterial Gold;
		public static readonly RawMaterial Sugar;
		public static readonly RawMaterial SugarCane;
		public static readonly RawMaterial Almonds;
		public static readonly RawMaterial Clay;
		public static readonly RawMaterial Silk;
		public static readonly RawMaterial Pearls;
		public static readonly RawMaterial Quartz;
		public static readonly RawMaterial Ropes;
		public static readonly RawMaterial AnimalHides;

		static RawMaterials()
		{
			Salt = new RawMaterial
			{
				Key = "Salt",
				DisplayName = "Salz",
				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				TradeValue = 9,
				ProductionCost = 13.75
			};

			Hemp = new RawMaterial
			{
				Key = "Hemp",
				DisplayName = "Hemp",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 24,
				ProductionCost = 20
			};

			Brine = new RawMaterial
			{
				Key = "Brine",
				DisplayName = "Sole",
				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				TradeValue = 6,
				ProductionCost = 5
			};

			IronOre = new RawMaterial
			{
				Key = "IronOre",
				DisplayName = "Eisenerz",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 12,
				ProductionCost = 10
			};

			Iron = new RawMaterial
			{
				Key = "Iron",
				DisplayName = "Eisen",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 33,
				ProductionCost = 25
			};

			Flour = new RawMaterial
			{
				Key = "Flour",
				DisplayName = "Mehl",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),

				TradeValue = 16,
				ProductionCost = 10
			};

			Coal = new RawMaterial
			{
				Key = "Coal",
				DisplayName = "Kohle",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 9,
				ProductionCost = 5
			};

			Wheat = new RawMaterial
			{
				Key = "Wheat",
				DisplayName = "Weizen",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),

				TradeValue = 3,
				ProductionCost = 2.5
			};

			Herbs = new RawMaterial
			{
				Key = "Herbs",
				DisplayName = "Kräuter",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				TradeValue = 6,
				ProductionCost = 5
			};

			Potash = new RawMaterial
			{
				Key = "Potash",
				DisplayName = "Pottasche",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				TradeValue = 20,
				ProductionCost = 15
			};

			Paper = new RawMaterial
			{
				Key = "Paper",
				DisplayName = "Papier",
				UnlockThreshold = new PopulationRequirement(940, PopulationGroups.Patricians),

				TradeValue = 24,
				ProductionCost = 20
			};

			Furs = new RawMaterial
			{
				Key = "Furs",
				DisplayName = "Pelze",
				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),

				TradeValue = 19,
				ProductionCost = 12
			};

			Barrels = new RawMaterial
			{
				Key = "Barrels",
				DisplayName = "Fässer",
				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),

				TradeValue = 38,
				ProductionCost = 29.17
			};

			CopperOre = new RawMaterial
			{
				Key = "CopperOre",
				DisplayName = "Kupfererz",
				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),

				TradeValue = 36,
				ProductionCost = 30
			};

			Brass = new RawMaterial
			{
				Key = "Brass",
				DisplayName = "Messing",
				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),

				TradeValue = 84,
				ProductionCost = 65
			};

			Grapes = new RawMaterial
			{
				Key = "Grapes",
				DisplayName = "Weintrauben",
				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),

				TradeValue = 45,
				ProductionCost = 37.5
			};

			Cattle = new RawMaterial
			{
				Key = "Cattle",
				DisplayName = "Rinder",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),

				TradeValue = 9,
				ProductionCost = 20
			};

			RoseOil = new RawMaterial
			{
				Key = "RoseOil",
				DisplayName = "Rosenöl",
				UnlockThreshold = new PopulationRequirement(2600, PopulationGroups.Envoys),

				TradeValue = 75,
				ProductionCost = 60
			};

			Beeswax = new RawMaterial
			{
				Key = "Beeswax",
				DisplayName = "Bienenwachs",
				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),

				TradeValue = 27,
				ProductionCost = 22.5
			};

			Candles = new RawMaterial
			{
				Key = "Candles",
				DisplayName = "Kerzen",
				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),

				TradeValue = 87,
				ProductionCost = 97.5
			};

			CoffeeBeans = new RawMaterial
			{
				Key = "CoffeeBeans",
				DisplayName = "Kaffeebohnen",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Envoys),

				TradeValue = 50,
				ProductionCost = 20
			};

			GoldOre = new RawMaterial
			{
				Key = "GoldOre",
				DisplayName = "Golderz",
				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),

				TradeValue = 40,
				ProductionCost = 37.5
			};

			Indigo = new RawMaterial
			{
				Key = "Indigo",
				DisplayName = "Indigo",
				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),

				TradeValue = 19,
				ProductionCost = 13.33
			};

			Gold = new RawMaterial
			{
				Key = "Gold",
				DisplayName = "Gold",
				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),

				TradeValue = 40,
				ProductionCost = 58.33
			};

			Sugar = new RawMaterial
			{
				Key = "Sugar",
				DisplayName = "Zucker",
				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				TradeValue = 26,
				ProductionCost = 27.5
			};

			SugarCane = new RawMaterial
			{
				Key = "SugarCane",
				DisplayName = "Zuckerrohr",
				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				TradeValue = 13,
				ProductionCost = 17.5
			};

			Almonds = new RawMaterial
			{
				Key = "Almonds",
				DisplayName = "Mandeln",
				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				TradeValue = 9,
				ProductionCost = 7.5
			};

			Clay = new RawMaterial
			{
				Key = "Clay",
				DisplayName = "Ton",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				TradeValue = 18,
				ProductionCost = 12.5
			};

			Silk = new RawMaterial
			{
				Key = "Silk",
				DisplayName = "Seide",
				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),

				TradeValue = 21,
				ProductionCost = 16.67
			};

			Pearls = new RawMaterial
			{
				Key = "Pearls",
				DisplayName = "Perlen",
				UnlockThreshold = new PopulationRequirement(1040, PopulationGroups.Envoys),

				TradeValue = 48,
				ProductionCost = 40
			};

			Quartz = new RawMaterial
			{
				Key = "Quartz",
				DisplayName = "Quarz",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				TradeValue = 18,
				ProductionCost = 15
			};

			Ropes = new RawMaterial
			{
				Key = "Ropes",
				DisplayName = "Seile",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				TradeValue = 39,
				ProductionCost = 30
			};

			AnimalHides = new RawMaterial
			{
				Key = "AnimalHides",
				DisplayName = "Tierhäute",
				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				TradeValue = 24,
				ProductionCost = 7.5
			};
		}

		[CanBeNull]
		public static RawMaterial GetByKey(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}

			var field = typeof(RawMaterials).GetField(key, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (RawMaterial)field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<RawMaterial> GetAll()
		{
			foreach (var field in typeof(RawMaterials).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (RawMaterial)field.GetValue(null);
			}
		}
	}
}