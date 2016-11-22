using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Static
{
	static class WaterResources
	{
		public static readonly WaterResource Fishes = new WaterResource { Key = "FishResource", DisplayName = "Fischgründe" };
		public static readonly WaterResource Reef = new WaterResource { Key = "ReefResource", DisplayName = "Korallenriff" };

		[NotNull]
		public static IEnumerable<WaterResource> GetAll()
		{
			foreach (var field in typeof(WaterResources).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (WaterResource)field.GetValue(null);
			}
		}
	}
}