namespace XyrusWorx.Gaming.AnnoCompanion.Models.Generator
{
	static class Buildings
	{
		public static readonly ProductionBuilding FishermansHut;
		public static readonly ProductionBuilding SpiceFarm;
		public static readonly ProductionBuilding Bakery;
		public static readonly ProductionBuilding ButchersShop;
		public static readonly ProductionBuilding CiderFarm;
		public static readonly ProductionBuilding MonasteryBrewery;
		public static readonly ProductionBuilding WinePress;
		public static readonly ProductionBuilding WeaversHut;
		public static readonly ProductionBuilding Tannery;
		public static readonly ProductionBuilding FurriersWorkshop;
		public static readonly ProductionBuilding SilkWeavingMill;
		public static readonly ProductionBuilding PrintingHouse;
		public static readonly ProductionBuilding RedsmithsWorkshop;
		public static readonly ProductionBuilding OpticiansWorkshop;
		public static readonly ProductionBuilding DatePlantation;
		public static readonly ProductionBuilding GoatFarm;
		public static readonly ProductionBuilding CarpetWorkshop;
		public static readonly ProductionBuilding RoastingHouse;
		public static readonly ProductionBuilding PearlWorkshop;
		public static readonly ProductionBuilding Perfumery;
		public static readonly ProductionBuilding ConfectionersWorkshop;

		public static readonly ProductionBuilding Mill;
		public static readonly ProductionBuilding CropFarm;
		public static readonly ProductionBuilding CattleFarm;
		public static readonly ProductionBuilding MonasteryGarden;
		public static readonly ProductionBuilding Vineyard;
		public static readonly ProductionBuilding BarrelCooperage;
		public static readonly ProductionBuilding HempPlantation;
		public static readonly ProductionBuilding PigFarm;
		public static readonly ProductionBuilding TrappersLodge;
		public static readonly ProductionBuilding SilkPlantation;
		public static readonly ProductionBuilding IndigoFarm;
		public static readonly ProductionBuilding PaperMill;
		public static readonly ProductionBuilding SaltWorks;
		public static readonly ProductionBuilding CandlemakersWorkshop;
		public static readonly ProductionBuilding Apiary;
		public static readonly ProductionBuilding CoffeePlantation;
		public static readonly ProductionBuilding RoseNursery;
		public static readonly ProductionBuilding SugarCanePlantation;
		public static readonly ProductionBuilding SugarMill;
		public static readonly ProductionBuilding AlmondPlantation;
		public static readonly ProductionBuilding ClayPit;
		public static readonly ProductionBuilding MosaicWorkshop;
		public static readonly ProductionBuilding ToolmakersWorkshop;
		public static readonly ProductionBuilding Ropeyard;

		public static readonly ProductionBuilding GlassSmelter;
		public static readonly ProductionBuilding IronSmelter;
		public static readonly ProductionBuilding GoldSmelter;
		public static readonly ProductionBuilding CopperSmelter;

		public static readonly ProductionBuilding SaltMine;
		public static readonly ProductionBuilding OreMine;
		public static readonly ProductionBuilding GoldMine;
		public static readonly ProductionBuilding CopperMine;
		public static readonly ProductionBuilding CoalMine;
		public static readonly ProductionBuilding QuartzQuarry;

		public static readonly ProductionBuilding LumberjacksHut;
		public static readonly ProductionBuilding StonemasonsHut;
		public static readonly ProductionBuilding CharcoalBurnersHut;
		public static readonly ProductionBuilding PearlFishersHut;
		public static readonly ProductionBuilding ForestGlassworks;

		public static readonly ProductionBuilding CannonFoundry;
		public static readonly ProductionBuilding ProvisionHouse;
		public static readonly ProductionBuilding WarMachinesWorkshop;
		public static readonly ProductionBuilding WeaponSmithy;

		static Buildings()
		{
			FishermansHut = new ProductionBuilding
			{
				Key = "FishermansHut",
				DisplayName = "Fischerhütte",
				Restrictions = BuildingRestrictions.Coast,

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants),

				Input = new[]
				{
					new BuildingInput(WaterResources.Fishes)
				},
				Output = new BuildingOutput(ConsumableGoods.Fishes, 2),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5
			};

