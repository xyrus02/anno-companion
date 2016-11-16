using System.Reflection;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	static class ConsumableGoods
	{
		public static readonly ConsumableGood Fish;
		public static readonly ConsumableGood Spices;
		public static readonly ConsumableGood Bread;
		public static readonly ConsumableGood Meat;
		public static readonly ConsumableGood Cider;
		public static readonly ConsumableGood Beer;
		public static readonly ConsumableGood Wine;
		public static readonly ConsumableGood LinenGarments;
		public static readonly ConsumableGood LeatherJerkins;
		public static readonly ConsumableGood FurCoats;
		public static readonly ConsumableGood BrocadeCoats;
		public static readonly ConsumableGood Books;
		public static readonly ConsumableGood Candlesticks;
		public static readonly ConsumableGood Glasses;
		public static readonly ConsumableGood Dates;
		public static readonly ConsumableGood Milk;
		public static readonly ConsumableGood Carpets;
		public static readonly ConsumableGood Coffee;
		public static readonly ConsumableGood PearlNecklaces;
		public static readonly ConsumableGood Perfume;
		public static readonly ConsumableGood Marzipan;

		static ConsumableGoods()
		{
			Fish = new ConsumableGood
			{
				Key = "Fish",
				DisplayName = "Fische",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Peasants),
				RequiredBy = new []
				{
					PopulationGroups.Beggars,
					PopulationGroups.Peasants,
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Spices = new ConsumableGood
			{
				Key = "Spices",
				DisplayName = "Gewürze",

				UnlockThreshold = new PopulationRequirement(145, PopulationGroups.Nomads),
				RequiredBy = new[]
				{
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Bread = new ConsumableGood
			{
				Key = "Bread",
				DisplayName = "Brot",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Patricians),
				RequiredBy = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Meat = new ConsumableGood
			{
				Key = "Meat",
				DisplayName = "Fleisch",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Noblemen),
				RequiredBy = new[]
				{
					PopulationGroups.Noblemen
				}
			};

			Cider = new ConsumableGood
			{
				Key = "Cider",
				DisplayName = "Most",

				UnlockThreshold = new PopulationRequirement(60, PopulationGroups.Peasants),
				RequiredBy = new[]
				{
					PopulationGroups.Beggars,
					PopulationGroups.Peasants,
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Beer = new ConsumableGood
			{
				Key = "Beer",
				DisplayName = "Bier",

				UnlockThreshold = new PopulationRequirement(510, PopulationGroups.Patricians),
				RequiredBy = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Wine = new ConsumableGood
			{
				Key = "Wine",
				DisplayName = "Wein",

				UnlockThreshold = new PopulationRequirement(1500, PopulationGroups.Noblemen),
				RequiredBy = new[]
				{
					PopulationGroups.Noblemen
				}
			};

			LinenGarments = new ConsumableGood
			{
				Key = "LinenGarments",
				DisplayName = "Leinenkutten",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Citizens),
				RequiredBy = new[]
				{
					PopulationGroups.Citizens,
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			LeatherJerkins = new ConsumableGood
			{
				Key = "LeatherJerkins",
				DisplayName = "Lederwämser",

				UnlockThreshold = new PopulationRequirement(690, PopulationGroups.Patricians),
				RequiredBy = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			FurCoats = new ConsumableGood
			{
				Key = "FurCoats",
				DisplayName = "Pelzmäntel",

				UnlockThreshold = new PopulationRequirement(950, PopulationGroups.Noblemen),
				RequiredBy = new[]
				{
					PopulationGroups.Noblemen
				}
			};

			BrocadeCoats = new ConsumableGood
			{
				Key = "BrocadeCoats",
				DisplayName = "Brokatgewänder",

				UnlockThreshold = new PopulationRequirement(4000, PopulationGroups.Noblemen),
				RequiredBy = new[]
				{
					PopulationGroups.Noblemen
				}
			};

			Books = new ConsumableGood
			{
				Key = "Books",
				DisplayName = "Bücher",

				UnlockThreshold = new PopulationRequirement(940, PopulationGroups.Patricians),
				RequiredBy = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Candlesticks = new ConsumableGood
			{
				Key = "Candlestick",
				DisplayName = "Kerzenleuchter",

				UnlockThreshold = new PopulationRequirement(3000, PopulationGroups.Noblemen),
				RequiredBy = new[]
				{
					PopulationGroups.Patricians,
					PopulationGroups.Noblemen
				}
			};

			Glasses = new ConsumableGood
			{
				Key = "Glasses",
				DisplayName = "Brillen",

				UnlockThreshold = new PopulationRequirement(2200, PopulationGroups.Noblemen),
				RequiredBy = new[]
				{
					PopulationGroups.Noblemen
				}
			};

			Dates = new ConsumableGood
			{
				Key = "Dates",
				DisplayName = "Datteln",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Nomads),
				RequiredBy = new[]
				{
					PopulationGroups.Nomads,
					PopulationGroups.Envoys
				}
			};

			Milk = new ConsumableGood
			{
				Key = "Milk",
				DisplayName = "Milch",

				UnlockThreshold = new PopulationRequirement(145, PopulationGroups.Nomads),
				RequiredBy = new[]
				{
					PopulationGroups.Nomads,
					PopulationGroups.Envoys
				}
			};

			Carpets = new ConsumableGood
			{
				Key = "Carpets",
				DisplayName = "Teppiche",

				UnlockThreshold = new PopulationRequirement(295, PopulationGroups.Nomads),
				RequiredBy = new[]
				{
					PopulationGroups.Nomads,
					PopulationGroups.Envoys
				}
			};

			Coffee = new ConsumableGood
			{
				Key = "Coffee",
				DisplayName = "Kaffee",

				UnlockThreshold = new PopulationRequirement(1, PopulationGroups.Envoys),
				RequiredBy = new[]
				{
					PopulationGroups.Envoys
				}
			};

			PearlNecklaces = new ConsumableGood
			{
				Key = "PearlNecklaces",
				DisplayName = "Perlenketten",

				UnlockThreshold = new PopulationRequirement(1040, PopulationGroups.Envoys),
				RequiredBy = new[]
				{
					PopulationGroups.Envoys
				}
			};

			Perfume = new ConsumableGood
			{
				Key = "Perfume",
				DisplayName = "Parfüm",

				UnlockThreshold = new PopulationRequirement(2600, PopulationGroups.Envoys),
				RequiredBy = new[]
				{
					PopulationGroups.Envoys
				}
			};

			Marzipan = new ConsumableGood
			{
				Key = "Marzipan",
				DisplayName = "Marzipan",

				UnlockThreshold = new PopulationRequirement(4360, PopulationGroups.Envoys),
				RequiredBy = new[]
				{
					PopulationGroups.Envoys
				}
			};
		}

		[CanBeNull]
		public static ConsumableGood GetByName(string name)
		{
			var field = typeof(ConsumableGoods).GetField(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
			if (field == null)
			{
				return null;
			}

			return (ConsumableGood) field.GetValue(null);
		}
	}
}