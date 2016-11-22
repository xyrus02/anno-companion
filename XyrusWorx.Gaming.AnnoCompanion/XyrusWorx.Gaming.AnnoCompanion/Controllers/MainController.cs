using XyrusWorx.Gaming.AnnoCompanion.Data;
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
			ServiceLocator.Default.Register(new Repository());
		}

		public MainView View => GetView<MainView>();
		public MainViewModel ViewModel => GetViewModel<MainViewModel>();

		protected override void OnInitialize()
		{
			var repo = new Repository();

			repo.Clear();
			repo.LoadStatic();
			repo.Export(@"D:\Code\XyrusWorx Collaboration\AnnoCompanion\XyrusWorx.Gaming.AnnoCompanion\XyrusWorx.Gaming.AnnoCompanion\Data");

			repo.Clear();
			repo.Import(@"D:\Code\XyrusWorx Collaboration\AnnoCompanion\XyrusWorx.Gaming.AnnoCompanion\XyrusWorx.Gaming.AnnoCompanion\Data");

			ViewModel.Load();
		}
	}
}
