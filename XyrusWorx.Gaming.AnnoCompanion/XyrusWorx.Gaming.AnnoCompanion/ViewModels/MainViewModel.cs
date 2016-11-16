using System.Linq;
using XyrusWorx.Collections;
using XyrusWorx.MVVM;
using XyrusWorx.Runtime;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class MainViewModel : ViewModel
	{
		private PageListViewModel mPages;

		public MainViewModel()
		{
			var viewModelTypes =
				from type in typeof(MainViewModel).Assembly.GetTypes()
				where typeof(ViewModel).IsAssignableFrom(type)
				where !type.IsAbstract && !type.IsInterface
				where type != typeof(MainViewModel)
				select type;

			foreach (var type in viewModelTypes)
			{
				ServiceLocator.Default.Register(type);
			}

			ServiceLocator.Default.Register(this);
		}

		public PageListViewModel Pages
		{
			get { return mPages; }
			private set
			{
				if (Equals(value, mPages)) return;
				mPages = value;
				OnPropertyChanged();
			}
		}

		public void Load()
		{
			Pages = ServiceLocator.Default.Resolve<PageListViewModel>();

			Pages.Items.AddRange(
				from type in typeof(MainViewModel).Assembly.GetTypes()
				where typeof(PageViewModel).IsAssignableFrom(type)
				where !type.IsAbstract && !type.IsInterface
				let instance = (PageViewModel)ServiceLocator.Default.Resolve(type)
				orderby instance.SortIndex
				select instance);

			Pages.Selection.SelectFirst();

			foreach (var item in Pages.Items)
			{
				item.Load();
			}
		}
	}
}
