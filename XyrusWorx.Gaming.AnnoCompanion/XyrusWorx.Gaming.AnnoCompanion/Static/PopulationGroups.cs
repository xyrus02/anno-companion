using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Static
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
				Faction = Faction.Orient
			};

			Envoys = new PopulationGroup
			{
				Key = "Envoys",
				DisplayName = "Gesandte",
				Tier = 2,
				Faction = Faction.Orient
			};
			
			Noblemen = new PopulationGroup
			{
				Key = "Noblemen",
				DisplayName = "Adlige",
				Tier = 4,
				Faction = Faction.Occident
			};

			Patricians = new PopulationGroup
			{
				Key = "Patricians",
				DisplayName = "Patrizier",
				Tier = 3,
				Faction = Faction.Occident
			};

			Citizens = new PopulationGroup
			{
				Key = "Citizens",
				DisplayName = "Bürger",
				Tier = 2,
				Faction = Faction.Occident
			};

			Peasants = new PopulationGroup
			{
				Key = "Peasants",
				DisplayName = "Bauern",
				Tier = 1,
				Faction = Faction.Occident
			};

			Beggars = new PopulationGroup
			{
				Key = "Beggars",
				DisplayName = "Bettler",
				Tier = 1,
				Faction = Faction.Lawless
			};
		}

		[NotNull]
		public static IEnumerable<PopulationGroup> GetAll()
		{
			foreach (var field in typeof(PopulationGroups).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (PopulationGroup) field.GetValue(null);
			}
		}
	}
}