using System.Windows.Input;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Windows.Input;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainOverviewPageViewModel : PageViewModel
	{
		private bool mIsGrouped = true;
		private readonly IDataProvider mRepository;

		public override string Header => "Produktionsketten";
		public override int SortIndex => 1;

		public ProductionChainOverviewPageViewModel() 
		{
			ResetAllCommand = new RelayCommand(ResetAll);
		}
		public ProductionChainOverviewPageViewModel(ProductionChainListViewModel list, IDataProvider repository) : this()
		{
			ProductionChains = list;
			mRepository = repository;
		}

		public ICommand ResetAllCommand { get; }
		public void ResetAll()
		{
			ProductionChains.Items.Foreach(x => x.Count = 1);
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

			foreach (var productionChain in mRepository.GetAll<ProductionChain>())
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