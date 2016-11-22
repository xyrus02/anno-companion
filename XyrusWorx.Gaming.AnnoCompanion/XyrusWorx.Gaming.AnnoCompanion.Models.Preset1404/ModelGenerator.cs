using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Models.Preset1404
{
	[PublicAPI]
	public class Anno4ModelGenerator : IModelGenerator
	{
		public void AddToIconResolver(IIconResolver iconResolver)
		{
			iconResolver.AddExternalDataSource(new EmbeddedBlobStore(
				typeof(Anno4ModelGenerator).Assembly, 
				new StringKeySequence("Resources", "Icons")));
		}
		public void Generate(IInstancePool instancePool)
		{
			if (instancePool == null)
			{
				throw new ArgumentNullException(nameof(instancePool));
			}

			var listingTypes = new List<Type>();

			listingTypes.Add(typeof(Fractions));
			listingTypes.Add(typeof(BuildingRestrictions));
			listingTypes.Add(typeof(Fertilities));
			listingTypes.Add(typeof(WaterResources));
			listingTypes.Add(typeof(MountainResources));
			listingTypes.Add(typeof(ConstructionMaterials));
			listingTypes.Add(typeof(WarfareMaterials));
			listingTypes.Add(typeof(RawMaterials));
			listingTypes.Add(typeof(ConsumableGoods));
			listingTypes.Add(typeof(Buildings));
			listingTypes.Add(typeof(ProductionChains));
			listingTypes.Add(typeof(PopulationGroups));

			foreach (var listingType in listingTypes)
			{
				foreach (var field in listingType.GetFields(BindingFlags.Public | BindingFlags.Static))
				{
					instancePool.Register((Persistable)field.GetValue(null));
				}
			}
		}
	}
}
