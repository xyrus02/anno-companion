using System.Linq;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainListViewModel : SearchableCollectionViewModel<ProductionChainViewModel>
	{
		private bool mSearchComponents;

		public ProductionChainListViewModel()
		{
			AutomaticallyUpdateSearchResults = true;
		}

		public bool SearchComponents
		{
			get { return mSearchComponents; }
			set
			{
				if (value == mSearchComponents) return;
				mSearchComponents = value;
				OnPropertyChanged();
				BeginUpdate();
			}
		}

		protected override bool IsVisible(ProductionChainViewModel element)
		{
			return Expression.IsMatch(element.DisplayName) || (SearchComponents && element.Components.Items.Any(x => Expression.IsMatch(x.ProductionBuildingDisplayName)));
		}
		private async void BeginUpdate() => await UpdateVisibleItems();
	}
}