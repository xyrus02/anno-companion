using Windows.ApplicationModel.Activation;
using XW.Apophysis.ParameterCompanion.Controllers;

namespace XW.Apophysis.ParameterCompanion
{
	sealed partial class LaunchController
	{
		private ApplicationController mController;

		public LaunchController()
		{
			Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
				Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
				Microsoft.ApplicationInsights.WindowsCollectors.Session);

			InitializeComponent();
		}

		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
			{
				DebugSettings.EnableFrameRateCounter = true;
			}
#endif

			mController = new ApplicationController(this, e);
			mController.Initialize();
		}
	}
}
