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
				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians)
			};

			Hemp = new RawMaterial
			{
				Key = "Hemp",
				DisplayName = "Hemp",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens)
			};

			Brine = new RawMaterial
			{
				Key = "Brine",
				DisplayName = "Sole",
				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians)
			};

			IronOre = new RawMaterial
			{
				Key = "IronOre",
				DisplayName = "Eisenerz",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens)
			};

			Iron = new RawMaterial
			{
				Key = "Iron",
				DisplayName = "Eisen",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens)
			};

			Flour = new RawMaterial
			{
				Key = "Flour",
				DisplayName = "Mehl",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians)
			};

			Coal = new RawMaterial
			{
				Key = "Coal",
				DisplayName = "Kohle",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens)
			};

			Wheat = new RawMaterial
			{
				Key = "Wheat",
				DisplayName = "Weizen",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians)
			};

			Herbs = new RawMaterial
			{
				Key = "Herbs",
				DisplayName = "Kräuter",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians)
			};

			Potash = new RawMaterial
			{
				Key = "Potash",
				DisplayName = "Pottasche",
				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians)
			};

			Paper = new RawMaterial
			{
				Key = "Paper",
				DisplayName = "Papier",
				UnlockThreshold = new PopulationRequirement(940, PopulationGroups.Patricians)
			};

			Furs = new RawMaterial
			{
				Key = "Furs",
				DisplayName = "Pelze",
				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen)
			};

			Barrels = new RawMaterial
			{
				Key = "Barrels",
				DisplayName = "Fässer",
				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen)
			};

			CopperOre = new RawMaterial
			{
				Key = "CopperOre",
				DisplayName = "Kupfererz",
				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen)
			};

			Brass = new RawMaterial
			{
				Key = "Brass",
				DisplayName = "Messing",
				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen)
			};

			Grapes = new RawMaterial
			{
				Key = "Grapes",
				DisplayName = "Weintrauben",
				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen)
			};

			Cattle = new RawMaterial
			{
				Key = "Cattle",
				DisplayName = "Rinder",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen)
			};

			RoseOil = new RawMaterial
			{
				Key = "RoseOil",
				DisplayName = "Rosenöl",
				UnlockThreshold = new PopulationRequirement(2600, PopulationGroups.Envoys)
			};

			Beeswax = new RawMaterial
			{
				Key = "Beeswax",
				DisplayName = "Bienenwachs",
				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen)
			};

			Candles = new RawMaterial
			{
				Key = "Candles",
				DisplayName = "Kerzen",
				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen)
			};

			CoffeeBeans = new RawMaterial
			{
				Key = "CoffeeBeans",
				DisplayName = "Kaffeebohnen",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Envoys)
			};

			GoldOre = new RawMaterial
			{
				Key = "GoldOre",
				DisplayName = "Golderz",
				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen)
			};

			Indigo = new RawMaterial
			{
				Key = "Indigo",
				DisplayName = "Indigo",
				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads)
			};

			Gold = new RawMaterial
			{
				Key = "Gold",
				DisplayName = "Gold",
				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen)
			};

			Sugar = new RawMaterial
			{
				Key = "Sugar",
				DisplayName = "Zucker",
				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys)
			};

			SugarCane = new RawMaterial
			{
				Key = "SugarCane",
				DisplayName = "Zuckerrohr",
				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys)
			};

			Almonds = new RawMaterial
			{
				Key = "Almonds",
				DisplayName = "Mandeln",
				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys)
			};

			Clay = new RawMaterial
			{
				Key = "Clay",
				DisplayName = "Ton",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads)
			};

			Silk = new RawMaterial
			{
				Key = "Silk",
				DisplayName = "Seide",
				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads)
			};

			Pearls = new RawMaterial
			{
				Key = "Pearls",
				DisplayName = "Perlen",
				UnlockThreshold = new PopulationRequirement(1040, PopulationGroups.Envoys)
			};

			Quartz = new RawMaterial
			{
				Key = "Quartz",
				DisplayName = "Quarz",
				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads)
			};

			Ropes = new RawMaterial
			{
				Key = "Ropes",
				DisplayName = "Seile",
				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens)
			};

			AnimalHides = new RawMaterial
			{
				Key = "AnimalHides",
				DisplayName = "Tierhäute",
				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians)
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