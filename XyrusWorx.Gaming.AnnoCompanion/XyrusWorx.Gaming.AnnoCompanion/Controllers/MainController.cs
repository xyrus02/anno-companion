using System.IO;
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
			ServiceLocator.Default.Register<IDataProvider>(new Repository());
		}

		public MainView View => GetView<MainView>();
		public MainViewModel ViewModel => GetViewModel<MainViewModel>();

		protected override void OnInitialize()
		{
			const string dataDirectoryName = "Data";

			var repository = (Repository)ServiceLocator.Default.Resolve<IDataProvider>();
			var shouldExport = !WorkingDirectory.HasChildStore(dataDirectoryName);
			var dataDirectory = WorkingDirectory.GetChildStore(dataDirectoryName);

			if (shouldExport)
			{
				repository.Clear();
				repository.LoadStatic();
				repository.Export(dataDirectory);
			}
			
			try
			{
				repository.Clear();
				repository.Import(dataDirectory);
			}
			catch (InvalidDataException exception)
			{
				Dialog.Error(exception).Display();
				Shutdown(1);
			}

			ViewModel.Load();
		}
	}
}
