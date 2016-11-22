using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
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
				Restrictions = BuildingRestrictions.Coast,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConsumableGoods.Fishes),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5,

				ProductionPerMinute = 2
			};

			SpiceFarm = new Building
			{
				Key = "SpiceFarm",
				DisplayName = "Gewürzplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConsumableGoods.Spices),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};

			Bakery = new Building
			{
				Key = "Bakery",
				DisplayName = "Backhaus",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Flour)

				},
				Output = new BuildingOutput(ConsumableGoods.Bread),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 4
			};

			ButchersShop = new Building
			{
				Key = "ButchersShop",
				DisplayName = "Schlachterei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Cattle),
					new BuildingInput(RawMaterials.Salt)

				},
				Output = new BuildingOutput(ConsumableGoods.Meat),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 2.5
			};

			CiderFarm = new Building
			{
				Key = "CiderFarm",
				DisplayName = "Mosthof",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConsumableGoods.Cider),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5,

				ProductionPerMinute = 1.5
			};

			MonasteryBrewery = new Building
			{
				Key = "MonasteryBrewery",
				DisplayName = "Klosterbrauerei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Herbs),
					new BuildingInput(RawMaterials.Wheat)

				},
				Output = new BuildingOutput(ConsumableGoods.Beer),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 1.5
			};

			WinePress = new Building
			{
				Key = "WinePress",
				DisplayName = "Kelterhaus",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Barrels),
					new BuildingInput(RawMaterials.Grapes)

				},
				Output = new BuildingOutput(ConsumableGoods.Wine),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 2
			};

			WeaversHut = new Building
			{
				Key = "WeaversHut",
				DisplayName = "Weberhütte",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Hemp)

				},
				Output = new BuildingOutput(ConsumableGoods.LinenGarments),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 2
			};

			Tannery = new Building
			{
				Key = "Tannery",
				DisplayName = "Gerberei",
				Restrictions = BuildingRestrictions.River,

				Input = new[]
				{
					new BuildingInput(RawMaterials.Salt),
					new BuildingInput(RawMaterials.AnimalHides)

				},
				Output = new BuildingOutput(ConsumableGoods.LeatherJerkins),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 4
			};

			FurriersWorkshop = new Building
			{
				Key = "FurriersWorkshop",
				DisplayName = "Kürschnerei",
				Restrictions = BuildingRestrictions.River,

				Input = new[]
				{
					new BuildingInput(RawMaterials.Furs),
					new BuildingInput(RawMaterials.Salt)

				},
				Output = new BuildingOutput(ConsumableGoods.FurCoats),

				ActiveCostPerMinute = 90,
				InactiveCostPerMinute = 45,

				ProductionPerMinute = 2.5
			};

			SilkWeavingMill = new Building
			{
				Key = "SilkWeavingMill",
				DisplayName = "Seidenweberei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Silk),
					new BuildingInput(RawMaterials.Gold)

				},
				Output = new BuildingOutput(ConsumableGoods.BrocadeCoats),

				ActiveCostPerMinute = 80,
				InactiveCostPerMinute = 40,

				ProductionPerMinute = 3
			};

			PrintingHouse = new Building
			{
				Key = "PrintingHouse",
				DisplayName = "Druckerei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Paper)

				},
				Output = new BuildingOutput(ConsumableGoods.Books),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 3
			};

			RedsmithsWorkshop = new Building
			{
				Key = "RedsmithsWorkshop",
				DisplayName = "Feinschmiede",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Brass),
					new BuildingInput(RawMaterials.Candles)

				},
				Output = new BuildingOutput(ConsumableGoods.Candlesticks),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30,

				ProductionPerMinute = 2
			};

			OpticiansWorkshop = new Building
			{
				Key = "OpticiansWorkshop",
				DisplayName = "Brillenmacherei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Quartz),
					new BuildingInput(RawMaterials.Brass)

				},
				Output = new BuildingOutput(ConsumableGoods.Glasses),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20,

				ProductionPerMinute = 2
			};

			DatePlantation = new Building
			{
				Key = "DatePlantation",
				DisplayName = "Dattelplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConsumableGoods.Dates),

				ActiveCostPerMinute = 45,
				InactiveCostPerMinute = 20,

				ProductionPerMinute = 3
			};

			GoatFarm = new Building
			{
				Key = "GoatFarm",
				DisplayName = "Ziegenfarm",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConsumableGoods.Milk),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1.5
			};

			CarpetWorkshop = new Building
			{
				Key = "CarpetWorkshop",
				DisplayName = "Teppichknüpferei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Indigo),
					new BuildingInput(RawMaterials.Silk)

				},
				Output = new BuildingOutput(ConsumableGoods.Carpets),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30,

				ProductionPerMinute = 1.5
			};

			RoastingHouse = new Building
			{
				Key = "RoastingHouse",
				DisplayName = "Rösterei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.CoffeeBeans)

				},
				Output = new BuildingOutput(ConsumableGoods.Coffee),

				ActiveCostPerMinute = 45,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 1
			};

			PearlWorkshop = new Building
			{
				Key = "PearlWorkshop",
				DisplayName = "Perlenknüpfer",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Pearls)

				},
				Output = new BuildingOutput(ConsumableGoods.PearlNecklaces),

				ActiveCostPerMinute = 70,
				InactiveCostPerMinute = 35,

				ProductionPerMinute = 1
			};

			Perfumery = new Building
			{
				Key = "Perfumery",
				DisplayName = "Duftmischer",

				Input = new[]
				{
					new BuildingInput(RawMaterials.RoseOil)

				},
				Output = new BuildingOutput(ConsumableGoods.Perfume),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30,

				ProductionPerMinute = 1
			};

			ConfectionersWorkshop = new Building
			{
				Key = "ConfectionersWorkshop",
				DisplayName = "Zuckerbäckerei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Sugar),
					new BuildingInput(RawMaterials.Almonds)

				},
				Output = new BuildingOutput(ConsumableGoods.Marzipan),

				ActiveCostPerMinute = 100,
				InactiveCostPerMinute = 50,

				ProductionPerMinute = 4
			};

			Mill = new Building
			{
				Key = "Mill",
				DisplayName = "Mühle",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Wheat)

				},
				Output = new BuildingOutput(RawMaterials.Flour),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 4
			};

			CropFarm = new Building
			{
				Key = "CropFarm",
				DisplayName = "Weizenfarm",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Wheat),

				ActiveCostPerMinute = 5,
				InactiveCostPerMinute = 0,

				ProductionPerMinute = 2
			};

			CattleFarm = new Building
			{
				Key = "CattleFarm",
				DisplayName = "Rindefarm",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Cattle),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1.25
			};

			MonasteryGarden = new Building
			{
				Key = "MonasteryGarden",
				DisplayName = "Klostergarten",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Herbs),

				ActiveCostPerMinute = 10,
				InactiveCostPerMinute = 0,

				ProductionPerMinute = 2
			};

			Vineyard = new Building
			{
				Key = "Vineyard",
				DisplayName = "Weingut",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Grapes),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 0.66
			};

			BarrelCooperage = new Building
			{
				Key = "BarrelCooperage",
				DisplayName = "Fassküferei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Iron),
					new BuildingInput(ConstructionMaterials.Wood)

				},
				Output = new BuildingOutput(RawMaterials.Wheat),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};

			HempPlantation = new Building
			{
				Key = "HempPlantation",
				DisplayName = "Hanfplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Hemp),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1
			};

			PigFarm = new Building
			{
				Key = "PigFarm",
				DisplayName = "Schweinezucht",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.AnimalHides),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 2
			};

			TrappersLodge = new Building
			{
				Key = "TrappersLodge",
				DisplayName = "Pelztierjagdhütte",
				Restrictions = BuildingRestrictions.Mountain,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Furs),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2.50
			};

			SilkPlantation = new Building
			{
				Key = "SilkPlantation",
				DisplayName = "Seidenplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Silk),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1.5
			};

			IndigoFarm = new Building
			{
				Key = "IndigoFarm",
				DisplayName = "Indigoplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Indigo),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1.5
			};

			PaperMill = new Building
			{
				Key = "PaperMill",
				DisplayName = "Papiermühle",
				Restrictions = BuildingRestrictions.River,

				Input = new[]
				{
					new BuildingInput(ConstructionMaterials.Wood)

				},
				Output = new BuildingOutput(RawMaterials.Paper),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 3
			};

			SaltWorks = new Building
			{
				Key = "SaltWorks",
				DisplayName = "Saline",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Brine)

				},
				Output = new BuildingOutput(RawMaterials.Salt),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 12,

				ProductionPerMinute = 4
			};

			CandlemakersWorkshop = new Building
			{
				Key = "CandlemakersWorkshop",
				DisplayName = "Lichtzieherei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Beeswax),
					new BuildingInput(RawMaterials.Hemp)

				},
				Output = new BuildingOutput(RawMaterials.Candles),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20,

				ProductionPerMinute = 1.33
			};

			Apiary = new Building
			{
				Key = "Apiary",
				DisplayName = "Imkerei",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Beeswax),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 0.67
			};

			CoffeePlantation = new Building
			{
				Key = "CoffeePlantation",
				DisplayName = "Kaffeeplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.CoffeeBeans),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1
			};

			RoseNursery = new Building
			{
				Key = "RoseNursery",
				DisplayName = "Rosenplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.RoseOil),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 0.5
			};

			SugarCanePlantation = new Building
			{
				Key = "SugarCanePlantation",
				DisplayName = "Zuckerrohrplantage",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.SugarCane),

				ActiveCostPerMinute = 35,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};

			SugarMill = new Building
			{
				Key = "SugarMill",
				DisplayName = "Zuckermühle",

				Input = new[]
				{
					new BuildingInput(RawMaterials.SugarCane)

				},
				Output = new BuildingOutput(RawMaterials.Sugar),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20,

				ProductionPerMinute = 4
			};

			AlmondPlantation = new Building
			{
				Key = "AlmondPlantation",
				DisplayName = "Mandelfarm",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Almonds),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5,

				ProductionPerMinute = 2
			};

			ClayPit = new Building
			{
				Key = "ClayPit",
				DisplayName = "Tongrube",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Clay),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5,

				ProductionPerMinute = 1.2
			};

			MosaicWorkshop = new Building
			{
				Key = "MosaicWorkshop",
				DisplayName = "Mosaikmacherei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Quartz),
					new BuildingInput(RawMaterials.Clay)

				},
				Output = new BuildingOutput(ConstructionMaterials.Mosaic),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2.4
			};

			ToolmakersWorkshop = new Building
			{
				Key = "ToolmakersWorkshop",
				DisplayName = "Werkzeugschmiede",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Iron)

				},
				Output = new BuildingOutput(ConstructionMaterials.Tools),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};

			Ropeyard = new Building
			{
				Key = "Ropeyard",
				DisplayName = "Seilerei",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Hemp)

				},
				Output = new BuildingOutput(RawMaterials.Ropes),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20,

				ProductionPerMinute = 2
			};

			GlassSmelter = new Building
			{
				Key = "GlassSmelter",
				DisplayName = "Glasmacher",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Quartz),
					new BuildingInput(RawMaterials.Potash)

				},
				Output = new BuildingOutput(ConstructionMaterials.Glass),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};

			IronSmelter = new Building
			{
				Key = "IronSmelter",
				DisplayName = "Eisenschmelze",

				Input = new[]
				{
					new BuildingInput(RawMaterials.IronOre),
					new BuildingInput(RawMaterials.Coal)

				},
				Output = new BuildingOutput(RawMaterials.Iron),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 2
			};

			GoldSmelter = new Building
			{
				Key = "GoldSmelter",
				DisplayName = "Goldschmelze",

				Input = new[]
				{
					new BuildingInput(RawMaterials.GoldOre),
					new BuildingInput(RawMaterials.Coal)

				},
				Output = new BuildingOutput(RawMaterials.Gold),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 1.5
			};

			CopperSmelter = new Building
			{
				Key = "CopperSmelter",
				DisplayName = "Kupferschmelze",

				Input = new[]
				{
					new BuildingInput(RawMaterials.CopperOre),
					new BuildingInput(RawMaterials.Coal)

				},
				Output = new BuildingOutput(RawMaterials.Brass),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 1.33
			};

			SaltMine = new Building
			{
				Key = "SaltMine",
				DisplayName = "Salzmine",
				Restrictions = BuildingRestrictions.Mountain,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Brine),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 4
			};

			OreMine = new Building
			{
				Key = "OreMine",
				DisplayName = "Eisenerzmine",
				Restrictions = BuildingRestrictions.Mountain,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.IronOre),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 2
			};

			GoldMine = new Building
			{
				Key = "GoldMine",
				DisplayName = "Goldmine",
				Restrictions = BuildingRestrictions.Mountain,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.GoldOre),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 30,

				ProductionPerMinute = 1.33
			};

			CopperMine = new Building
			{
				Key = "CopperMine",
				DisplayName = "Kupfermine",
				Restrictions = BuildingRestrictions.Mountain,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.CopperOre),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 25,

				ProductionPerMinute = 1.33
			};

			QuartzQuarry = new Building
			{
				Key = "QuartzQuarry",
				DisplayName = "Quarzbruch",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Quartz),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 1.33
			};

			LumberjacksHut = new Building
			{
				Key = "LumberjacksHut",
				DisplayName = "Holzfällerhütte",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConstructionMaterials.Wood),

				ActiveCostPerMinute = 5,
				InactiveCostPerMinute = 0,

				ProductionPerMinute = 1.5
			};

			StonemasonsHut = new Building
			{
				Key = "StonemasonsHut",
				DisplayName = "Steinmetz",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConstructionMaterials.Stone),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10,

				ProductionPerMinute = 2
			};

			CharcoalBurnersHut = new Building
			{
				Key = "CharcoalBurnersHut",
				DisplayName = "Köhlerhütte",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Coal),

				ActiveCostPerMinute = 10,
				InactiveCostPerMinute = 0,

				ProductionPerMinute = 2
			};

			PearlFishersHut = new Building
			{
				Key = "PearlFishersHut",
				DisplayName = "Perlentaucher",
				Restrictions = BuildingRestrictions.Coast,

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Pearls),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20,

				ProductionPerMinute = 1
			};

			ForestGlassworks = new Building
			{
				Key = "ForestGlassworks",
				DisplayName = "Waldglashütte",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Potash),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};

			CannonFoundry = new Building
			{
				Key = "CannonFoundry",
				DisplayName = "Kanonenschmiede",

				Input = new[]
				{
					new BuildingInput(ConstructionMaterials.Wood),
					new BuildingInput(RawMaterials.Iron)

				},
				Output = new BuildingOutput(WarfareMaterials.Cannons),

				ActiveCostPerMinute = 100,
				InactiveCostPerMinute = 50,

				ProductionPerMinute = 1
			};

			ProvisionHouse = new Building
			{
				Key = "ProvisionHouse",
				DisplayName = "Proviantmagazin",

				Input = new BuildingInput[0],
				Output = new BuildingOutput(WarfareMaterials.Provisions),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 0,

				ProductionPerMinute = 5.0 / 23.0 // Production cycle is 23 sec
			};

			WarMachinesWorkshop = new Building
			{
				Key = "WarMachinesWorkshop",
				DisplayName = "Kriegsmaschinenwerkstatt",

				Input = new[]
				{
					new BuildingInput(ConstructionMaterials.Wood),
					new BuildingInput(RawMaterials.Ropes)

				},
				Output = new BuildingOutput(WarfareMaterials.WarMachines),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30,

				ProductionPerMinute = 1.5
			};

			WeaponSmithy = new Building
			{
				Key = "WeaponSmithy",
				DisplayName = "Waffenschmiede",

				Input = new[]
				{
					new BuildingInput(RawMaterials.Iron)

				},
				Output = new BuildingOutput(WarfareMaterials.Weapons),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15,

				ProductionPerMinute = 2
			};
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