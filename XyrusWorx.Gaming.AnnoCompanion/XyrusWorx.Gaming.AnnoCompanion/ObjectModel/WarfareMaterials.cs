using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class WarfareMaterials
	{
		public static readonly WarfareMaterial Weapons;
		public static readonly WarfareMaterial WarMachines;
		public static readonly WarfareMaterial Cannons;
		public static readonly WarfareMaterial Provisions;

		static WarfareMaterials()
		{
			Weapons = new WarfareMaterial()
			{
				Key = "Weapons",
				DisplayName = "Waffen",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians)
			};

			WarMachines = new WarfareMaterial()
			{
				Key = "WarMachines",
				DisplayName = "Kriegsmaschinen",
				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen)
			};

			Cannons = new WarfareMaterial()
			{
				Key = "Cannons",
				DisplayName = "Kanonen",
				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen)
			};

			Provisions = new WarfareMaterial()
			{
				Key = "Provisions",
				DisplayName = "Proviant",
				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen)
			};
		}

		[CanBeNull]
		public static WarfareMaterial GetByKey(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}

			var field = typeof(WarfareMaterials).GetField(key, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (WarfareMaterial)field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<WarfareMaterial> GetAll()
		{
			foreach (var field in typeof(WarfareMaterials).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (WarfareMaterial)field.GetValue(null);
			}
		}
	}
}