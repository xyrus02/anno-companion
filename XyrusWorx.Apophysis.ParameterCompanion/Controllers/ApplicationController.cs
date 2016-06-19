using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using JetBrains.Annotations;
using XW.Apophysis.ParameterCompanion.Views;

namespace XW.Apophysis.ParameterCompanion.Controllers
{
	public class ApplicationController : UwpApplicationHost
	{
		public ApplicationController([NotNull] Application application, LaunchActivatedEventArgs args = null) : base(application, args)
		{
		}

		protected override void OnStartup()
		{
			base.OnStartup();

			Frame rootFrame = Window.Current.Content as Frame;

			// App-Initialisierung nicht wiederholen, wenn das Fenster bereits Inhalte enthält.
			// Nur sicherstellen, dass das Fenster aktiv ist.
			if (rootFrame == null)
			{
				// Frame erstellen, der als Navigationskontext fungiert und zum Parameter der ersten Seite navigieren
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (LaunchArgs?.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Zustand von zuvor angehaltener Anwendung laden
				}

				// Den Frame im aktuellen Fenster platzieren
				Window.Current.Content = rootFrame;
			}

			if (LaunchArgs?.PrelaunchActivated == false)
			{
				if (rootFrame.Content == null)
				{
					// Wenn der Navigationsstapel nicht wiederhergestellt wird, zur ersten Seite navigieren
					// und die neue Seite konfigurieren, indem die erforderlichen Informationen als Navigationsparameter
					// übergeben werden
					rootFrame.Navigate(typeof(MainView), LaunchArgs?.Arguments);
				}
				// Sicherstellen, dass das aktuelle Fenster aktiv ist
				Window.Current.Activate();
			}
		}

		/// <summary>
		/// Wird aufgerufen, wenn die Navigation auf eine bestimmte Seite fehlschlägt
		/// </summary>
		/// <param name="sender">Der Rahmen, bei dem die Navigation fehlgeschlagen ist</param>
		/// <param name="e">Details über den Navigationsfehler</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}
	}
}