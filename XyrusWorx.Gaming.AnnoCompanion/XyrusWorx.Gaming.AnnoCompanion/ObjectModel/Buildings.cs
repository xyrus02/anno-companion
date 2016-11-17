using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class Buildings
	{
		public static readonly Building FishermansHut;
		public static readonly Building SpiceFarm;
		public static readonly Building Bakery;
		public static readonly Building ButchersShop;
		public static readonly Building CiderFarm;
		public static readonly Building MonasteryBrewery;
		public static readonly Building WinePress;
		public static readonly Building WeaversHut;
		public static readonly Building Tannery;
		public static readonly Building FurriersWorkshop;
		public static readonly Building SilkWeavingMill;
		public static readonly Building PrintingHouse;
		public static readonly Building RedsmithsWorkshop;
		public static readonly Building OpticiansWorkshop;
		public static readonly Building DatePlantation;
		public static readonly Building GoatFarm;
		public static readonly Building CarpetWorkshop;
		public static readonly Building RoastingHouse;
		public static readonly Building PearlWorkshop;
		public static readonly Building Perfumery;
		public static readonly Building ConfectionersWorkshop;

		public static readonly Building Mill;
		public static readonly Building CropFarm;
		public static readonly Building CattleFarm;
		public static readonly Building MonasteryGarden;
		public static readonly Building Vineyard;
		public static readonly Building BarrelCooperage;
		public static readonly Building HempPlantation;
		public static readonly Building PigFarm;
		public static readonly Building TrappersLodge;
		public static readonly Building SilkPlantation;
		public static readonly Building IndigoFarm;
		public static readonly Building PaperMill;
		public static readonly Building SaltWorks;
		public static readonly Building CandlemakersWorkshop;
		public static readonly Building Apiary;
		public static readonly Building CoffeePlantation;
		public static readonly Building RoseNursery;
		public static readonly Building SugarCanePlantation;
		public static readonly Building SugarMill;
		public static readonly Building AlmondPlantation;
		public static readonly Building ClayPit;
		public static readonly Building MosaicWorkshop;
		public static readonly Building ToolmakersWorkshop;
		public static readonly Building Ropeyard;

		public static readonly Building GlassSmelter;
		public static readonly Building IronSmelter;
		public static readonly Building GoldSmelter;
		public static readonly Building CopperSmelter;

		public static readonly Building SaltMine;
		public static readonly Building OreMine;
		public static readonly Building GoldMine;
		public static readonly Building CopperMine;
		public static readonly Building QuartzQuarry;

		public static readonly Building LumberjacksHut;
		public static readonly Building StonemasonsHut;
		public static readonly Building CharcoalBurnersHut;
		public static readonly Building PearlFishersHut;
		public static readonly Building ForestGlassworks;

		public static readonly Building CannonFoundry;
		public static readonly Building ProvisionHouse;
		public static readonly Building WarMachinesWorkshop;
		public static readonly Building WeaponSmithy;

		static Buildings()
		{
			FishermansHut = new Building
			{
				Key = "FishermansHut",
				DisplayName = "Fischerhütte",
				Location = BuildingLocation.Coast,

				Input = new Good[0],
				Output = ConsumableGoods.Fishes
			};

			SpiceFarm = new Building
			{
				Key = "SpiceFarm",
				DisplayName = "Gewürzplantage",

				Input = new Good[0],
				Output = ConsumableGoods.Fishes
			};

			Bakery = new Building
			{
				Key = "Bakery",
				DisplayName = "Backhaus",

				Input = new Good[]
				{
					RawMaterials.Flour
				},
				Output = ConsumableGoods.Bread
			};

			ButchersShop = new Building
			{
				Key = "ButchersShop",
				DisplayName = "Schlachterei",

				Input = new Good[]
				{
					RawMaterials.Cattle
				},
				Output = ConsumableGoods.Meat
			};

			CiderFarm = new Building
			{
				Key = "CiderFarm",
				DisplayName = "Mosthof",

				Input = new Good[0],
				Output = ConsumableGoods.Cider
			};

			MonasteryBrewery = new Building
			{
				Key = "MonasteryBrewery",
				DisplayName = "Klosterbrauerei",

				Input = new Good[0],
				Output = RawMaterials.Herbs
			};

			WinePress = new Building
			{
				Key = "WinePress",
				DisplayName = "Kelterhaus",

				Input = new Good[]
				{
					RawMaterials.Barrels,
					RawMaterials.Grapes
				},
				Output = ConsumableGoods.Wine
			};

			WeaversHut = new Building
			{
				Key = "WeaversHut",
				DisplayName = "Weberhütte",

				Input = new Good[]
				{
					RawMaterials.Hemp
				},
				Output = ConsumableGoods.LinenGarments
			};

			Tannery = new Building
			{
				Key = "Tannery",
				DisplayName = "Gerberei",
				Location = BuildingLocation.River,

				Input = new Good[]
				{
					RawMaterials.Salt,
					RawMaterials.AnimalHides
				},
				Output = ConsumableGoods.LeatherJerkins
			};

			FurriersWorkshop = new Building
			{
				Key = "FurriersWorkshop",
				DisplayName = "Kürschnerei",
				Location = BuildingLocation.River,

				Input = new Good[]
				{
					RawMaterials.Furs,
					RawMaterials.Salt
				},
				Output = ConsumableGoods.FurCoats
			};

			SilkWeavingMill = new Building
			{
				Key = "SilkWeavingMill",
				DisplayName = "Seidenweberei",

				Input = new Good[]
				{
					RawMaterials.Silk,
					RawMaterials.Gold
				},
				Output = ConsumableGoods.BrocadeCoats
			};

			PrintingHouse = new Building
			{
				Key = "PrintingHouse",
				DisplayName = "Druckerei",

				Input = new Good[]
				{
					RawMaterials.Paper
				},
				Output = ConsumableGoods.Books
			};

			RedsmithsWorkshop = new Building
			{
				Key = "RedsmithsWorkshop",
				DisplayName = "Feinschmiede",

				Input = new Good[]
				{
					RawMaterials.Brass,
					RawMaterials.Candles
				},
				Output = ConsumableGoods.Candlesticks
			};

			OpticiansWorkshop = new Building
			{
				Key = "OpticiansWorkshop",
				DisplayName = "Brillenmacherei",

				Input = new Good[]
				{
					RawMaterials.Quartz,
					RawMaterials.Brass
				},
				Output = ConsumableGoods.Cider
			};

			DatePlantation = new Building
			{
				Key = "DatePlantation",
				DisplayName = "Dattelplantage",

				Input = new Good[0],
				Output = ConsumableGoods.Dates
			};

			GoatFarm = new Building
			{
				Key = "GoatFarm",
				DisplayName = "Ziegenfarm",

				Input = new Good[0],
				Output = ConsumableGoods.Milk
			};

			CarpetWorkshop = new Building
			{
				Key = "CarpetWorkshop",
				DisplayName = "Teppichknüpferei",

				Input = new Good[]
				{
					RawMaterials.Indigo,
					RawMaterials.Silk
				},
				Output = ConsumableGoods.Carpets
			};

			RoastingHouse = new Building
			{
				Key = "RoastingHouse",
				DisplayName = "Rösterei",

				Input = new Good[]
				{
					RawMaterials.CoffeeBeans
				},
				Output = ConsumableGoods.Coffee
			};

			PearlWorkshop = new Building
			{
				Key = "PearlWorkshop",
				DisplayName = "Perlenknüpfer",

				Input = new Good[]
				{
					RawMaterials.Pearls
				},
				Output = ConsumableGoods.PearlNecklaces
			};

			Perfumery = new Building
			{
				Key = "Perfumery",
				DisplayName = "Duftmischer",

				Input = new Good[]
				{
					RawMaterials.RoseOil
				},
				Output = ConsumableGoods.Perfume
			};

			ConfectionersWorkshop = new Building
			{
				Key = "ConfectionersWorkshop",
				DisplayName = "Zuckerbäckerei",

				Input = new Good[]
				{
					RawMaterials.Sugar,
					RawMaterials.Almonds
				},
				Output = ConsumableGoods.Marzipan
			};

			Mill = new Building
			{
				Key = "Mill",
				DisplayName = "Mühle",

				Input = new Good[]
				{
					RawMaterials.Wheat
				},
				Output = RawMaterials.Flour
			};

			CropFarm = new Building
			{
				Key = "CropFarm",
				DisplayName = "Weizenfarm",

				Input = new Good[0],
				Output = RawMaterials.Wheat
			};

			CattleFarm = new Building
			{
				Key = "CattleFarm",
				DisplayName = "Rindefarm",

				Input = new Good[0],
				Output = RawMaterials.Cattle
			};

			MonasteryGarden = new Building
			{
				Key = "MonasteryGarden",
				DisplayName = "Klostergarten",

				Input = new Good[0],
				Output = RawMaterials.Herbs
			};

			Vineyard = new Building
			{
				Key = "Vineyard",
				DisplayName = "Weingut",

				Input = new Good[0],
				Output = RawMaterials.Grapes
			};

			BarrelCooperage = new Building
			{
				Key = "BarrelCooperage",
				DisplayName = "Fassküferei",

				Input = new Good[]
				{
					RawMaterials.Iron,
					ConstructionMaterials.Wood
				},
				Output = RawMaterials.Wheat
			};

			HempPlantation = new Building
			{
				Key = "HempPlantation",
				DisplayName = "Hanfplantage",

				Input = new Good[0],
				Output = RawMaterials.Hemp
			};

			PigFarm = new Building
			{
				Key = "PigFarm",
				DisplayName = "Schweinezucht",

				Input = new Good[0],
				Output = RawMaterials.AnimalHides
			};

			TrappersLodge = new Building
			{
				Key = "TrappersLodge",
				DisplayName = "Pelztierjagdhütte",
				Location = BuildingLocation.Mountain,

				Input = new Good[0],
				Output = RawMaterials.Furs
			};

			SilkPlantation = new Building
			{
				Key = "SilkPlantation",
				DisplayName = "Seidenplantage",

				Input = new Good[0],
				Output = RawMaterials.Silk
			};

			IndigoFarm = new Building
			{
				Key = "IndigoFarm",
				DisplayName = "Indigoplantage",

				Input = new Good[0],
				Output = RawMaterials.Indigo
			};

			PaperMill = new Building
			{
				Key = "PaperMill",
				DisplayName = "Papiermühle",
				Location = BuildingLocation.River,

				Input = new Good[]
				{
					ConstructionMaterials.Wood
				},
				Output = RawMaterials.Paper
			};

			SaltWorks = new Building
			{
				Key = "SaltWorks",
				DisplayName = "Saline",

				Input = new Good[]
				{
					RawMaterials.Brine
				},
				Output = RawMaterials.Salt
			};

			CandlemakersWorkshop = new Building
			{
				Key = "CandlemakersWorkshop",
				DisplayName = "Lichtzieherei",

				Input = new Good[]
				{
					RawMaterials.Beeswax,
					RawMaterials.Hemp
				},
				Output = RawMaterials.Candles
			};

			Apiary = new Building
			{
				Key = "Apiary",
				DisplayName = "Imkerei",

				Input = new Good[0],
				Output = RawMaterials.Beeswax
			};

			CoffeePlantation = new Building
			{
				Key = "CoffeePlantation",
				DisplayName = "Kaffeeplantage",

				Input = new Good[0],
				Output = RawMaterials.CoffeeBeans
			};

			RoseNursery = new Building
			{
				Key = "RoseNursery",
				DisplayName = "Rosenplantage",

				Input = new Good[0],
				Output = RawMaterials.RoseOil
			};

			SugarCanePlantation = new Building
			{
				Key = "SugarCanePlantation",
				DisplayName = "Zuckerrohrplantage",

				Input = new Good[0],
				Output = RawMaterials.SugarCane
			};

			SugarMill = new Building
			{
				Key = "SugarMill",
				DisplayName = "Zuckermühle",

				Input = new Good[]
				{
					RawMaterials.SugarCane
				},
				Output = RawMaterials.Wheat
			};

			AlmondPlantation = new Building
			{
				Key = "AlmondPlantation",
				DisplayName = "Mandelfarm",

				Input = new Good[0],
				Output = RawMaterials.Almonds
			};

			ClayPit = new Building
			{
				Key = "ClayPit",
				DisplayName = "Tongrube",

				Input = new Good[0],
				Output = RawMaterials.Clay
			};

			MosaicWorkshop = new Building
			{
				Key = "MosaicWorkshop",
				DisplayName = "Mosaikmacherei",

				Input = new Good[]
				{
					RawMaterials.Quartz,
					RawMaterials.Clay
				},
				Output = ConstructionMaterials.Mosaic
			};

			ToolmakersWorkshop = new Building
			{
				Key = "ToolmakersWorkshop",
				DisplayName = "Werkzeugschmiede",

				Input = new Good[]
				{
					RawMaterials.Iron
				},
				Output = ConstructionMaterials.Tools
			};

			Ropeyard = new Building
			{
				Key = "Ropeyard",
				DisplayName = "Seilerei",

				Input = new Good[]
				{
					RawMaterials.Hemp
				},
				Output = RawMaterials.Ropes
			};

			GlassSmelter = new Building
			{
				Key = "GlassSmelter",
				DisplayName = "Glasmacher",

				Input = new Good[]
				{
					RawMaterials.Quartz,
					RawMaterials.Potash
				},
				Output = ConstructionMaterials.Glass
			};

			IronSmelter = new Building
			{
				Key = "IronSmelter",
				DisplayName = "Eisenschmelze",

				Input = new Good[]
				{
					RawMaterials.IronOre,
					RawMaterials.Coal
				},
				Output = RawMaterials.Iron
			};

			GoldSmelter = new Building
			{
				Key = "GoldSmelter",
				DisplayName = "Goldschmelze",

				Input = new Good[]
				{
					RawMaterials.GoldOre,
					RawMaterials.Coal
				},
				Output = RawMaterials.Gold
			};

			CopperSmelter = new Building
			{
				Key = "CopperSmelter",
				DisplayName = "Kupferschmelze",

				Input = new Good[]
				{
					RawMaterials.CopperOre,
					RawMaterials.Coal
				},
				Output = RawMaterials.Brass
			};

			SaltMine = new Building
			{
				Key = "SaltMine",
				DisplayName = "Salzmine",
				Location = BuildingLocation.Mountain,

				Input = new Good[0],
				Output = RawMaterials.Brine
			};

			OreMine = new Building
			{
				Key = "OreMine",
				DisplayName = "Eisenerzmine",
				Location = BuildingLocation.Mountain,

				Input = new Good[0],
				Output = RawMaterials.IronOre
			};

			GoldMine = new Building
			{
				Key = "GoldMine",
				DisplayName = "Goldmine",
				Location = BuildingLocation.Mountain,

				Input = new Good[0],
				Output = RawMaterials.GoldOre
			};

			CopperMine = new Building
			{
				Key = "CopperMine",
				DisplayName = "Kupfermine",
				Location = BuildingLocation.Mountain,

				Input = new Good[0],
				Output = RawMaterials.CopperOre
			};

			QuartzQuarry = new Building
			{
				Key = "QuartzQuarry",
				DisplayName = "Quarzbruch",

				Input = new Good[0],
				Output = RawMaterials.Quartz
			};

			LumberjacksHut = new Building
			{
				Key = "LumberjacksHut",
				DisplayName = "Holzfällerhütte",

				Input = new Good[0],
				Output = ConstructionMaterials.Wood
			};

			StonemasonsHut = new Building
			{
				Key = "StonemasonsHut",
				DisplayName = "Steinmetz",

				Input = new Good[0],
				Output = ConstructionMaterials.Stone
			};

			CharcoalBurnersHut = new Building
			{
				Key = "CharcoalBurnersHut",
				DisplayName = "Köhlerhütte",

				Input = new Good[0],
				Output = RawMaterials.Coal
			};

			PearlFishersHut = new Building
			{
				Key = "PearlFishersHut",
				DisplayName = "Perlentaucher",
				Location = BuildingLocation.Coast,

				Input = new Good[0],
				Output = RawMaterials.Pearls
			};

			ForestGlassworks = new Building
			{
				Key = "ForestGlassworks",
				DisplayName = "Waldglashütte",

				Input = new Good[0],
				Output = RawMaterials.Potash
			};

			CannonFoundry = new Building
			{
				Key = "CannonFoundry",
				DisplayName = "Kanonenschmiede",

				Input = new Good[]
				{
					ConstructionMaterials.Wood,
					RawMaterials.Iron
				},
				Output = WarfareMaterials.Cannons
			};

			ProvisionHouse = new Building
			{
				Key = "ProvisionHouse",
				DisplayName = "Proviantmagazin",

				Input = new Good[0],
				Output = WarfareMaterials.Provisions
			};

			WarMachinesWorkshop = new Building
			{
				Key = "WarMachinesWorkshop",
				DisplayName = "Kriegsmaschinenwerkstatt",

				Input = new Good[]
				{
					ConstructionMaterials.Wood,
					RawMaterials.Ropes
				},
				Output = WarfareMaterials.WarMachines
			};

			WeaponSmithy = new Building
			{
				Key = "WeaponSmithy",
				DisplayName = "Waffenschmiede",

				Input = new Good[]
				{
					RawMaterials.Iron
				},
				Output = WarfareMaterials.Weapons
			};
		}

		[CanBeNull]
		public static Building GetByKey(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}

			var field = typeof(Buildings).GetField(key, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (Building)field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<Building> GetAll()
		{
			foreach (var field in typeof(Buildings).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (Building)field.GetValue(null);
			}
		}
	}
}