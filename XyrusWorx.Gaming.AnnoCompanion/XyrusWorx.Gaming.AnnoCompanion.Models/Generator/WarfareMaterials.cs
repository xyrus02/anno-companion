using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.Models.Generator
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

				TradeValue = 52,
				ProductionCost = 40
			};

			WarMachines = new WarfareMaterial()
			{
				Key = "WarMachines",
				DisplayName = "Kriegsmaschinen",

				TradeValue = 119,
				ProductionCost = 106.66
			};

			Cannons = new WarfareMaterial()
			{
				Key = "Cannons",
				DisplayName = "Kanonen",

				TradeValue = 169,
				ProductionCost = 155
			};

			Provisions = new WarfareMaterial()
			{
				Key = "Provisions",
				DisplayName = "Proviant",

				TradeValue = 168,
				ProductionCost = 150 // Production I,II,III = 150,100,148.5 => 112%,168%,113%
			};
		}
	}
}