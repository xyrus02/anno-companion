using System;
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
			InputDelay = TimeSpan.FromMilliseconds(500);
		}

		public bool SearchComponents
		{
			get { return mSearchComponents; }
			set
			{
				if (value == mSearchComponents) return;
				mSearchComponents = value;
				OnPropertyChanged();

				if (!string.IsNullOrWhiteSpace(SearchString))
				{
					BeginUpdateSearchResults();
				}
			}
		}

		protected override bool IsVisible(ProductionChainViewModel element)
		{
			return Expression.IsMatch(element.DisplayName) || (SearchComponents && element.Components.Items.Any(x => Expression.IsMatch(x.ProductionBuildingDisplayName)));
		}
		private async void BeginUpdate() => await UpdateVisibleItems();
	}
}