using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.Static
{
	static class Fertilities
	{
		public static readonly Fertility Cider = new Fertility {Key = "CiderFertility", DisplayName = "Fruchtbarkeit Most"};
		public static readonly Fertility Hemp = new Fertility {Key = "HempFertility", DisplayName = "Fruchtbarkeit Hanf" };
		public static readonly Fertility Herbs = new Fertility {Key = "HerbFertility", DisplayName = "Fruchtbarkeit Kräuter" };
		public static readonly Fertility Wheat = new Fertility {Key = "WheatFertility", DisplayName = "Fruchtbarkeit Weizen" };
		public static readonly Fertility Bees = new Fertility {Key = "BeeFertility", DisplayName = "Fruchtbarkeit Bienen" };
		public static readonly Fertility Grapes = new Fertility {Key = "GrapeFertility", DisplayName = "Fruchtbarkeit Trauben" };
		public static readonly Fertility Dates = new Fertility {Key = "DateFertility", DisplayName = "Fruchtbarkeit Datteln" };
		public static readonly Fertility Spices = new Fertility {Key = "SpiceFertility", DisplayName = "Fruchtbarkeit Gewürze" };
		public static readonly Fertility Indigo = new Fertility {Key = "IndigoFertility", DisplayName = "Fruchtbarkeit Indigo" };
		public static readonly Fertility Silk = new Fertility {Key = "SilkFertility", DisplayName = "Fruchtbarkeit Seide" };
		public static readonly Fertility Clay = new Fertility {Key = "ClayFertility", DisplayName = "Fruchtbarkeit Ton" };
		public static readonly Fertility Coffee = new Fertility {Key = "CoffeeFertility", DisplayName = "Fruchtbarkeit Kaffee" };
		public static readonly Fertility Roses = new Fertility {Key = "RoseFertility", DisplayName = "Fruchtbarkeit Rosen" };
		public static readonly Fertility Almonds = new Fertility {Key = "AlmondFertility", DisplayName = "Fruchtbarkeit Mandeln" };
		public static readonly Fertility SugarCanes = new Fertility {Key = "SugarCaneFertility", DisplayName = "Fruchtbarkeit Zuckerrohr" };
		public static readonly Fertility Forest = new Fertility {Key = "Forest", DisplayName = "Forst" };

		[NotNull]
		public static IEnumerable<Fertility> GetAll()
		{
			foreach (var field in typeof(Fertilities).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (Fertility)field.GetValue(null);
			}
		}
	}
}