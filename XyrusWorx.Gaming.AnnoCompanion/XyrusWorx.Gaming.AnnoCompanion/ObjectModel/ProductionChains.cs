namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class ProductionChains
	{
		public static readonly ProductionChain Fish;
		public static readonly ProductionChain Spices;
		public static readonly ProductionChain Bread;
		public static readonly ProductionChain Meat;
		public static readonly ProductionChain Cider;
		public static readonly ProductionChain Beer;
		public static readonly ProductionChain Wine;
		public static readonly ProductionChain LinenGarments;
		public static readonly ProductionChain LeatherJerkins;
		public static readonly ProductionChain FurCoats;
		public static readonly ProductionChain BrocadeCoats;
		public static readonly ProductionChain Books;
		public static readonly ProductionChain Candlesticks;
		public static readonly ProductionChain Glasses;
		public static readonly ProductionChain Dates;
		public static readonly ProductionChain Milk;
		public static readonly ProductionChain Carpets;
		public static readonly ProductionChain Coffee;
		public static readonly ProductionChain PearlNecklaces;
		public static readonly ProductionChain Perfume;
		public static readonly ProductionChain Marzipan;

		static ProductionChains()
		{
			Fish = new ProductionChain
			{
				OutputGood = ConsumableGoods.Fish,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.FishermansHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(285, PopulationGroups.Beggars), 
					new ProvisionCapacity(200, PopulationGroups.Peasants), 
					new ProvisionCapacity(500, PopulationGroups.Citizens), 
					new ProvisionCapacity(909, PopulationGroups.Patricians), 
					new ProvisionCapacity(1250, PopulationGroups.Noblemen)
				}
			};

			Cider = new ProductionChain
			{
				OutputGood = ConsumableGoods.Cider,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.CiderFarm)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(500, PopulationGroups.Beggars),
					new ProvisionCapacity(340, PopulationGroups.Peasants),
					new ProvisionCapacity(340, PopulationGroups.Citizens),
					new ProvisionCapacity(652, PopulationGroups.Patricians),
					new ProvisionCapacity(1153, PopulationGroups.Noblemen)
				}
			};

			LinenGarments = new ProductionChain
			{
				OutputGood = ConsumableGoods.LinenGarments,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.WeaversHut),
					new ProductionChainComponent(2, Buildings.HempPlantation)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(476, PopulationGroups.Citizens),
					new ProvisionCapacity(1052, PopulationGroups.Patricians),
					new ProvisionCapacity(2500, PopulationGroups.Noblemen)
				}
			};

			Spices = new ProductionChain
			{
				OutputGood = ConsumableGoods.Spices,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.SpiceFarm)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(500, PopulationGroups.Citizens),
					new ProvisionCapacity(909, PopulationGroups.Patricians),
					new ProvisionCapacity(1250, PopulationGroups.Noblemen)
				}
			};


			Bread = new ProductionChain
			{
				OutputGood = ConsumableGoods.Bread,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.Bakery),
					new ProductionChainComponent(1, Buildings.Mill),
					new ProductionChainComponent(2, Buildings.CropFarm)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(727, PopulationGroups.Patricians),
					new ProvisionCapacity(1025, PopulationGroups.Noblemen)
				}
			};

			Beer = new ProductionChain
			{
				OutputGood = ConsumableGoods.Beer,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.MonasteryBrewery),
					new ProductionChainComponent(1, Buildings.MonestaryGarden),
					new ProductionChainComponent(1, Buildings.CropFarm)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(625, PopulationGroups.Patricians),
					new ProvisionCapacity(1071, PopulationGroups.Noblemen)
				}
			};

			LeatherJerkins = new ProductionChain
			{
				OutputGood = ConsumableGoods.LeatherJerkins,
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.Tannery),
					new ProductionChainComponent(4, Buildings.PigFarm),
					new ProductionChainComponent(1, Buildings.SaltWorks),
					new ProductionChainComponent(1, Buildings.SaltMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1428, PopulationGroups.Patricians),
					new ProvisionCapacity(2500, PopulationGroups.Noblemen)
				}
			};

			Books = new ProductionChain
			{
				OutputGood = ConsumableGoods.Books,
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.PrintingHouse),
					new ProductionChainComponent(4, Buildings.IndigoFarm),
					new ProductionChainComponent(1, Buildings.PaperMill),
					new ProductionChainComponent(2, Buildings.LumberjacksHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1875, PopulationGroups.Patricians),
					new ProvisionCapacity(3333, PopulationGroups.Noblemen)
				}
			};

			Candlesticks = new ProductionChain
			{
				OutputGood = ConsumableGoods.Candlesticks,
				Components = new[]
				{
					new ProductionChainComponent(4, Buildings.RedsmithsWorkshop),
					new ProductionChainComponent(6, Buildings.CandlemakersWorkshop),
					new ProductionChainComponent(12, Buildings.Apiary),
					new ProductionChainComponent(6, Buildings.HempPlantation),
					new ProductionChainComponent(3, Buildings.CopperSmelter),
					new ProductionChainComponent(3, Buildings.CopperMine),
					new ProductionChainComponent(2, Buildings.CharcoalBurnersHut),
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(2500, PopulationGroups.Patricians),
					new ProvisionCapacity(3333, PopulationGroups.Noblemen)
				}
			};

			Meat = new ProductionChain
			{
				OutputGood = ConsumableGoods.Meat,
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.ButchersShop),
					new ProductionChainComponent(4, Buildings.CattleFarm),
					new ProductionChainComponent(1, Buildings.SaltWorks, 0.96),
					new ProductionChainComponent(1, Buildings.SaltMine, 0.96),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut, 0.96)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1136, PopulationGroups.Noblemen)
				}
			};

			Wine = new ProductionChain
			{
				OutputGood = ConsumableGoods.Wine,
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.WinePress),
					new ProductionChainComponent(6, Buildings.Vineyard),
					new ProductionChainComponent(2, Buildings.BarrelCooperage),
					new ProductionChainComponent(2, Buildings.LumberjacksHut, 0.665),
					new ProductionChainComponent(1, Buildings.IronSmelter),
					new ProductionChainComponent(1, Buildings.OreMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1000, PopulationGroups.Noblemen)
				}
			};

			Glasses = new ProductionChain
			{
				OutputGood = ConsumableGoods.Glasses,
				Components = new[]
				{
					new ProductionChainComponent(4, Buildings.OpticiansWorkshop),
					new ProductionChainComponent(3, Buildings.QuartzQuarry),
					new ProductionChainComponent(3, Buildings.CopperSmelter),
					new ProductionChainComponent(3, Buildings.CopperMine),
					new ProductionChainComponent(2, Buildings.CharcoalBurnersHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1709, PopulationGroups.Noblemen)
				}
			};

			FurCoats = new ProductionChain
			{
				OutputGood = ConsumableGoods.FurCoats,
				Components = new[]
				{
					new ProductionChainComponent(3, Buildings.FurriersWorkshop),
					new ProductionChainComponent(3, Buildings.TrappersLodge),
					new ProductionChainComponent(1, Buildings.SaltWorks, 0.95),
					new ProductionChainComponent(1, Buildings.SaltMine, 0.95),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut, 0.95)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1562, PopulationGroups.Noblemen)
				}
			};

			BrocadeCoats = new ProductionChain
			{
				OutputGood = ConsumableGoods.BrocadeCoats,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.SilkWeavingMill),
					new ProductionChainComponent(2, Buildings.SilkPlantation),
					new ProductionChainComponent(1, Buildings.GoldSmelter),
					new ProductionChainComponent(1, Buildings.GoldMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(2112, PopulationGroups.Noblemen)
				}
			};

			Dates = new ProductionChain
			{
				OutputGood = ConsumableGoods.Dates,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.DatePlantation)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(450, PopulationGroups.Nomads),
					new ProvisionCapacity(600, PopulationGroups.Envoys)
				}
			};

			Milk = new ProductionChain
			{
				OutputGood = ConsumableGoods.Milk,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.GoatFarm)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(436, PopulationGroups.Nomads),
					new ProvisionCapacity(666, PopulationGroups.Envoys)
				}
			};

			Carpets = new ProductionChain
			{
				OutputGood = ConsumableGoods.Carpets,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.CarpetWorkshop),
					new ProductionChainComponent(1, Buildings.SilkPlantation),
					new ProductionChainComponent(1, Buildings.IndigoFarm)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(909, PopulationGroups.Nomads),
					new ProvisionCapacity(1500, PopulationGroups.Envoys)
				}
			};

			Coffee = new ProductionChain
			{
				OutputGood = ConsumableGoods.Coffee,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.RoastingHouse),
					new ProductionChainComponent(2, Buildings.CoffeePlantation)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1000, PopulationGroups.Envoys)
				}
			};

			PearlNecklaces = new ProductionChain
			{
				OutputGood = ConsumableGoods.PearlNecklaces,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.PearlWorkshop),
					new ProductionChainComponent(1, Buildings.PearlFishersHut)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(751, PopulationGroups.Envoys)
				}
			};

			Perfume = new ProductionChain
			{
				OutputGood = ConsumableGoods.Perfume,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.Perfumery),
					new ProductionChainComponent(3, Buildings.RoseNursery)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1250, PopulationGroups.Envoys)
				}
			};

			Marzipan = new ProductionChain
			{
				OutputGood = ConsumableGoods.Marzipan,
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.ConfectionersWorkshop),
					new ProductionChainComponent(2, Buildings.AlmondPlantation),
					new ProductionChainComponent(1, Buildings.SugarMill),
					new ProductionChainComponent(2, Buildings.SugarCanePlantation)
				},

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(2453, PopulationGroups.Envoys)
				}
			};
		}
	}
}