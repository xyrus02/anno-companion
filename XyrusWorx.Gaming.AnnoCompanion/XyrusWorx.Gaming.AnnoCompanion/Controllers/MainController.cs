using XyrusWorx.Gaming.AnnoCompanion.ViewModels;
using XyrusWorx.Gaming.AnnoCompanion.Views;
using XyrusWorx.Runtime;
using XyrusWorx.Windows.Runtime;

namespace XyrusWorx.Gaming.AnnoCompanion.Controllers
{
	class MainController : ApplicationController
	{
		public MainController()
		{
			ServiceLocator.Default.Register<ApplicationController>(this);
		}

		public MainView View => GetView<MainView>();
		public MainViewModel ViewModel => GetViewModel<MainViewModel>();
	}
}
