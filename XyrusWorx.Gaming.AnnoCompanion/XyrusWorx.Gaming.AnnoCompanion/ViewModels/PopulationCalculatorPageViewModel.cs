using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Windows.Input;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class PopulationCalculatorPageViewModel : PageViewModel
	{
		private readonly IDataProvider mRepository;
		private readonly Dispatcher mDispatcher;

		public PopulationCalculatorPageViewModel()
		{
			Fractions = new List<FractionViewModel>();
			Requirements = new ObservableCollection<BuildingViewModel>();

			ResetAllCommand = new RelayCommand(ResetAll);
		}
		public PopulationCalculatorPageViewModel(IDataProvider repository, Dispatcher dispatcher) : this()
		{
			mRepository = repository;
			mDispatcher = dispatcher;
			Fractions.AddRange(
				from fraction in repository?.GetAll<Fraction>() ?? new Fraction[0]
				orderby fraction.SortOrder ascending
				let viewModel = new FractionViewModel(repository)
				{
					Owner = this,
					Model = fraction
				}
				select viewModel);
		}

		public ICommand ResetAllCommand { get; }
		public void ResetAll()
		{
			Fractions?.Foreach(x => x.Items.Foreach(y => y.Count = 0));
		}

		public override string Header => "Bevölkerungsrechner";
		public override int SortIndex => 2;

		public IList<FractionViewModel> Fractions { get; }
		public IList<BuildingViewModel> Requirements { get; }

		[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
		public async void UpdateValues()
		{
			var requirements =
				from fraction in Fractions
				from requirement in CollectBuildingRequirements(fraction)
				orderby requirement.SortIndex
				select requirement;
			
			await Task.Run(() =>
			{
				mDispatcher?.Invoke(() => Requirements.Reset(requirements.Distinct(new ExpressionComparer<BuildingViewModel>(x => x.Model))));

				foreach (var fraction in Fractions)
				{
					UpdateTurnaroundThresholds(fraction, requirements);
				}
			});
		}

		private void UpdateTurnaroundThresholds(FractionViewModel fraction, IEnumerable<BuildingViewModel> buildings)
		{
			if (fraction == null)
			{
				return;
			}

			if (buildings == null)
			{
				return;
			}

			var componentArray = buildings.AsArray();

			var allProductionChains = componentArray
				.Select(x => x.ProductionChain).Where(x => x != null)
				.Distinct(new ExpressionComparer<ProductionChainViewModel>(x => x.Model))
				.ToArray();

			var factionGroups = fraction.Items.ToDictionary(x => x.Model);
			var chainCounts = allProductionChains.ToDictionary(x => x.Model, x => x.Count);

			var capacities =
				from populationGroup in mRepository.GetAll<PopulationGroup>()
				where populationGroup.Fraction == fraction.Model

				let groupChains =
					from chain in allProductionChains

					let consumable = chain.OutputGood as ConsumableGood
					where consumable != null
					let consumingGroups = consumable.ProvisionCapacities

					let orderedConsumerGroups =
						from consumingGroup in consumingGroups
						where consumingGroup.PopulationGroup.Fraction == fraction.Model
						orderby consumingGroup.PopulationGroup.Tier
						select consumingGroup.PopulationGroup

					let principalGroup = orderedConsumerGroups.FirstOrDefault()
					where principalGroup != null
					where principalGroup == populationGroup
					select chain

				let provisionCapacities =
					from chain in groupChains

					let consumable = chain.OutputGood as ConsumableGood
					where consumable != null
					let provisionCapacities = consumable.ProvisionCapacities

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
		private IEnumerable<BuildingViewModel> CollectBuildingRequirements(FractionViewModel fraction)
		{
			if (fraction == null)
			{
				yield break;
			}

			var maximumTier = fraction.Items.Where(x => x.Count > 0).OrderByDescending(x => x.Model?.Tier ?? -1).FirstOrDefault()?.Model?.Tier ?? -1;
			if (maximumTier < 0)
			{
				yield break;
			}

			var groupCounts = fraction.Items.ToDictionary(x => x.Key, x => x.Count);

			var chains =
				from chain in mRepository?.GetAll<ProductionChain>() ?? new ProductionChain[0]

				let consumable = chain.OutputGood as ConsumableGood
				where consumable != null

				let isProvisionedToCurrentTier = consumable.ProvisionCapacities.Any(x =>
					x.PopulationGroup.Tier <= maximumTier &&
					x.PopulationGroup.Fraction == fraction.Model)

				let isUnlockedWithCurrentPopulationCount =
					groupCounts.GetValueByKeyOrDefault(chain.OutputBuilding.UnlockThreshold.PopulationGroup.Key) >=
					chain.OutputBuilding.UnlockThreshold.Count

				let wasUnlockedWithLowerThanCurrentTier = chain.OutputBuilding.UnlockThreshold.PopulationGroup.Tier < maximumTier

				where isProvisionedToCurrentTier
				where isUnlockedWithCurrentPopulationCount || wasUnlockedWithLowerThanCurrentTier || (fraction.Model?.Passive ?? false)

				orderby chain.Components.Min(x => x.Building.UnlockThreshold.PopulationGroup.Tier)

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

				var consumable = chain.OutputGood as ConsumableGood;
				if (consumable == null)
				{
					continue;
				}

				foreach (var groupCapacity in consumable.ProvisionCapacities)
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