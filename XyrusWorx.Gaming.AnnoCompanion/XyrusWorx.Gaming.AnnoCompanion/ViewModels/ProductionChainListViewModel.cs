using System.Linq;
using JetBrains.Annotations;
using XyrusWorx.MVVM;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainListViewModel : SearchableCollectionViewModel<ProductionChainViewModel>
	{
		private bool mSearchComponents;

		public ProductionChainListViewModel()
		{
			Selection = new SelectionViewModel<ProductionChainViewModel>(this);
			AutomaticallyUpdateSearchResults = true;
		}

		[NotNull]
		public SelectionViewModel<ProductionChainViewModel> Selection { get; }

		public bool SearchComponents
		{
			get { return mSearchComponents; }
			set
			{
				if (value == mSearchComponents) return;
				mSearchComponents = value;
				OnPropertyChanged();
				UpdateVisibleItems();
			}
		}

		protected override bool IsVisible(ProductionChainViewModel element)
		{
			return Expression.IsMatch(element.DisplayName) || (SearchComponents && element.Components.Items.Any(x => Expression.IsMatch(x.ProductionBuildingDisplayName)));
		}
	}
}