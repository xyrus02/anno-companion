using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class ConsumableGoods
	{
		public static readonly ConsumableGood Fishes;
		public static readonly ConsumableGood Spices;
		public static readonly ConsumableGood Bread;
		public static readonly ConsumableGood Meat;
		public static readonly ConsumableGood Cider;
		public static readonly ConsumableGood Beer;
		public static readonly ConsumableGood Wine;
		public static readonly ConsumableGood LinenGarments;
		public static readonly ConsumableGood LeatherJerkins;
		public static readonly ConsumableGood FurCoats;
		public static readonly ConsumableGood BrocadeCoats;
		public static readonly ConsumableGood Books;
		public static readonly ConsumableGood Candlesticks;
		public static readonly ConsumableGood Glasses;
		public static readonly ConsumableGood Dates;
		public static readonly ConsumableGood Milk;
		public static readonly ConsumableGood Carpets;
		public static readonly ConsumableGood Coffee;
		public static readonly ConsumableGood PearlNecklaces;
		public static readonly ConsumableGood Perfume;
		public static readonly ConsumableGood Marzipan;

		static ConsumableGoods()
		{
			Fishes = new ConsumableGood
			{
				Key = "Fishes",
				DisplayName = "Fische",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants),
				ConsumingPopulationGroups = new []
				{
					PopulationGroups.Beggars,
					PopulationGroups.Peasants,
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 9,
				CommonProductionCost = 7.5
			};

			Spices = new ConsumableGood
			{
				Key = "Spices",
				DisplayName = "Gewürze",

				UnlockThreshold = new PopulationRequirement(145, PopulationGroups.Nomads),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 18,
				CommonProductionCost = 15
			};

			Bread = new ConsumableGood
			{
				Key = "Bread",
				DisplayName = "Brot",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 26,
				CommonProductionCost = 17.5
			};

			Meat = new ConsumableGood
			{
				Key = "Meat",
				DisplayName = "Fleisch",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 50,
				CommonProductionCost = 51
			};

			Cider = new ConsumableGood
			{
				Key = "Cider",
				DisplayName = "Most",

				UnlockThreshold = new PopulationRequirement(60, PopulationGroups.Peasants),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Beggars,
					PopulationGroups.Peasants,
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 12,
				CommonProductionCost = 10
			};

			Beer = new ConsumableGood
			{
				Key = "Beer",
				DisplayName = "Bier",

				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 39,
				CommonProductionCost = 30
			};

			Wine = new ConsumableGood
			{
				Key = "Wine",
				DisplayName = "Wein",

				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 120,
				CommonProductionCost =91.66
			};

			LinenGarments = new ConsumableGood
			{
				Key = "LinenGarments",
				DisplayName = "Leinenkutten",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 46,
				CommonProductionCost = 32.5
			};

			LeatherJerkins = new ConsumableGood
			{
				Key = "LeatherJerkins",
				DisplayName = "Lederwämser",

				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 41,
				CommonProductionCost = 19.38
			};

			FurCoats = new ConsumableGood
			{
				Key = "FurCoats",
				DisplayName = "Pelzmäntel",

				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 77,
				CommonProductionCost = 55.33
			};

			BrocadeCoats = new ConsumableGood
			{
				Key = "BrocadeCoats",
				DisplayName = "Brokatgewänder",

				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 108,
				CommonProductionCost = 72.5
			};

			Books = new ConsumableGood
			{
				Key = "Books",
				DisplayName = "Bücher",

				UnlockThreshold = new PopulationRequirement(940, PopulationGroups.Patricians),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 50,
				CommonProductionCost = 40
			};

			Candlesticks = new ConsumableGood
			{
				Key = "Candlesticks",
				DisplayName = "Kerzenleuchter",

				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				},

				CommonTradeValue = 194,
				CommonProductionCost = 130
			};

			Glasses = new ConsumableGood
			{
				Key = "Glasses",
				DisplayName = "Brillen",

				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Noblemen
				},
				
				CommonTradeValue = 90,
				CommonProductionCost = 60
			};

			Dates = new ConsumableGood
			{
				Key = "Dates",
				DisplayName = "Datteln",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Nomads),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Nomads,
					PopulationGroups.Envoys
				},

				CommonTradeValue = 4,
				CommonProductionCost = 15
			};

			Milk = new ConsumableGood
			{
				Key = "Milk",
				DisplayName = "Milch",

				UnlockThreshold = new PopulationRequirement(145, PopulationGroups.Nomads),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Nomads,
					PopulationGroups.Envoys
				},

				CommonTradeValue = 16,
				CommonProductionCost = 13.33
			};

			Carpets = new ConsumableGood
			{
				Key = "Carpets",
				DisplayName = "Teppiche",

				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Nomads,
					PopulationGroups.Envoys
				},

				CommonTradeValue = 107,
				CommonProductionCost = 70
			};

			Coffee = new ConsumableGood
			{
				Key = "Coffee",
				DisplayName = "Kaffee",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Envoys),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Envoys
				},

				CommonTradeValue = 162,
				CommonProductionCost = 85
			};

			PearlNecklaces = new ConsumableGood
			{
				Key = "PearlNecklaces",
				DisplayName = "Perlenketten",

				UnlockThreshold = new PopulationRequirement(1040, PopulationGroups.Envoys),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Envoys
				},

				CommonTradeValue = 165,
				CommonProductionCost = 110
			};

			Perfume = new ConsumableGood
			{
				Key = "Perfume",
				DisplayName = "Parfüm",

				UnlockThreshold = new PopulationRequirement(2600, PopulationGroups.Envoys),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Envoys
				},

				CommonTradeValue = 225,
				CommonProductionCost = 150
			};

			Marzipan = new ConsumableGood
			{
				Key = "Marzipan",
				DisplayName = "Marzipan",

				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),
				ConsumingPopulationGroups = new[]
				{
					PopulationGroups.Envoys
				},

				CommonTradeValue = 78,
				CommonProductionCost = 60
			};
		}

		[CanBeNull]
		public static ConsumableGood GetByKey(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}

			var field = typeof(ConsumableGoods).GetField(key, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (ConsumableGood) field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<ConsumableGood> GetAll()
		{
			foreach (var field in typeof(ConsumableGoods).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (ConsumableGood)field.GetValue(null);
			}
		}
	}
}