namespace XyrusWorx.Gaming.AnnoCompanion.Models.Preset1404
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

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(285, PopulationGroups.Beggars),
					new ProvisionCapacity(200, PopulationGroups.Peasants),
					new ProvisionCapacity(500, PopulationGroups.Citizens),
					new ProvisionCapacity(909, PopulationGroups.Patricians),
					new ProvisionCapacity(1250, PopulationGroups.Noblemen)
				},

				TradeValue = 9,
				ProductionCost = 7.5
			};

			Spices = new ConsumableGood
			{
				Key = "Spices",
				DisplayName = "Gewürze",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(500, PopulationGroups.Citizens),
					new ProvisionCapacity(909, PopulationGroups.Patricians),
					new ProvisionCapacity(1250, PopulationGroups.Noblemen)
				},

				TradeValue = 18,
				ProductionCost = 15
			};

			Bread = new ConsumableGood
			{
				Key = "Bread",
				DisplayName = "Brot",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(727, PopulationGroups.Patricians),
					new ProvisionCapacity(1025, PopulationGroups.Noblemen)
				},

				TradeValue = 26,
				ProductionCost = 17.5
			};

			Meat = new ConsumableGood
			{
				Key = "Meat",
				DisplayName = "Fleisch",
				
				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1136, PopulationGroups.Noblemen)
				},

				TradeValue = 50,
				ProductionCost = 51
			};

			Cider = new ConsumableGood
			{
				Key = "Cider",
				DisplayName = "Most",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(500, PopulationGroups.Beggars),
					new ProvisionCapacity(340, PopulationGroups.Peasants),
					new ProvisionCapacity(340, PopulationGroups.Citizens),
					new ProvisionCapacity(652, PopulationGroups.Patricians),
					new ProvisionCapacity(1153, PopulationGroups.Noblemen)
				},

				TradeValue = 12,
				ProductionCost = 10
			};

			Beer = new ConsumableGood
			{
				Key = "Beer",
				DisplayName = "Bier",

				
				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(625, PopulationGroups.Patricians),
					new ProvisionCapacity(1071, PopulationGroups.Noblemen)
				},

				TradeValue = 39,
				ProductionCost = 30
			};

			Wine = new ConsumableGood
			{
				Key = "Wine",
				DisplayName = "Wein",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1000, PopulationGroups.Noblemen)
				},

				TradeValue = 120,
				ProductionCost =91.66
			};

			LinenGarments = new ConsumableGood
			{
				Key = "LinenGarments",
				DisplayName = "Leinenkutten",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(476, PopulationGroups.Citizens),
					new ProvisionCapacity(1052, PopulationGroups.Patricians),
					new ProvisionCapacity(2500, PopulationGroups.Noblemen)
				},

				TradeValue = 46,
				ProductionCost = 32.5
			};

			LeatherJerkins = new ConsumableGood
			{
				Key = "LeatherJerkins",
				DisplayName = "Lederwämser",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1428, PopulationGroups.Patricians),
					new ProvisionCapacity(2500, PopulationGroups.Noblemen)
				},

				TradeValue = 41,
				ProductionCost = 19.38
			};

			FurCoats = new ConsumableGood
			{
				Key = "FurCoats",
				DisplayName = "Pelzmäntel",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1562, PopulationGroups.Noblemen)
				},

				TradeValue = 77,
				ProductionCost = 55.33
			};

			BrocadeCoats = new ConsumableGood
			{
				Key = "BrocadeCoats",
				DisplayName = "Brokatgewänder",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(2112, PopulationGroups.Noblemen)
				},

				TradeValue = 108,
				ProductionCost = 72.5
			};

			Books = new ConsumableGood
			{
				Key = "Books",
				DisplayName = "Bücher",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1875, PopulationGroups.Patricians),
					new ProvisionCapacity(3333, PopulationGroups.Noblemen)
				},

				TradeValue = 50,
				ProductionCost = 40
			};

			Candlesticks = new ConsumableGood
			{
				Key = "Candlesticks",
				DisplayName = "Kerzenleuchter",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(2500, PopulationGroups.Patricians),
					new ProvisionCapacity(3333, PopulationGroups.Noblemen)
				},

				TradeValue = 194,
				ProductionCost = 130
			};

			Glasses = new ConsumableGood
			{
				Key = "Glasses",
				DisplayName = "Brillen",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1709, PopulationGroups.Noblemen)
				},
				
				TradeValue = 90,
				ProductionCost = 60
			};

			Dates = new ConsumableGood
			{
				Key = "Dates",
				DisplayName = "Datteln",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(450, PopulationGroups.Nomads),
					new ProvisionCapacity(600, PopulationGroups.Envoys)
				},

				TradeValue = 4,
				ProductionCost = 15
			};

			Milk = new ConsumableGood
			{
				Key = "Milk",
				DisplayName = "Milch",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(436, PopulationGroups.Nomads),
					new ProvisionCapacity(666, PopulationGroups.Envoys)
				},

				TradeValue = 16,
				ProductionCost = 13.33
			};

			Carpets = new ConsumableGood
			{
				Key = "Carpets",
				DisplayName = "Teppiche",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(909, PopulationGroups.Nomads),
					new ProvisionCapacity(1500, PopulationGroups.Envoys)
				},

				TradeValue = 107,
				ProductionCost = 70
			};

			Coffee = new ConsumableGood
			{
				Key = "Coffee",
				DisplayName = "Kaffee",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1000, PopulationGroups.Envoys)
				},

				TradeValue = 162,
				ProductionCost = 85
			};

			PearlNecklaces = new ConsumableGood
			{
				Key = "PearlNecklaces",
				DisplayName = "Perlenketten",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(751, PopulationGroups.Envoys)
				},

				TradeValue = 165,
				ProductionCost = 110
			};

			Perfume = new ConsumableGood
			{
				Key = "Perfume",
				DisplayName = "Parfüm",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(1250, PopulationGroups.Envoys)
				},

				TradeValue = 225,
				ProductionCost = 150
			};

			Marzipan = new ConsumableGood
			{
				Key = "Marzipan",
				DisplayName = "Marzipan",

				ProvisionCapacities = new[]
				{
					new ProvisionCapacity(2453, PopulationGroups.Envoys)
				},

				TradeValue = 78,
				ProductionCost = 60
			};
		}
	}
}