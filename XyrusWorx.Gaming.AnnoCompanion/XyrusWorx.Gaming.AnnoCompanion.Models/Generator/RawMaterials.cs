namespace XyrusWorx.Gaming.AnnoCompanion.Models.Generator
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

				TradeValue = 9,
				ProductionCost = 13.75
			};

			Hemp = new RawMaterial
			{
				Key = "Hemp",
				DisplayName = "Hemp",

				TradeValue = 24,
				ProductionCost = 20
			};

			Brine = new RawMaterial
			{
				Key = "Brine",
				DisplayName = "Sole",

				TradeValue = 6,
				ProductionCost = 5
			};

			IronOre = new RawMaterial
			{
				Key = "IronOre",
				DisplayName = "Eisenerz",

				TradeValue = 12,
				ProductionCost = 10
			};

			Iron = new RawMaterial
			{
				Key = "Iron",
				DisplayName = "Eisen",

				TradeValue = 33,
				ProductionCost = 25
			};

			Flour = new RawMaterial
			{
				Key = "Flour",
				DisplayName = "Mehl",

				TradeValue = 16,
				ProductionCost = 10
			};

			Coal = new RawMaterial
			{
				Key = "Coal",
				DisplayName = "Kohle",

				TradeValue = 9,
				ProductionCost = 5
			};

			Wheat = new RawMaterial
			{
				Key = "Wheat",
				DisplayName = "Weizen",

				TradeValue = 3,
				ProductionCost = 2.5
			};

			Herbs = new RawMaterial
			{
				Key = "Herbs",
				DisplayName = "Kräuter",

				TradeValue = 6,
				ProductionCost = 5
			};

			Potash = new RawMaterial
			{
				Key = "Potash",
				DisplayName = "Pottasche",

				TradeValue = 20,
				ProductionCost = 15
			};

			Paper = new RawMaterial
			{
				Key = "Paper",
				DisplayName = "Papier",

				TradeValue = 24,
				ProductionCost = 20
			};

			Furs = new RawMaterial
			{
				Key = "Furs",
				DisplayName = "Pelze",

				TradeValue = 19,
				ProductionCost = 12
			};

			Barrels = new RawMaterial
			{
				Key = "Barrels",
				DisplayName = "Fässer",

				TradeValue = 38,
				ProductionCost = 29.17
			};

			CopperOre = new RawMaterial
			{
				Key = "CopperOre",
				DisplayName = "Kupfererz",

				TradeValue = 36,
				ProductionCost = 30
			};

			Brass = new RawMaterial
			{
				Key = "Brass",
				DisplayName = "Messing",

				TradeValue = 84,
				ProductionCost = 65
			};

			Grapes = new RawMaterial
			{
				Key = "Grapes",
				DisplayName = "Weintrauben",

				TradeValue = 45,
				ProductionCost = 37.5
			};

			Cattle = new RawMaterial
			{
				Key = "Cattle",
				DisplayName = "Rinder",

				TradeValue = 9,
				ProductionCost = 20
			};

			RoseOil = new RawMaterial
			{
				Key = "RoseOil",
				DisplayName = "Rosenöl",

				TradeValue = 75,
				ProductionCost = 60
			};

			Beeswax = new RawMaterial
			{
				Key = "Beeswax",
				DisplayName = "Bienenwachs",

				TradeValue = 27,
				ProductionCost = 22.5
			};

			Candles = new RawMaterial
			{
				Key = "Candles",
				DisplayName = "Kerzen",

				TradeValue = 87,
				ProductionCost = 97.5
			};

			CoffeeBeans = new RawMaterial
			{
				Key = "CoffeeBeans",
				DisplayName = "Kaffeebohnen",

				TradeValue = 50,
				ProductionCost = 20
			};

			GoldOre = new RawMaterial
			{
				Key = "GoldOre",
				DisplayName = "Golderz",

				TradeValue = 40,
				ProductionCost = 37.5
			};

			Indigo = new RawMaterial
			{
				Key = "Indigo",
				DisplayName = "Indigo",

				TradeValue = 19,
				ProductionCost = 13.33
			};

			Gold = new RawMaterial
			{
				Key = "Gold",
				DisplayName = "Gold",

				TradeValue = 40,
				ProductionCost = 58.33
			};

			Sugar = new RawMaterial
			{
				Key = "Sugar",
				DisplayName = "Zucker",

				TradeValue = 26,
				ProductionCost = 27.5
			};

			SugarCane = new RawMaterial
			{
				Key = "SugarCane",
				DisplayName = "Zuckerrohr",

				TradeValue = 13,
				ProductionCost = 17.5
			};

			Almonds = new RawMaterial
			{
				Key = "Almonds",
				DisplayName = "Mandeln",

				TradeValue = 9,
				ProductionCost = 7.5
			};

			Clay = new RawMaterial
			{
				Key = "Clay",
				DisplayName = "Ton",

				TradeValue = 18,
				ProductionCost = 12.5
			};

			Silk = new RawMaterial
			{
				Key = "Silk",
				DisplayName = "Seide",

				TradeValue = 21,
				ProductionCost = 16.67
			};

			Pearls = new RawMaterial
			{
				Key = "Pearls",
				DisplayName = "Perlen",

				TradeValue = 48,
				ProductionCost = 40
			};

			Quartz = new RawMaterial
			{
				Key = "Quartz",
				DisplayName = "Quarz",

				TradeValue = 18,
				ProductionCost = 15
			};

			Ropes = new RawMaterial
			{
				Key = "Ropes",
				DisplayName = "Seile",

				TradeValue = 39,
				ProductionCost = 30
			};

			AnimalHides = new RawMaterial
			{
				Key = "AnimalHides",
				DisplayName = "Tierhäute",

				TradeValue = 24,
				ProductionCost = 7.5
			};
		}
	}
}