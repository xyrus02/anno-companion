using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Static
{
	static class ConstructionMaterials
	{
		public static readonly ConstructionMaterial Wood;
		public static readonly ConstructionMaterial Tools;
		public static readonly ConstructionMaterial Stone;
		public static readonly ConstructionMaterial Glass;
		public static readonly ConstructionMaterial Mosaic;

		static ConstructionMaterials()
		{
			Wood = new ConstructionMaterial
			{
				Key = "Wood",
				DisplayName = "Holz",

				TradeValue = 4,
				ProductionCost = 3.33
			};

			Tools = new ConstructionMaterial
			{
				Key = "Tools",
				DisplayName = "Werkzeug",

				TradeValue = 36,
				ProductionCost = 27.5
			};

			Stone = new ConstructionMaterial
			{
				Key = "Stone",
				DisplayName = "Steine",
				
				TradeValue = 8,
				ProductionCost = 10
			};

			Glass = new ConstructionMaterial
			{
				Key = "Glass",
				DisplayName = "Glas",
				
				TradeValue = 68,
				ProductionCost = 26.25
			};

			Mosaic = new ConstructionMaterial
			{
				Key = "Mosaic",
				DisplayName = "Mosaik",
				
				TradeValue = 46,
				ProductionCost = 32.5
			};
		}

		[NotNull]
		public static IEnumerable<ConstructionMaterial> GetAll()
		{
			foreach (var field in typeof(ConstructionMaterials).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (ConstructionMaterial)field.GetValue(null);
			}
		}
	}
}