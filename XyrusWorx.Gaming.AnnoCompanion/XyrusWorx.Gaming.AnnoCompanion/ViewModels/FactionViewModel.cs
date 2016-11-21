using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class FactionViewModel : CollectionViewModel<PopulationGroupViewModel>
	{
		private Factions mFaction;
		private string mDisplayName;

		public FactionViewModel()
		{
			Items = new ObservableCollection<PopulationGroupViewModel>();
		}

		public PopulationCalculatorPageViewModel Owner { get; set; }
		public override IList<PopulationGroupViewModel> Items { get; }

		public string DisplayName
		{
			get { return mDisplayName; }
			set
			{
				if (value == mDisplayName) return;
				mDisplayName = value;
				OnPropertyChanged();
			}
		}
		public Factions Faction
		{
			get { return mFaction; }
			set
			{
				mFaction = value;
				OnPropertyChanged();

				var groups =
					from populationGroup in PopulationGroups.GetAll()
					orderby populationGroup.Tier ascending 
					where populationGroup.Faction == mFaction
					select new PopulationGroupViewModel()
					{
						Model = populationGroup,
						Owner = this
					};

				Items.Reset(groups);
			}
		}

		public void UpdateValues() => Owner.UpdateValues();
		public void UpdateTurnaroundThresholds([NotNull] IEnumerable<BuildingViewModel> buildings)
		{
			if (buildings == null)
			{
				throw new ArgumentNullException(nameof(buildings));
			}

			var componentArray = buildings.AsArray();

			var allProductionChains = componentArray
				.Select(x => x.ProductionChain).Where(x => x != null)
				.Distinct(new ExpressionComparer<ProductionChainViewModel>(x => x.Model))
				.ToArray();

			var factionGroups = Items.ToDictionary(x => x.Model);
			var chainCounts = allProductionChains.ToDictionary(x => x.Model, x => x.Count);

			var capacities =
				from populationGroup in PopulationGroups.GetAll()
				where populationGroup.Faction == Faction

				let groupChains = 
					from chain in allProductionChains

					let consumable = chain.OutputGood as ConsumableGood where consumable != null
					let consumingGroups = consumable.ConsumingPopulationGroups where consumingGroups != null

					let orderedConsumerGroups = 
						from consumingGroup in consumingGroups
						where consumingGroup.Faction == Faction
						orderby consumingGroup.Tier
						select consumingGroup

					let principalGroup = orderedConsumerGroups.FirstOrDefault() where principalGroup != null
					where principalGroup == populationGroup
					select chain

				let provisionCapacities = 
					from chain in groupChains

					let provisionCapacities = chain.Model?.ProvisionCapacities where provisionCapacities != null

					from provisionCapacity in provisionCapacities
					select new
					{
						provisionCapacity.PopulationGroup,
						Count = provisionCapacity.Count * chainCounts.GetValueByKeyOrDefault(chain.Model)
					}

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

		public IEnumerable<BuildingViewModel> CollectBuildingRequirements()
		{
			var maximumTier = Items.Where(x => x.Count > 0).OrderByDescending(x => x.Model?.Tier ?? -1).FirstOrDefault()?.Model?.Tier ?? -1;
			if (maximumTier < 0)
			{
				yield break;
			}

			var groupCounts = Items.ToDictionary(x => x.Key, x => x.Count);

			var chains =
				from chain in ProductionChains.GetAll()

				let goodIsConsumable = chain.OutputGood is ConsumableGood

				let isProvisionedToCurrentTier = chain.ProvisionCapacities != null && chain.ProvisionCapacities.Any(x =>
					x.PopulationGroup.Tier <= maximumTier &&
					x.PopulationGroup.Faction == Faction)

				let isUnlockedWithCurrentPopulationCount =
					groupCounts.GetValueByKeyOrDefault(chain.OutputGood.UnlockThreshold.PopulationGroup.Key) >=
					chain.OutputGood.UnlockThreshold.Count

				let wasUnlockedWithLowerThanCurrentTier = chain.OutputGood.UnlockThreshold.PopulationGroup.Tier < maximumTier

				let isUnlockedImplicitly = Faction == Factions.Lawless

				where (goodIsConsumable && isProvisionedToCurrentTier)
				where (isUnlockedWithCurrentPopulationCount || wasUnlockedWithLowerThanCurrentTier || isUnlockedImplicitly)

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
					chainCount += (int)Math.Ceiling(groupCounts.GetValueByKeyOrDefault(groupCapacity.PopulationGroup.Key) / (double)groupCapacity.Count);
				}

				chainViewModel.Count = chainCount;

				var componentSortIndex = 0;

				foreach (var component in chain.Components)
				{
					var buildingViewModel = new BuildingViewModel
					{
						Model = component.Building,
						Count = component.Count * chainCount,
						ProductionChain = chainViewModel
					};

					componentSortIndex += 1;

					buildingViewModel.SortIndex = chainSortIndex + componentSortIndex;

					yield return buildingViewModel;
				}
			}
		}
	}
}