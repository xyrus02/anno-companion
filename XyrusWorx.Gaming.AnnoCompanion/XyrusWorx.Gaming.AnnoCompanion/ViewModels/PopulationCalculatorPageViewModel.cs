﻿using System.Collections.Generic;
using System.Linq;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class PopulationCalculatorPageViewModel : PageViewModel
	{
		private IEnumerable<BuildingViewModel> mRequirements;
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
		public IEnumerable<BuildingViewModel> Requirements
		{
			get { return mRequirements?.Distinct(new ExpressionComparer<BuildingViewModel>(x => x.Model)); }
			private set
			{
				if (Equals(value, mRequirements)) return;
				mRequirements = value;
				OnPropertyChanged();
			}
		}

		public void UpdateValues()
		{
			Requirements = Factions
				.SelectMany(x => x.CollectBuildingRequirements())
				.OrderBy(x => x.SortIndex)
				.ToArray();

			foreach (var faction in Factions)
			{
				faction.UpdateTurnaroundThresholds(mRequirements);
			}
		}
	}
}