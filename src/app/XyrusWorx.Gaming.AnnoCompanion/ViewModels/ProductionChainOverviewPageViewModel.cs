using System.Linq;
using System.Windows.Input;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Runtime;
using XyrusWorx.Windows.Input;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	[Singleton]
	class ProductionChainOverviewPageViewModel : PageViewModel
	{
		private bool mIsGrouped = true;
		private readonly IDataProvider mRepository;

		public override string Header => "Produktionsketten";
		public override int SortIndex => 1;

		public ProductionChainOverviewPageViewModel(ProductionChainListViewModel list, IDataProvider repository)
		{
			ResetAllCommand = new RelayCommand(ResetAll);

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
			get => mIsGrouped;
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

			var productionChains =
				from item in mRepository?.GetAll<ProductionChain>() ?? new ProductionChain[0]
				let viewModel = new ProductionChainViewModel
				{
					Model = item,
					IsVisible = true
				}
				orderby string.IsNullOrWhiteSpace(viewModel.PrincipalPopulationGroup) ? 0 : 1 ascending
				orderby viewModel.SortIndex ascending
				select viewModel;

			foreach (var productionChain in productionChains)
			{
				ProductionChains.Items.Add(productionChain);
			}
		}
	}
}