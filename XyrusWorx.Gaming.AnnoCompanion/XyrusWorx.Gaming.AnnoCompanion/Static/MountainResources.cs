using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Static
{
	static class MountainResources
	{
		public static readonly MountainResource IronOre = new MountainResource { Key = "IronOreResource", DisplayName = "Eisenvorkommen" };
		public static readonly MountainResource Coal = new MountainResource { Key = "CoalResource", DisplayName = "Kohlevorkommen" };
		public static readonly MountainResource GoldOre = new MountainResource { Key = "GoldOreResource", DisplayName = "Goldvorkommen" };
		public static readonly MountainResource CopperOre = new MountainResource { Key = "CopperOreResource", DisplayName = "Kupfervorkommen" };
		public static readonly MountainResource Brine = new MountainResource { Key = "BrineResource", DisplayName = "Solevorkommen" };
		public static readonly MountainResource Quartz = new MountainResource { Key = "QuartzResource", DisplayName = "Quartzvorkommen" };
		public static readonly MountainResource Quarry = new MountainResource { Key = "QuarryResource", DisplayName = "Steinbruch" };
		public static readonly MountainResource FurAnimals = new MountainResource { Key = "FurAnimalResource", DisplayName = "Pelztiere" };

		[NotNull]
		public static IEnumerable<MountainResource> GetAll()
		{
			foreach (var field in typeof(MountainResources).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (MountainResource)field.GetValue(null);
			}
		}
	}
}