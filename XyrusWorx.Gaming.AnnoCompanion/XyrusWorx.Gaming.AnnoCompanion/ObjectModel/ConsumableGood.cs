using System;
using System.Linq;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class ConsumableGood : Good
	{
		private ProvisionCapacity[] mProvisionCapacities;

		public ProvisionCapacity[] ProvisionCapacities
		{
			get { return mProvisionCapacities ?? new ProvisionCapacity[0]; }
			set { mProvisionCapacities = value; }
		}

		public double GetConsumptionRate([NotNull] PopulationGroup populationGroup)
		{
			if (populationGroup == null)
			{
				throw new ArgumentNullException(nameof(populationGroup));
			}

			var capacityPerProductionChain = ProvisionCapacities.FirstOrDefault(x => x.PopulationGroup == populationGroup)?.Count;
			var productionChain = ProductionChains.GetByGood(this);

			if (productionChain == null || capacityPerProductionChain == null)
			{
				return 0;
			}

			var endpoint = productionChain.Components.FirstOrDefault(x => x.Building.Output.Good == this);
			if (endpoint == null)
			{
				return 0;
			}

			return endpoint.Count * endpoint.Building.ProductionPerMinute / capacityPerProductionChain.Value;
		}
	}
}