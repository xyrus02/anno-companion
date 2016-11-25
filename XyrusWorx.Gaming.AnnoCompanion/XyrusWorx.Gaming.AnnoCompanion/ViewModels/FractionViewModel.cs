using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class FractionViewModel : CollectionViewModel<PopulationGroupViewModel>
	{
		private readonly IDataProvider mRepository;
		private Fraction mModel;

		public FractionViewModel() { }
		public FractionViewModel(IDataProvider repository) : this()
		{
			mRepository = repository;
			Items = new ObservableCollection<PopulationGroupViewModel>();
		}

		public PopulationCalculatorPageViewModel Owner { get; set; }
		public override IList<PopulationGroupViewModel> Items { get; }

		public string DisplayName => Model?.DisplayName;

		public Fraction Model
		{
			get { return mModel; }
			set
			{
				mModel = value;
				OnPropertyChanged();

				var groups =
					from populationGroup in mRepository?.GetAll<PopulationGroup>() ?? new PopulationGroup[0]
					orderby populationGroup.Tier ascending 
					where populationGroup.Fraction == mModel
					select new PopulationGroupViewModel
					{
						Model = populationGroup,
						Owner = Owner
					};

				Items.Reset(groups);
			}
		}
	}
}