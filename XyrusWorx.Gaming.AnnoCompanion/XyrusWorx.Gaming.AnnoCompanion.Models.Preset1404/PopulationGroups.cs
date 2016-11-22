namespace XyrusWorx.Gaming.AnnoCompanion.Models.Preset1404
{
	static class PopulationGroups
	{
		public static readonly PopulationGroup Beggars;
		public static readonly PopulationGroup Peasants;
		public static readonly PopulationGroup Citizens;
		public static readonly PopulationGroup Patricians;
		public static readonly PopulationGroup Noblemen;
		public static readonly PopulationGroup Nomads;
		public static readonly PopulationGroup Envoys;

		static PopulationGroups()
		{
			Nomads = new PopulationGroup
			{
				Key = "Nomads",
				DisplayName = "Nomaden",
				Tier = 1,
				Fraction = Fractions.Orient
			};

			Envoys = new PopulationGroup
			{
				Key = "Envoys",
				DisplayName = "Gesandte",
				Tier = 2,
				Fraction = Fractions.Orient
			};
			
			Noblemen = new PopulationGroup
			{
				Key = "Noblemen",
				DisplayName = "Adlige",
				Tier = 4,
				Fraction = Fractions.Occident
			};

			Patricians = new PopulationGroup
			{
				Key = "Patricians",
				DisplayName = "Patrizier",
				Tier = 3,
				Fraction = Fractions.Occident
			};

			Citizens = new PopulationGroup
			{
				Key = "Citizens",
				DisplayName = "Bürger",
				Tier = 2,
				Fraction = Fractions.Occident
			};

			Peasants = new PopulationGroup
			{
				Key = "Peasants",
				DisplayName = "Bauern",
				Tier = 1,
				Fraction = Fractions.Occident
			};

			Beggars = new PopulationGroup
			{
				Key = "Beggars",
				DisplayName = "Bettler",
				Tier = 1,
				Fraction = Fractions.Lawless
			};
		}
	}
}