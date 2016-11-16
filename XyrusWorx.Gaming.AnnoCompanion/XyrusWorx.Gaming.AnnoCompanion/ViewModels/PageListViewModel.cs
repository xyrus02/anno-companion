using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XyrusWorx.MVVM;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	sealed class PageListViewModel : CollectionViewModel<PageViewModel>
	{
		public PageListViewModel()
		{
			Items = new ObservableCollection<PageViewModel>();
			Selection = new SelectionViewModel<PageViewModel>(this);
		}

		public SelectionViewModel<PageViewModel> Selection { get; }
		public override IList<PageViewModel> Items { get; }

		public T Get<T>() where T : PageViewModel => Items.OfType<T>().FirstOrDefault();
	}
}