			SpiceFarm = new ProductionBuilding
			{
				Key = "SpiceFarm",
				DisplayName = "Gewürzplantage",

				UnlockThreshold = new PopulationRequirement(145, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(Fertilities.Spices)
				},
				Output = new BuildingOutput(ConsumableGoods.Spices, 2),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			Bakery = new ProductionBuilding
			{
				Key = "Bakery",
				DisplayName = "Backhaus",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Flour)

				},
				Output = new BuildingOutput(ConsumableGoods.Bread, 4),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			ButchersShop = new ProductionBuilding
			{
				Key = "ButchersShop",
				DisplayName = "Schlachterei",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Cattle),
					new BuildingInput(RawMaterials.Salt)

				},
				Output = new BuildingOutput(ConsumableGoods.Meat, 2.5),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25
			};

			CiderFarm = new ProductionBuilding
			{
				Key = "CiderFarm",
				DisplayName = "Mosthof",

				UnlockThreshold = new PopulationRequirement(60, PopulationGroups.Peasants),

				Input = new[]
				{
					new BuildingInput(Fertilities.Cider)
				},
				Output = new BuildingOutput(ConsumableGoods.Cider, 1.5),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5
			};

			MonasteryBrewery = new ProductionBuilding
			{
				Key = "MonasteryBrewery",
				DisplayName = "Klosterbrauerei",

				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Herbs),
					new BuildingInput(RawMaterials.Wheat)
				},
				Output = new BuildingOutput(ConsumableGoods.Beer, 1.5),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			WinePress = new ProductionBuilding
			{
				Key = "WinePress",
				DisplayName = "Kelterhaus",

				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Barrels),
					new BuildingInput(RawMaterials.Grapes)

				},
				Output = new BuildingOutput(ConsumableGoods.Wine, 2),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25
			};

			WeaversHut = new ProductionBuilding
			{
				Key = "WeaversHut",
				DisplayName = "Weberhütte",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Hemp)
				},
				Output = new BuildingOutput(ConsumableGoods.LinenGarments, 2),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 10
			};

			Tannery = new ProductionBuilding
			{
				Key = "Tannery",
				DisplayName = "Gerberei",
				Restrictions = BuildingRestrictions.River,

				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Salt),
					new BuildingInput(RawMaterials.AnimalHides)

				},
				Output = new BuildingOutput(ConsumableGoods.LeatherJerkins, 4),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			FurriersWorkshop = new ProductionBuilding
			{
				Key = "FurriersWorkshop",
				DisplayName = "Kürschnerei",
				Restrictions = BuildingRestrictions.River,

				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Furs),
					new BuildingInput(RawMaterials.Salt)

				},
				Output = new BuildingOutput(ConsumableGoods.FurCoats, 2.5),

				ActiveCostPerMinute = 90,
				InactiveCostPerMinute = 45
			};

			SilkWeavingMill = new ProductionBuilding
			{
				Key = "SilkWeavingMill",
				DisplayName = "Seidenweberei",

				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Silk),
					new BuildingInput(RawMaterials.Gold)

				},
				Output = new BuildingOutput(ConsumableGoods.BrocadeCoats, 3),

				ActiveCostPerMinute = 80,
				InactiveCostPerMinute = 40
			};

			PrintingHouse = new ProductionBuilding
			{
				Key = "PrintingHouse",
				DisplayName = "Druckerei",

				UnlockThreshold = new PopulationRequirement(940, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Paper)
				},
				Output = new BuildingOutput(ConsumableGoods.Books, 3),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25
			};

			RedsmithsWorkshop = new ProductionBuilding
			{
				Key = "RedsmithsWorkshop",
				DisplayName = "Feinschmiede",

				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Brass),
					new BuildingInput(RawMaterials.Candles)

				},
				Output = new BuildingOutput(ConsumableGoods.Candlesticks, 2),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30
			};

			OpticiansWorkshop = new ProductionBuilding
			{
				Key = "OpticiansWorkshop",
				DisplayName = "Brillenmacherei",

				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Quartz),
					new BuildingInput(RawMaterials.Brass)

				},
				Output = new BuildingOutput(ConsumableGoods.Glasses, 2),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20
			};

			DatePlantation = new ProductionBuilding
			{
				Key = "DatePlantation",
				DisplayName = "Dattelplantage",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(Fertilities.Dates)
				},
				Output = new BuildingOutput(ConsumableGoods.Dates, 3),

				ActiveCostPerMinute = 45,
				InactiveCostPerMinute = 20
			};

			GoatFarm = new ProductionBuilding
			{
				Key = "GoatFarm",
				DisplayName = "Ziegenfarm",

				UnlockThreshold = new PopulationRequirement(145, PopulationGroups.Nomads),

				Input = new BuildingInput[0],
				Output = new BuildingOutput(ConsumableGoods.Milk, 1.5),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			CarpetWorkshop = new ProductionBuilding
			{
				Key = "CarpetWorkshop",
				DisplayName = "Teppichknüpferei",

				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Indigo),
					new BuildingInput(RawMaterials.Silk)

				},
				Output = new BuildingOutput(ConsumableGoods.Carpets, 1.5),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30
			};

			RoastingHouse = new ProductionBuilding
			{
				Key = "RoastingHouse",
				DisplayName = "Rösterei",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(RawMaterials.CoffeeBeans)
				},
				Output = new BuildingOutput(ConsumableGoods.Coffee, 1),

				ActiveCostPerMinute = 45,
				InactiveCostPerMinute = 25
			};

			PearlWorkshop = new ProductionBuilding
			{
				Key = "PearlWorkshop",
				DisplayName = "Perlenknüpfer",

				UnlockThreshold = new PopulationRequirement(1040, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Pearls)
				},
				Output = new BuildingOutput(ConsumableGoods.PearlNecklaces, 1),

				ActiveCostPerMinute = 70,
				InactiveCostPerMinute = 35
			};

			Perfumery = new ProductionBuilding
			{
				Key = "Perfumery",
				DisplayName = "Duftmischer",

				UnlockThreshold = new PopulationRequirement(2600, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(RawMaterials.RoseOil)
				},
				Output = new BuildingOutput(ConsumableGoods.Perfume, 1),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30
			};

			ConfectionersWorkshop = new ProductionBuilding
			{
				Key = "ConfectionersWorkshop",
				DisplayName = "Zuckerbäckerei",

				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Sugar),
					new BuildingInput(RawMaterials.Almonds)
				},
				Output = new BuildingOutput(ConsumableGoods.Marzipan, 4),

				ActiveCostPerMinute = 100,
				InactiveCostPerMinute = 50
			};

			Mill = new ProductionBuilding
			{
				Key = "Mill",
				DisplayName = "Mühle",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Wheat)
				},
				Output = new BuildingOutput(RawMaterials.Flour, 4),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 10
			};

			CropFarm = new ProductionBuilding
			{
				Key = "CropFarm",
				DisplayName = "Weizenfarm",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(Fertilities.Wheat)
				},
				Output = new BuildingOutput(RawMaterials.Wheat, 2),

				ActiveCostPerMinute = 5,
				InactiveCostPerMinute = 0
			};

			CattleFarm = new ProductionBuilding
			{
				Key = "CattleFarm",
				DisplayName = "Rindefarm",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.Cattle, 1.25),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 10
			};

			MonasteryGarden = new ProductionBuilding
			{
				Key = "MonasteryGarden",
				DisplayName = "Klostergarten",

				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(Fertilities.Herbs)
				},
				Output = new BuildingOutput(RawMaterials.Herbs, 2),

				ActiveCostPerMinute = 10,
				InactiveCostPerMinute = 0
			};

			Vineyard = new ProductionBuilding
			{
				Key = "Vineyard",
				DisplayName = "Weingut",

				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(Fertilities.Grapes)
				},
				Output = new BuildingOutput(RawMaterials.Grapes, 0.66),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 15
			};

			BarrelCooperage = new ProductionBuilding
			{
				Key = "BarrelCooperage",
				DisplayName = "Fassküferei",

				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Iron),
					new BuildingInput(ConstructionMaterials.Wood)

				},
				Output = new BuildingOutput(RawMaterials.Barrels, 2),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			HempPlantation = new ProductionBuilding
			{
				Key = "HempPlantation",
				DisplayName = "Hanfplantage",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(Fertilities.Hemp)
				},
				Output = new BuildingOutput(RawMaterials.Hemp, 1),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			PigFarm = new ProductionBuilding
			{
				Key = "PigFarm",
				DisplayName = "Schweinezucht",

				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				Input = new BuildingInput[0],
				Output = new BuildingOutput(RawMaterials.AnimalHides, 2),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 10
			};

			TrappersLodge = new ProductionBuilding
			{
				Key = "TrappersLodge",
				DisplayName = "Pelztierjagdhütte",
				Restrictions = BuildingRestrictions.Mountain,

				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(MountainResources.FurAnimals)
				},
				Output = new BuildingOutput(RawMaterials.Furs, 2.50),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			SilkPlantation = new ProductionBuilding
			{
				Key = "SilkPlantation",
				DisplayName = "Seidenplantage",

				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(Fertilities.Silk)
				},
				Output = new BuildingOutput(RawMaterials.Silk, 1.5),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 10
			};

			IndigoFarm = new ProductionBuilding
			{
				Key = "IndigoFarm",
				DisplayName = "Indigoplantage",

				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(Fertilities.Indigo)
				},
				Output = new BuildingOutput(RawMaterials.Indigo, 1.5),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			PaperMill = new ProductionBuilding
			{
				Key = "PaperMill",
				DisplayName = "Papiermühle",
				Restrictions = BuildingRestrictions.River,

				UnlockThreshold = new PopulationRequirement(940, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(ConstructionMaterials.Wood)
				},
				Output = new BuildingOutput(RawMaterials.Paper, 3),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 25
			};

			SaltWorks = new ProductionBuilding
			{
				Key = "SaltWorks",
				DisplayName = "Saline",

				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Brine)
				},
				Output = new BuildingOutput(RawMaterials.Salt, 4),

				ActiveCostPerMinute = 25,
				InactiveCostPerMinute = 12
			};

			CandlemakersWorkshop = new ProductionBuilding
			{
				Key = "CandlemakersWorkshop",
				DisplayName = "Lichtzieherei",

				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Beeswax),
					new BuildingInput(RawMaterials.Hemp)
				},
				Output = new BuildingOutput(RawMaterials.Candles, 1.33),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20
			};

			Apiary = new ProductionBuilding
			{
				Key = "Apiary",
				DisplayName = "Imkerei",

				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(Fertilities.Bees)
				},
				Output = new BuildingOutput(RawMaterials.Beeswax, 0.67),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 10
			};

			CoffeePlantation = new ProductionBuilding
			{
				Key = "CoffeePlantation",
				DisplayName = "Kaffeeplantage",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(Fertilities.Coffee)
				},
				Output = new BuildingOutput(RawMaterials.CoffeeBeans, 1),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			RoseNursery = new ProductionBuilding
			{
				Key = "RoseNursery",
				DisplayName = "Rosenplantage",

				UnlockThreshold = new PopulationRequirement(2600, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(Fertilities.Roses)
				},
				Output = new BuildingOutput(RawMaterials.RoseOil, 0.5),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			SugarCanePlantation = new ProductionBuilding
			{
				Key = "SugarCanePlantation",
				DisplayName = "Zuckerrohrplantage",

				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(Fertilities.SugarCanes)
				},
				Output = new BuildingOutput(RawMaterials.SugarCane, 2),

				ActiveCostPerMinute = 35,
				InactiveCostPerMinute = 15
			};

			SugarMill = new ProductionBuilding
			{
				Key = "SugarMill",
				DisplayName = "Zuckermühle",

				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(RawMaterials.SugarCane)

				},
				Output = new BuildingOutput(RawMaterials.Sugar, 4),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20
			};

			AlmondPlantation = new ProductionBuilding
			{
				Key = "AlmondPlantation",
				DisplayName = "Mandelfarm",

				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(Fertilities.Almonds)
				},
				Output = new BuildingOutput(RawMaterials.Almonds, 2),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5
			};

			ClayPit = new ProductionBuilding
			{
				Key = "ClayPit",
				DisplayName = "Tongrube",

				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(Fertilities.Clay)
				},
				Output = new BuildingOutput(RawMaterials.Clay, 1.2),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 5
			};

			MosaicWorkshop = new ProductionBuilding
			{
				Key = "MosaicWorkshop",
				DisplayName = "Mosaikmacherei",

				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Quartz),
					new BuildingInput(RawMaterials.Clay)

				},
				Output = new BuildingOutput(ConstructionMaterials.Mosaic, 2.4),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			ToolmakersWorkshop = new ProductionBuilding
			{
				Key = "ToolmakersWorkshop",
				DisplayName = "Werkzeugschmiede",

				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Iron)

				},
				Output = new BuildingOutput(ConstructionMaterials.Tools, 2),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			Ropeyard = new ProductionBuilding
			{
				Key = "Ropeyard",
				DisplayName = "Seilerei",

				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Hemp)

				},
				Output = new BuildingOutput(RawMaterials.Ropes, 2),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20
			};

			GlassSmelter = new ProductionBuilding
			{
				Key = "GlassSmelter",
				DisplayName = "Glasmacher",

				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Quartz),
					new BuildingInput(RawMaterials.Potash)

				},
				Output = new BuildingOutput(ConstructionMaterials.Glass, 2),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			IronSmelter = new ProductionBuilding
			{
				Key = "IronSmelter",
				DisplayName = "Eisenschmelze",

				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(RawMaterials.IronOre),
					new BuildingInput(RawMaterials.Coal)

				},
				Output = new BuildingOutput(RawMaterials.Iron, 2),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			GoldSmelter = new ProductionBuilding
			{
				Key = "GoldSmelter",
				DisplayName = "Goldschmelze",

				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.GoldOre),
					new BuildingInput(RawMaterials.Coal)

				},
				Output = new BuildingOutput(RawMaterials.Gold, 1.5),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			CopperSmelter = new ProductionBuilding
			{
				Key = "CopperSmelter",
				DisplayName = "Kupferschmelze",

				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(RawMaterials.CopperOre),
					new BuildingInput(RawMaterials.Coal)

				},
				Output = new BuildingOutput(RawMaterials.Brass, 1.33),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 25
			};

			SaltMine = new ProductionBuilding
			{
				Key = "SaltMine",
				DisplayName = "Salzmine",
				Restrictions = BuildingRestrictions.Mountain,

				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(MountainResources.Brine)
				},
				Output = new BuildingOutput(RawMaterials.Brine, 4),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			OreMine = new ProductionBuilding
			{
				Key = "OreMine",
				DisplayName = "Eisenerzmine",
				Restrictions = BuildingRestrictions.Mountain,

				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(MountainResources.IronOre)
				},
				Output = new BuildingOutput(RawMaterials.IronOre, 2),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			GoldMine = new ProductionBuilding
			{
				Key = "GoldMine",
				DisplayName = "Goldmine",
				Restrictions = BuildingRestrictions.Mountain,

				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(MountainResources.GoldOre)
				},
				Output = new BuildingOutput(RawMaterials.GoldOre, 1.33),

				ActiveCostPerMinute = 50,
				InactiveCostPerMinute = 30
			};

			CopperMine = new ProductionBuilding
			{
				Key = "CopperMine",
				DisplayName = "Kupfermine",
				Restrictions = BuildingRestrictions.Mountain,

				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(MountainResources.CopperOre)
				},
				Output = new BuildingOutput(RawMaterials.CopperOre, 1.33),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 25
			};

			CoalMine = new ProductionBuilding
			{
				Key = "CoalMine",
				DisplayName = "Kohlemine",
				Restrictions = BuildingRestrictions.Mountain,

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(MountainResources.Coal)
				},
				Output = new BuildingOutput(RawMaterials.Coal, 4),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			QuartzQuarry = new ProductionBuilding
			{
				Key = "QuartzQuarry",
				DisplayName = "Quarzbruch",

				UnlockThreshold = new PopulationRequirement(440, PopulationGroups.Nomads),

				Input = new[]
				{
					new BuildingInput(MountainResources.Quartz)
				},
				Output = new BuildingOutput(RawMaterials.Quartz, 1.33),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			LumberjacksHut = new ProductionBuilding
			{
				Key = "LumberjacksHut",
				DisplayName = "Holzfällerhütte",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants),

				Input = new[]
				{
					new BuildingInput(Fertilities.Forest)
				},
				Output = new BuildingOutput(ConstructionMaterials.Wood, 1.5),

				ActiveCostPerMinute = 5,
				InactiveCostPerMinute = 0
			};

			StonemasonsHut = new ProductionBuilding
			{
				Key = "StonemasonsHut",
				DisplayName = "Steinmetz",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(MountainResources.Quarry)
				},
				Output = new BuildingOutput(ConstructionMaterials.Stone, 2),

				ActiveCostPerMinute = 20,
				InactiveCostPerMinute = 10
			};

			CharcoalBurnersHut = new ProductionBuilding
			{
				Key = "CharcoalBurnersHut",
				DisplayName = "Köhlerhütte",

				UnlockThreshold = new PopulationRequirement(240, PopulationGroups.Citizens),

				Input = new[]
				{
					new BuildingInput(Fertilities.Forest)
				},
				Output = new BuildingOutput(RawMaterials.Coal, 2),

				ActiveCostPerMinute = 10,
				InactiveCostPerMinute = 0
			};

			PearlFishersHut = new ProductionBuilding
			{
				Key = "PearlFishersHut",
				DisplayName = "Perlentaucher",
				Restrictions = BuildingRestrictions.Coast,

				UnlockThreshold = new PopulationRequirement(1040, PopulationGroups.Envoys),

				Input = new[]
				{
					new BuildingInput(WaterResources.Reef)
				},
				Output = new BuildingOutput(RawMaterials.Pearls, 1),

				ActiveCostPerMinute = 40,
				InactiveCostPerMinute = 20
			};

			ForestGlassworks = new ProductionBuilding
			{
				Key = "ForestGlassworks",
				DisplayName = "Waldglashütte",

				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(Fertilities.Forest)
				},
				Output = new BuildingOutput(RawMaterials.Potash, 2),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};

			CannonFoundry = new ProductionBuilding
			{
				Key = "CannonFoundry",
				DisplayName = "Kanonenschmiede",

				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(ConstructionMaterials.Wood),
					new BuildingInput(RawMaterials.Iron)
				},
				Output = new BuildingOutput(WarfareMaterials.Cannons, 1),

				ActiveCostPerMinute = 100,
				InactiveCostPerMinute = 50
			};

			ProvisionHouse = new ProductionBuilding
			{
				Key = "ProvisionHouse",
				DisplayName = "Proviantmagazin",

				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),

				Input = new BuildingInput[0],
				Output = new BuildingOutput(WarfareMaterials.Provisions, 5.0),

				ActiveCostPerMinute = 15,
				InactiveCostPerMinute = 0 / 23.0 // Production cycle is 23 sec
			};

			WarMachinesWorkshop = new ProductionBuilding
			{
				Key = "WarMachinesWorkshop",
				DisplayName = "Kriegsmaschinenwerkstatt",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),

				Input = new[]
				{
					new BuildingInput(ConstructionMaterials.Wood),
					new BuildingInput(RawMaterials.Ropes)

				},
				Output = new BuildingOutput(WarfareMaterials.WarMachines, 1.5),

				ActiveCostPerMinute = 60,
				InactiveCostPerMinute = 30
			};

			WeaponSmithy = new ProductionBuilding
			{
				Key = "WeaponSmithy",
				DisplayName = "Waffenschmiede",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),

				Input = new[]
				{
					new BuildingInput(RawMaterials.Iron)
				},
				Output = new BuildingOutput(WarfareMaterials.Weapons, 2),

				ActiveCostPerMinute = 30,
				InactiveCostPerMinute = 15
			};
		}
	}
}