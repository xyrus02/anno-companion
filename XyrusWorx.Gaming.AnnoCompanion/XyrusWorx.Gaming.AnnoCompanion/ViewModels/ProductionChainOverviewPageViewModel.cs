using System.Linq;
using XyrusWorx.Gaming.AnnoCompanion.ObjectModel;
using XyrusWorx.Runtime;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainOverviewPageViewModel : PageViewModel
	{
		public override string Header => "Produktionsketten";
		public override int SortIndex => 1;

		public ProductionChainOverviewPageViewModel()
		{
		}
		public ProductionChainOverviewPageViewModel(ProductionChainListViewModel list) : this()
		{
			ProductionChains = list;
		}

		public ProductionChainListViewModel ProductionChains { get; }

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