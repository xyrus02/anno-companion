using System.Linq;
using XyrusWorx.MVVM;
using XyrusWorx.Runtime;

namespace XyrusWorx.Gaming.AnnoCompanion.ViewModels
{
	class MainViewModel : ViewModel
	{
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
	}
}
