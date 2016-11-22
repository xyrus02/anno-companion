﻿using System.Collections.Generic;
using System.Linq;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class PopulationCalculatorPageViewModel : PageViewModel
	{
		private IEnumerable<BuildingViewModel> mRequirements;
		private IEnumerable<FractionViewModel> mFractions;

		public PopulationCalculatorPageViewModel() { }
		public PopulationCalculatorPageViewModel(IDataProvider repository) : this()
		{
			Fractions = new List<FractionViewModel>(
				from fraction in repository?.GetAll<Fraction>() ?? new Fraction[0]
				orderby fraction.SortOrder ascending 
				let viewModel = new FractionViewModel(repository)
				{
					Model = fraction,
					Owner = this
				}
				select viewModel);
		}

		public override string Header => "Bevölkerungsrechner";
		public override int SortIndex => 2;

		public IEnumerable<FractionViewModel> Fractions
		{
			get { return mFractions; }
			private set
			{
				if (Equals(value, mFractions)) return;
				mFractions = value;
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
			Requirements = Fractions
				.SelectMany(x => x.CollectBuildingRequirements())
				.OrderBy(x => x.SortIndex)
				.ToArray();

			foreach (var faction in Fractions)
			{
				faction.UpdateTurnaroundThresholds(mRequirements);
			}
		}
	}
}