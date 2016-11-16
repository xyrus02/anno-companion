using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class Buildings
	{
		public static readonly Building FishermansHut = new Building { Key = "FishermansHut", DisplayName = "Fischerhütte", Location = BuildingLocation.Coast };
		public static readonly Building SpiceFarm = new Building { Key = "SpiceFarm", DisplayName = "Gewürzplantage" };
		public static readonly Building Bakery = new Building { Key = "Bakery", DisplayName = "Backhaus" };
		public static readonly Building ButchersShop = new Building { Key = "ButchersShop", DisplayName = "Schlachterei" };
		public static readonly Building CiderFarm = new Building { Key = "CiderFarm", DisplayName = "Mosthof" };
		public static readonly Building MonasteryBrewery = new Building { Key = "MonasteryBrewery", DisplayName = "Klosterbrauerei" };
		public static readonly Building WinePress = new Building { Key = "WinePress", DisplayName = "Kelterhaus" };
		public static readonly Building WeaversHut = new Building { Key = "WeaversHut", DisplayName = "Weberhütte" };
		public static readonly Building Tannery = new Building { Key = "Tannery", DisplayName = "Gerberei", Location = BuildingLocation.River };
		public static readonly Building FurriersWorkshop = new Building { Key = "FurriersWorkshop", DisplayName = "Kürschnerei", Location = BuildingLocation.River };
		public static readonly Building SilkWeavingMill = new Building { Key = "SilkWeavingMill", DisplayName = "Seidenweberei" };
		public static readonly Building PrintingHouse = new Building { Key = "PrintingHouse", DisplayName = "Druckerei" };
		public static readonly Building RedsmithsWorkshop = new Building { Key = "RedsmithsWorkshop", DisplayName = "Feinschmiede" };
		public static readonly Building OpticiansWorkshop = new Building { Key = "OpticiansWorkshop", DisplayName = "Brillenmacherei" };
		public static readonly Building DatePlantation = new Building { Key = "DatePlantation", DisplayName = "Dattelplantage" };
		public static readonly Building GoatFarm = new Building { Key = "GoatFarm", DisplayName = "Ziegenfarm" };
		public static readonly Building CarpetWorkshop = new Building { Key = "CarpetWorkshop", DisplayName = "Teppichknüpferei" };
		public static readonly Building RoastingHouse = new Building { Key = "RoastingHouse", DisplayName = "Rösterei" };
		public static readonly Building PearlWorkshop = new Building { Key = "PearlWorkshop", DisplayName = "Perlenknüpfer" };
		public static readonly Building Perfumery = new Building { Key = "Perfumery", DisplayName = "Duftmischer" };
		public static readonly Building ConfectionersWorkshop = new Building { Key = "ConfectionersWorkshop", DisplayName = "Zuckerbäckerei" };

		public static readonly Building Mill = new Building { Key = "Mill", DisplayName = "Mühle" };
		public static readonly Building CropFarm = new Building { Key = "CropFarm", DisplayName = "Weizenfarm" };
		public static readonly Building CattleFarm = new Building { Key = "CattleFarm", DisplayName = "Rindefarm" };
		public static readonly Building MonestaryGarden = new Building { Key = "MonestaryGarden", DisplayName = "Klostergarten" };
		public static readonly Building Vineyard = new Building { Key = "Vineyard", DisplayName = "Weingut" };
		public static readonly Building BarrelCooperage = new Building { Key = "BarrelCooperage", DisplayName = "Fassküferei" };
		public static readonly Building HempPlantation = new Building { Key = "HempPlantation", DisplayName = "Hanfplantage" };
		public static readonly Building PigFarm = new Building { Key = "PigFarm", DisplayName = "Schweinezucht" };
		public static readonly Building TrappersLodge = new Building { Key = "TrappersLodge", DisplayName = "Pelztierjagdhütte", Location = BuildingLocation.Mountain };
		public static readonly Building SilkPlantation = new Building { Key = "SilkPlantation", DisplayName = "Seidenplantage" };
		public static readonly Building IndigoFarm = new Building { Key = "IndigoFarm", DisplayName = "Indigoplantage" };
		public static readonly Building PaperMill = new Building { Key = "PaperMill", DisplayName = "Papiermühle", Location = BuildingLocation.River };
		public static readonly Building SaltWorks = new Building { Key = "SaltWorks", DisplayName = "Saline" };
		public static readonly Building CandlemakersWorkshop = new Building { Key = "CandlemakersWorkshop", DisplayName = "Lichtzieherei" };
		public static readonly Building Apiary = new Building { Key = "Apiary", DisplayName = "Imkerei" };
		public static readonly Building CoffeePlantation = new Building { Key = "CoffeePlantation", DisplayName = "Kaffeeplantage" };
		public static readonly Building RoseNursery = new Building { Key = "RoseNursery", DisplayName = "Rosenplantage" };
		public static readonly Building SugarCanePlantation = new Building { Key = "SugarCanePlantation", DisplayName = "Zuckerrohrplantage" };
		public static readonly Building SugarMill = new Building { Key = "SugarMill", DisplayName = "Zuckermühle" };
		public static readonly Building AlmondPlantation = new Building { Key = "AlmondPlantation", DisplayName = "Mandelfarm" };

		public static readonly Building IronSmelter = new Building { Key = "IronSmelter", DisplayName = "Eisenschmelze" };
		public static readonly Building GoldSmelter = new Building { Key = "GoldSmelter", DisplayName = "Goldschmelze" };
		public static readonly Building CopperSmelter = new Building { Key = "CopperSmelter", DisplayName = "Kupferschmelze" };

		public static readonly Building SaltMine = new Building { Key = "SaltMine", DisplayName = "Salzmine", Location = BuildingLocation.Mountain };
		public static readonly Building OreMine = new Building { Key = "OreMine", DisplayName = "Eisenerzmine", Location = BuildingLocation.Mountain };
		public static readonly Building GoldMine = new Building { Key = "GoldMine", DisplayName = "Goldmine", Location = BuildingLocation.Mountain };
		public static readonly Building CopperMine = new Building { Key = "CopperMine", DisplayName = "Kupfermine", Location = BuildingLocation.Mountain };
		public static readonly Building QuartzQuarry = new Building { Key = "QuartzQuarry", DisplayName = "Quarzbruch", Location = BuildingLocation.Mountain };

		public static readonly Building LumberjacksHut = new Building { Key = "LumberjacksHut", DisplayName = "Holzfällerhütte" };
		public static readonly Building CharcoalBurnersHut = new Building { Key = "CharcoalBurnersHut", DisplayName = "Köhlerhütte" };
		public static readonly Building PearlFishersHut = new Building { Key = "PearlFishersHut", DisplayName = "Perlentaucher", Location = BuildingLocation.Coast };

		[CanBeNull]
		public static Building GetByName(string name)
		{
			var field = typeof(Buildings).GetField(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (Building)field.GetValue(null);
		}

		[NotNull]
		public static IEnumerable<Building> GetAll()
		{
			foreach (var field in typeof(Buildings).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				yield return (Building)field.GetValue(null);
			}
		}
	}
}