using System.Windows.Data;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.Views
{
	public partial class GroupedProductionChainListView
	{
		public GroupedProductionChainListView()
		{
			InitializeComponent();
		}

		// gk: todo in Behavior mit Conditons auslagern
		private void OnFilterCollectionViewSource(object sender, FilterEventArgs e)
		{
			var item = e.Item as IHideable;
			e.Accepted = item?.IsVisible ?? false;
		}
	}
}
