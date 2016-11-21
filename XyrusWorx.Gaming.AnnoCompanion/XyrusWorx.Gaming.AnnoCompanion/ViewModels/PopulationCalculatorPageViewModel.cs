using System.Collections.Generic;
using System.Linq;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class PopulationCalculatorPageViewModel : PageViewModel
	{
		private IEnumerable<ProductionChainComponentViewModel> mRequiredProductionChainComponents;
		private IEnumerable<FactionViewModel> mFactions;

		public PopulationCalculatorPageViewModel()
		{
			Factions = new[]
			{
				new FactionViewModel {Faction = ObjectModel.Factions.Occident, Owner = this, DisplayName = "Okzident"},
				new FactionViewModel {Faction = ObjectModel.Factions.Orient, Owner = this, DisplayName = "Orient"},
				new FactionViewModel {Faction = ObjectModel.Factions.Lawless, Owner = this, DisplayName = "Gesetzlose"}
			};
		}

		public override string Header => "Bevölkerungsrechner";
		public override int SortIndex => 2;

		public IEnumerable<FactionViewModel> Factions
		{
			get { return mFactions; }
			private set
			{
				if (Equals(value, mFactions)) return;
				mFactions = value;
				OnPropertyChanged();
			}
		}
		public IEnumerable<ProductionChainComponentViewModel> RequiredProductionChainComponents
		{
			get { return mRequiredProductionChainComponents.Distinct(new ExpressionComparer<ProductionChainComponentViewModel>(x => x.Model.Building)); }
			private set
			{
				if (Equals(value, mRequiredProductionChainComponents)) return;
				mRequiredProductionChainComponents = value;
				OnPropertyChanged();
			}
		}

		public void UpdateValues()
		{
			RequiredProductionChainComponents = Factions
				.SelectMany(x => x.CollectRequiredProductionChainComponents())
				.OrderBy(x => x.SortIndex)
				.ToArray();

			foreach (var faction in Factions)
			{
				faction.UpdateTurnaroundThresholds(mRequiredProductionChainComponents);
			}
		}
	}
}