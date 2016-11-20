using System;
using System.Collections.Generic;
using System.Linq;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class PopulationCalculatorPageViewModel : PageViewModel
	{
		private IEnumerable<ProductionChainComponentViewModel> mRequiredProductionChainComponents;

		public PopulationCalculatorPageViewModel()
		{
			Occident = new FactionViewModel { Faction = Factions.Occident, Owner = this };
			Orient = new FactionViewModel { Faction = Factions.Orient, Owner = this };
		}

		public override string Header => "Bevölkerungsrechner";
		public override int SortIndex => 2;

		public FactionViewModel Occident { get; }
		public FactionViewModel Orient { get; }

		public IEnumerable<ProductionChainComponentViewModel> RequiredProductionChainComponents
		{
			get { return mRequiredProductionChainComponents; }
			private set
			{
				if (Equals(value, mRequiredProductionChainComponents)) return;
				mRequiredProductionChainComponents = value;
				OnPropertyChanged();
			}
		}

		public void UpdateValues()
		{
			RequiredProductionChainComponents = 
				new[]
					{
						GetProductionChains(Occident),
						GetProductionChains(Orient)
					}
				.SelectMany(x => x)
				.OrderBy(x => x.SortIndex);

			UpdateTurnaroundThresholds(Occident);
			UpdateTurnaroundThresholds(Orient);
		}

		private void UpdateTurnaroundThresholds(FactionViewModel faction)
		{
			var allProductionChains = RequiredProductionChainComponents
				.Select(x => x.ProductionChain)
				.Distinct();

			var factionGroups = faction.Items.ToDictionary(x => x.Model);
			var chainCounts = RequiredProductionChainComponents.Select(x => x.ProductionChain).Distinct().ToDictionary(x => x.Model, x => x.Count);

			var capacities =
				from populationGroup in PopulationGroups.GetAll().Where(x => x.Faction == faction.Faction)

				let groupChains = allProductionChains.Where(chain => populationGroup.Key == chain.OutputGood
					.CastTo<ConsumableGood>()?
					.ConsumingPopulationGroups?
					.OrderBy(x => x.Tier)
					.FirstOrDefault(x => x.Tier > 0)?
					.Key)

				let provisionCapacities = groupChains
					.SelectMany(chain => (chain.Model?.ProvisionCapacities ?? new ProvisionCapacity[0]).Select(capacityThreshold => new
					{
						capacityThreshold.PopulationGroup,
						Count = capacityThreshold.Count * chainCounts[chain.Model]
					}))
					.Where(x => x.PopulationGroup?.Key == populationGroup.Key)

				select new
				{
					PopulationGroup = populationGroup,
					Capacity = provisionCapacities.OrderBy(x => x.Count).FirstOrDefault()?.Count ?? 0
				};

			var capacityToCount = capacities.ToDictionary(x => x.PopulationGroup);

			foreach (var group in capacityToCount.Keys)
			{
				var viewModel = factionGroups.GetValueByKeyOrDefault(group);
				if (viewModel == null)
				{
					continue;
				}

				viewModel.TurnaroundThreshold = capacityToCount[group].Capacity;
			}

		}
		private IEnumerable<ProductionChainComponentViewModel> GetProductionChains(FactionViewModel faction)
		{
			var maximumTier = faction.Items.Where(x => x.Count > 0).OrderByDescending(x => x.Model?.Tier ?? -1).FirstOrDefault()?.Model?.Tier ?? -1;
			if (maximumTier < 0)
			{
				yield break;
			}

			var groupCounts = faction.Items.ToDictionary(x => x.Key, x => x.Count);

			var chains =
				from chain in ProductionChains.GetAll()

				let goodIsConsumable = chain.OutputGood is ConsumableGood

				let isProvisionedToCurrentTier = chain.ProvisionCapacities != null && chain.ProvisionCapacities.Any(x => 
					x.PopulationGroup.Tier <= maximumTier && 
					x.PopulationGroup.Faction == faction.Faction)

				let isUnlockedWithCurrentPopulationCount = 
					groupCounts.GetValueByKeyOrDefault(chain.OutputGood.UnlockThreshold.PopulationGroup.Key) >= 
					chain.OutputGood.UnlockThreshold.Count

				let wasUnlockedWithLowerThanCurrentTier = chain.OutputGood.UnlockThreshold.PopulationGroup.Tier < maximumTier

				where (goodIsConsumable && isProvisionedToCurrentTier)
				where (isUnlockedWithCurrentPopulationCount || wasUnlockedWithLowerThanCurrentTier)

				orderby chain.Components.Min(x => x.Building.Output.UnlockThreshold.PopulationGroup.Tier)

				select chain;

			var chainSortIndex = 0;

			foreach (var chain in chains)
			{
				var chainCount = 0;
				var chainViewModel = new ProductionChainViewModel
				{
					Model = chain
				};

				chainSortIndex += 100;

				foreach (var groupCapacity in chain.ProvisionCapacities)
				{
					chainCount += (int)Math.Ceiling(groupCounts[groupCapacity.PopulationGroup.Key] / (double) groupCapacity.Count);
				}

				chainViewModel.Count = chainCount;

				var componentSortIndex = 0;

				foreach (var component in chain.Components)
				{
					var componentViewModel = new ProductionChainComponentViewModel
					{
						Model = component,
						Count = component.Count * chainCount,
						ProductionChain = chainViewModel
					};

					componentSortIndex += 1;

					componentViewModel.SortIndex = chainSortIndex + componentSortIndex;

					yield return componentViewModel;
				}
			}
		}
	}
}