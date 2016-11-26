using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Gaming.AnnoCompanion.Models;
using XyrusWorx.Gaming.AnnoCompanion.ViewModels;
using XyrusWorx.Gaming.AnnoCompanion.Views;
using XyrusWorx.Runtime;
using XyrusWorx.Windows;
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
			var dataProvider = ServiceLocator.Default.Resolve<IDataProvider>();
			var instancePoolFactory = ServiceLocator.Default.Resolve<IInstancePoolFactory>();
			var iconResolverFactory = ServiceLocator.Default.Resolve<IIconResolverFactory>();

			var instancePool = instancePoolFactory.GetInstancePool();
			var iconResolver = iconResolverFactory.GetIconResolver();

			var objectStores = GetAvailableObjectStores(instancePool, dataProvider);
			var objectStore = SelectObjectStore(objectStores);

			if (objectStore == null)
			{
				Dialog.Error("Es stehen keine Profile zur Verfügung.").Display();
				Shutdown(1);
			}

			try
			{
				LoadObjectStore(dataProvider, iconResolver, objectStore);
			}
			catch (InvalidDataException exception)
			{
				Dialog.Error(exception).Display();
				Shutdown(1);
			}

			ViewModel.Profile = objectStore;
			ViewModel.Load();
		}

		private void LoadObjectStore(
			[NotNull] IDataProvider dataProvider,
			[NotNull] IIconResolver iconResolver, 
			[NotNull] ObjectStoreModel objectStore)
		{
			if (dataProvider == null)
			{
				throw new ArgumentNullException(nameof(dataProvider));
			}

			if (iconResolver == null)
			{
				throw new ArgumentNullException(nameof(iconResolver));
			}

			if (objectStore == null)
			{
				throw new ArgumentNullException(nameof(objectStore));
			}

			var profile = objectStore as ProfileModel;
			if (profile != null)
			{
				var basePreset = profile.BasedOn;
				if (basePreset != null)
				{
					basePreset.Load(dataProvider);
					if (basePreset.IconStore != null)
					{
						iconResolver.AddExternalDataSource(basePreset.IconStore);
					}
				}

				if (profile.IconStore != null)
				{
					iconResolver.AddExternalDataSource(profile.IconStore);
				}

				profile.Load(dataProvider);
			}
			else
			{
				if (objectStore.IconStore != null)
				{
					iconResolver.AddExternalDataSource(objectStore.IconStore);
				}

				objectStore.Load(dataProvider);
			}
		}
		private ObjectStoreModel SelectObjectStore(IList<ObjectStoreModel> objectStores)
		{
			ObjectStoreModel objectStore = null;

			if (objectStores.Count == 1)
			{
				objectStore = objectStores.First();
			}
			else if (objectStores.Count > 1)
			{
				objectStore = Execution.ExecuteOnUiThread(() =>
				{
					var window = new ProfileSelectionView();
					var selectionViewModel = new ProfileSelectionViewModel();

					selectionViewModel.Items.Reset(objectStores);
					window.DataContext = selectionViewModel;

					var result = window.ShowDialog();
					if (result == null || result == false)
					{
						Shutdown(0);
					}

					return selectionViewModel.Selection.SelectedItem;
				});
			}

			return objectStore;
		}

		private IList<ObjectStoreModel> GetAvailableObjectStores(
			[NotNull] IInstancePool instancePool, 
			[NotNull] IDataProvider dataProvider)
		{
			if (instancePool == null)
			{
				throw new ArgumentNullException(nameof(instancePool));
			}

			if (dataProvider == null)
			{
				throw new ArgumentNullException(nameof(dataProvider));
			}

			const string profileDirectoryName = "Profiles";

			var profileDirectory = WorkingDirectory.GetChildStore(profileDirectoryName, true);
			var generators = GetModelGenerators().AsList();
			var objectStores = new List<ObjectStoreModel>();

			foreach (var generator in generators)
			{
				var profileModel = new PresetModel
				{
					Key = generator.Key,
					DisplayName = generator.DisplayName,
					Generator = generator,
					IconStore = generator.Icons
				};

				instancePool.Register(profileModel);
				objectStores.Add(profileModel);
			}

			if (WorkingDirectory.HasChildStore(profileDirectoryName))
			{
				var profiles = profileDirectory.GetChildStoreKeys();
				var messages = new List<string>();

				foreach (var storageKey in profiles)
				{
					var currentProfileDirectory = profileDirectory.GetChildStore(storageKey);
					if (!currentProfileDirectory.ContainsKey("profile.json"))
					{
						continue;
					}

					try
					{
						const string dataDirectoryName = "Data";
						const string iconsDirectoryName = "Icons";

						var profileModel = dataProvider.Read<ProfileModel>(currentProfileDirectory.Open("profile.json"));
						if (profileModel == null)
						{
							continue;
						}

						profileModel.DataStore = currentProfileDirectory.GetChildStore(dataDirectoryName);
						profileModel.IconStore = currentProfileDirectory.GetChildStore(iconsDirectoryName);

						instancePool.Register(profileModel);
						objectStores.Add(profileModel);
					}
					catch (Exception exception)
					{
						messages.Add($"{storageKey}: {exception.GetOriginalMessage()}");
					}
				}

				if (messages.Any())
				{
					Dialog.Error(string.Join("\r\n", messages)).Display();
				}
			}

			return objectStores;
		}
		private IList<IModelGenerator> GetModelGenerators()
		{
			var assemblyLocation = Path.GetDirectoryName(typeof(MainController).Assembly.Location) ?? string.Empty;
			var result = new List<IModelGenerator>();

			foreach (var fileName in Directory.GetFiles(assemblyLocation, "*.dll", SearchOption.TopDirectoryOnly))
			{
				try
				{
					var assembly = Assembly.LoadFile(fileName);
					var types = assembly.GetLoadableTypes().Where(x => typeof(IModelGenerator).IsAssignableFrom(x));

					foreach (var type in types)
					{
						try
						{
							result.Add((IModelGenerator)Activator.CreateInstance(type));
						}
						catch
						{
							//
						}
					}
				}
				catch
				{
					//
				}
			}

			return result;
		}
	}
}
