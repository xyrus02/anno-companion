using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class FactionViewModel : CollectionViewModel<PopulationGroupViewModel>
	{
		private Factions mFaction;

		public FactionViewModel()
		{
			Items = new ObservableCollection<PopulationGroupViewModel>();
		}

		public PopulationCalculatorPageViewModel Owner { get; set; }
		public override IList<PopulationGroupViewModel> Items { get; }

		public Factions Faction
		{
			get { return mFaction; }
			set
			{
				mFaction = value;
				OnPropertyChanged();

				var groups =
					from populationGroup in PopulationGroups.GetAll()
					let sortTier =
						populationGroup.Tier == 0 ? 1 :
						populationGroup.Tier == 1 ? 0 :
						populationGroup.Tier
					orderby sortTier ascending 
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
	}
}