using System.Windows.Data;
using XyrusWorx.Gaming.AnnoCompanion.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.Views
{
	public partial class ProductionChainOverviewPageView
	{
		public ProductionChainOverviewPageView()
		{
			InitializeComponent();
		}

		// gk: todo in Behavior mit Conditons auslagern
		private void OnFilterCollectionViewSource(object sender, FilterEventArgs e)
		{
			var item = e.Item as ProductionChainViewModel;
			e.Accepted = item?.IsVisible ?? false;
		}
	}
}
