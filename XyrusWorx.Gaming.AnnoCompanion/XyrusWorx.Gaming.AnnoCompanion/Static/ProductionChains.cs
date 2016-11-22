using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Static
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
		public static readonly ProductionChain Cannons;
		public static readonly ProductionChain Ropes;
		public static readonly ProductionChain Stone;
		public static readonly ProductionChain Mosaic;
		public static readonly ProductionChain Glass;
		public static readonly ProductionChain Tools;
		public static readonly ProductionChain WarMachines;
		public static readonly ProductionChain Weapons;
		public static readonly ProductionChain Wood;

		static ProductionChains()
		{
			Fish = new ProductionChain
			{
				Key = "FishProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.FishermansHut)
				}
			};

			Cider = new ProductionChain
			{
				Key = "CiderProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.CiderFarm)
				}
			};

			LinenGarments = new ProductionChain
			{
				Key = "LinenGarmentProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.WeaversHut),
					new ProductionChainComponent(2, Buildings.HempPlantation)
				}
			};

			Spices = new ProductionChain
			{
				Key = "SpiceProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.SpiceFarm)
				}
			};


			Bread = new ProductionChain
			{
				Key = "BreadProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.Bakery),
					new ProductionChainComponent(1, Buildings.Mill),
					new ProductionChainComponent(2, Buildings.CropFarm)
				}
			};

			Beer = new ProductionChain
			{
				Key = "BeerProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.MonasteryBrewery),
					new ProductionChainComponent(1, Buildings.MonasteryGarden),
					new ProductionChainComponent(1, Buildings.CropFarm)
				}
			};

			LeatherJerkins = new ProductionChain
			{
				Key = "LeatherJerkinProduction",
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.Tannery),
					new ProductionChainComponent(4, Buildings.PigFarm),
					new ProductionChainComponent(1, Buildings.SaltWorks),
					new ProductionChainComponent(1, Buildings.SaltMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				}
			};

			Books = new ProductionChain
			{
				Key = "BookProduction",
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.PrintingHouse),
					new ProductionChainComponent(4, Buildings.IndigoFarm),
					new ProductionChainComponent(1, Buildings.PaperMill),
					new ProductionChainComponent(2, Buildings.LumberjacksHut)
				}
			};

			Candlesticks = new ProductionChain
			{
				Key = "CandlestickProduction",
				Components = new[]
				{
					new ProductionChainComponent(4, Buildings.RedsmithsWorkshop),
					new ProductionChainComponent(6, Buildings.CandlemakersWorkshop),
					new ProductionChainComponent(12, Buildings.Apiary),
					new ProductionChainComponent(6, Buildings.HempPlantation),
					new ProductionChainComponent(3, Buildings.CopperSmelter),
					new ProductionChainComponent(3, Buildings.CopperMine),
					new ProductionChainComponent(2, Buildings.CharcoalBurnersHut),
				}
			};

			Meat = new ProductionChain
			{
				Key = "MeatProduction",
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.ButchersShop),
					new ProductionChainComponent(4, Buildings.CattleFarm),
					new ProductionChainComponent(1, Buildings.SaltWorks, 0.96),
					new ProductionChainComponent(1, Buildings.SaltMine, 0.96),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut, 0.96)
				}
			};

			Wine = new ProductionChain
			{
				Key = "WineProduction",
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.WinePress),
					new ProductionChainComponent(6, Buildings.Vineyard),
					new ProductionChainComponent(2, Buildings.BarrelCooperage),
					new ProductionChainComponent(2, Buildings.LumberjacksHut, 0.665),
					new ProductionChainComponent(1, Buildings.IronSmelter),
					new ProductionChainComponent(1, Buildings.OreMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				}
			};

			Glasses = new ProductionChain
			{
				Key = "GlassesProduction",
				Components = new[]
				{
					new ProductionChainComponent(4, Buildings.OpticiansWorkshop),
					new ProductionChainComponent(3, Buildings.QuartzQuarry),
					new ProductionChainComponent(3, Buildings.CopperSmelter),
					new ProductionChainComponent(3, Buildings.CopperMine),
					new ProductionChainComponent(2, Buildings.CharcoalBurnersHut)
				}
			};

			FurCoats = new ProductionChain
			{
				Key = "FurCoatProduction",
				Components = new[]
				{
					new ProductionChainComponent(3, Buildings.FurriersWorkshop),
					new ProductionChainComponent(3, Buildings.TrappersLodge),
					new ProductionChainComponent(1, Buildings.SaltWorks, 0.95),
					new ProductionChainComponent(1, Buildings.SaltMine, 0.95),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut, 0.95)
				}
			};

			BrocadeCoats = new ProductionChain
			{
				Key = "BrocadeCoatProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.SilkWeavingMill),
					new ProductionChainComponent(2, Buildings.SilkPlantation),
					new ProductionChainComponent(1, Buildings.GoldSmelter),
					new ProductionChainComponent(1, Buildings.GoldMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				}
			};

			Dates = new ProductionChain
			{
				Key = "DateProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.DatePlantation)
				}
			};

			Milk = new ProductionChain
			{
				Key = "MilkProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.GoatFarm)
				}
			};

			Carpets = new ProductionChain
			{
				Key = "CarpetProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.CarpetWorkshop),
					new ProductionChainComponent(1, Buildings.SilkPlantation),
					new ProductionChainComponent(1, Buildings.IndigoFarm)
				}
			};

			Coffee = new ProductionChain
			{
				Key = "CoffeeProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.RoastingHouse),
					new ProductionChainComponent(2, Buildings.CoffeePlantation)
				}
			};

			PearlNecklaces = new ProductionChain
			{
				Key = "PearlNecklaceProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.PearlWorkshop),
					new ProductionChainComponent(1, Buildings.PearlFishersHut)
				}
			};

			Perfume = new ProductionChain
			{
				Key = "PerfumeProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.Perfumery),
					new ProductionChainComponent(3, Buildings.RoseNursery)
				}
			};

			Marzipan = new ProductionChain
			{
				Key = "MarzipanProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.ConfectionersWorkshop),
					new ProductionChainComponent(2, Buildings.AlmondPlantation),
					new ProductionChainComponent(1, Buildings.SugarMill),
					new ProductionChainComponent(2, Buildings.SugarCanePlantation)
				}
			};

			Cannons = new ProductionChain
			{
				Key = "CannonProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.CannonFoundry), 
					new ProductionChainComponent(1, Buildings.IronSmelter), 
					new ProductionChainComponent(1, Buildings.OreMine), 
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut), 
					new ProductionChainComponent(2, Buildings.LumberjacksHut)
				}
			};

			Ropes = new ProductionChain
			{
				Key = "RopeProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.Ropeyard), 
					new ProductionChainComponent(1, Buildings.HempPlantation)
				}
			};

			Stone = new ProductionChain
			{
				Key = "StoneProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.StonemasonsHut)
				}
			};

			Glass = new ProductionChain
			{
				Key = "GlassProduction",
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.GlassSmelter),
					new ProductionChainComponent(1, Buildings.ForestGlassworks, 0.75),
					new ProductionChainComponent(1, Buildings.QuartzQuarry)
				}
			};

			Mosaic = new ProductionChain
			{
				Key = "MosaicProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.MosaicWorkshop),
					new ProductionChainComponent(1, Buildings.QuartzQuarry, 0.90),
					new ProductionChainComponent(2, Buildings.ClayPit)
				}
			};

			Tools = new ProductionChain
			{
				Key = "ToolProduction",
				Components = new[]
				{
					new ProductionChainComponent(2, Buildings.ToolmakersWorkshop),
					new ProductionChainComponent(1, Buildings.IronSmelter),
					new ProductionChainComponent(1, Buildings.OreMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				}
			};

			WarMachines = new ProductionChain
			{
				Key = "WarMachineProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.WarMachinesWorkshop),
					new ProductionChainComponent(2, Buildings.Ropeyard),
					new ProductionChainComponent(2, Buildings.HempPlantation),
					new ProductionChainComponent(2, Buildings.LumberjacksHut)
				}
			};

			Weapons = new ProductionChain
			{
				Key = "WeaponProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.WeaponSmithy),
					new ProductionChainComponent(1, Buildings.IronSmelter),
					new ProductionChainComponent(1, Buildings.OreMine),
					new ProductionChainComponent(1, Buildings.CharcoalBurnersHut)
				}
			};

			Wood = new ProductionChain
			{
				Key = "WoodProduction",
				Components = new[]
				{
					new ProductionChainComponent(1, Buildings.LumberjacksHut)
				}
			};

		}

		[NotNull]
		public static IEnumerable<ProductionChain> GetAll()
		{
			foreach (var field in typeof(ProductionChains).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (ProductionChain) field.GetValue(null);
			}
		}
	}
}