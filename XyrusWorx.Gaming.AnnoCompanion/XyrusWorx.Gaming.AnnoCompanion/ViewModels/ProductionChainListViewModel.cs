using JetBrains.Annotations;
using XyrusWorx.MVVM;
using XyrusWorx.Windows.ViewModels;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class ProductionChainListViewModel : SearchableCollectionViewModel<ProductionChainViewModel>
	{
		public ProductionChainListViewModel()
		{
			Selection = new SelectionViewModel<ProductionChainViewModel>(this);
		}

		[NotNull]
		public SelectionViewModel<ProductionChainViewModel> Selection { get;}

		protected override bool IsVisible(ProductionChainViewModel element)
		{
			return Expression.IsMatch(element.DisplayName);
		}
	}
}