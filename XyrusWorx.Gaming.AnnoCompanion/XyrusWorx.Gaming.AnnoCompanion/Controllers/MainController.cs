using System.IO;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Gaming.AnnoCompanion.Models.Generator;
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
			var repository = new Repository(typeof(Depletable).Assembly);

			ServiceLocator.Default.Register<ApplicationController>(this);

			ServiceLocator.Default.Register<IDataProvider>(repository);
			ServiceLocator.Default.Register<IIconResolverFactory>(repository);
			ServiceLocator.Default.Register<IInstancePoolFactory>(repository);
		}

		public MainView View => GetView<MainView>();
		public MainViewModel ViewModel => GetViewModel<MainViewModel>();

		protected override void OnInitialize()
		{
			const string dataDirectoryName = "Data";
			const string iconsDirectoryName = "Icons";

			var dataProvider = ServiceLocator.Default.Resolve<IDataProvider>();
			var instancePoolFactory = ServiceLocator.Default.Resolve<IInstancePoolFactory>();
			var iconResolverFactory = ServiceLocator.Default.Resolve<IIconResolverFactory>();

			var shouldExport = !WorkingDirectory.HasChildStore(dataDirectoryName);
			var dataDirectory = WorkingDirectory.GetChildStore(dataDirectoryName);

			if (shouldExport)
			{
				ModelGenerator.Generate(instancePoolFactory.GetInstancePool());
				dataProvider.Export(dataDirectory);
			}

			var iconResolver = iconResolverFactory.GetIconResolver();

			iconResolver.AddExternalDataSource(new EmbeddedBlobStore(
				typeof(Depletable).Assembly, 
				new StringKeySequence("Resources", iconsDirectoryName)));
			iconResolver.AddExternalDataSource(dataDirectory.GetChildStore(iconsDirectoryName));

			try
			{
				dataProvider.Clear();
				dataProvider.Import(dataDirectory);
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
