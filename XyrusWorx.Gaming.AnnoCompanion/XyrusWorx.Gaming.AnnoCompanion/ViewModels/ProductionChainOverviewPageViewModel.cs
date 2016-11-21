using System.Windows.Input;
using XyrusWorx.Collections;
using XyrusWorx.Windows.Input;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainOverviewPageViewModel : PageViewModel
	{
		private bool mIsGrouped = true;

		public override string Header => "Produktionsketten";
		public override int SortIndex => 1;

		public ProductionChainOverviewPageViewModel()
		{
			ResetAllCommand = new RelayCommand(ResetAll);
		}

		public ICommand ResetAllCommand { get; }
		public void ResetAll()
		{
			ProductionChains.Items.Foreach(x => x.Count = 1);
		}

		public ProductionChainOverviewPageViewModel(ProductionChainListViewModel list) : this()
		{
			ProductionChains = list;
		}

		public ProductionChainListViewModel ProductionChains { get; }

		public bool IsGrouped
		{
			get { return mIsGrouped; }
			set
			{
				if (value == mIsGrouped) return;
				mIsGrouped = value;
				OnPropertyChanged();
			}
		}

		public override void Load()
		{
			if (ProductionChains == null)
			{
				return;
			}

			foreach (var productionChain in ObjectModel.ProductionChains.GetAll())
			{
				ProductionChains.Items.Add(new ProductionChainViewModel
				{
					Model = productionChain,
					IsVisible = true
				});
			}
		}
	}
}