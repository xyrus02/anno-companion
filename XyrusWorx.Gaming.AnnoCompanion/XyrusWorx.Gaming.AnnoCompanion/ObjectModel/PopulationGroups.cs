using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class PopulationGroups
	{
		public static readonly PopulationGroup Beggars = new PopulationGroup { Key = "Beggars", DisplayName = "Bettler", Tier = 0, Faction = Factions.Occident };
		public static readonly PopulationGroup Peasants = new PopulationGroup { Key = "Peasants", DisplayName = "Bauern", Tier = 1, Faction = Factions.Occident };
		public static readonly PopulationGroup Citizens = new PopulationGroup { Key = "Citizens", DisplayName = "Bürger", Tier = 2, Faction = Factions.Occident };
		public static readonly PopulationGroup Patricians = new PopulationGroup { Key = "Patricians", DisplayName = "Patrizier", Tier = 3, Faction = Factions.Occident };
		public static readonly PopulationGroup Noblemen = new PopulationGroup { Key = "Noblemen", DisplayName = "Adlige", Tier = 4, Faction = Factions.Occident };
		public static readonly PopulationGroup Nomads = new PopulationGroup { Key = "Nomads", DisplayName = "Nomaden", Tier = 1, Faction = Factions.Orient };
		public static readonly PopulationGroup Envoys = new PopulationGroup { Key = "Envoys", DisplayName = "Gesandte", Tier = 2, Faction = Factions.Orient };

		[CanBeNull]
		public static ConsumableGood GetByName(string name)
		{
			var field = typeof(ConsumableGoods).GetField(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (ConsumableGood)field.GetValue(null);
		}
	}
}