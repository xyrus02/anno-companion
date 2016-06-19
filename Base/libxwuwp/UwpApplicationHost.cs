using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using JetBrains.Annotations;
using XW.Configuration;
using XW.Diagnostics;

namespace XW
{
	[PublicAPI]
	public class UwpApplicationHost : IApplicationDomain
	{
		private static UwpApplicationHost mInstance;
		private readonly LaunchActivatedEventArgs mArgs;
		private readonly Application mApplication;
		private bool mIsActive;

		public UwpApplicationHost([NotNull] Application application, LaunchActivatedEventArgs args = null)
		{
			if (mInstance != null)
			{
				throw new InvalidOperationException(Messages.ErrMultipleApplicationHostsInstanced);
			}

			if (application == null)
			{
				throw new ArgumentNullException(nameof(application));
			}

			mApplication = application;
			mArgs = args;
			mInstance = this;

			mApplication.UnhandledException += OnUnhandledException;
			mApplication.Suspending += OnSuspending;
			mApplication.Resuming += OnResuming;

			var rootStorage = ApplicationData.Current;

			Log = new TraceLogProvider();
			VersionInfo = new UwpVersionInfo(Package.Current);

			LocalStorage = rootStorage?.LocalFolder.TryTransform(x => new UwpStorage(x)) ?? (IKeyedDomainStorage)new EmptyStorage();
			RoamingStorage = rootStorage?.RoamingFolder.TryTransform(x => new UwpStorage(x)) ?? (IKeyedDomainStorage)new EmptyStorage();
			SharedLocalStorage = rootStorage?.SharedLocalFolder.TryTransform(x => new UwpStorage(x)) ?? (IKeyedDomainStorage)new EmptyStorage();
			TemporaryStorage = rootStorage?.TemporaryFolder.TryTransform(x => new UwpStorage(x)) ?? (IKeyedDomainStorage)new EmptyStorage();
			CacheStorage = rootStorage?.LocalCacheFolder.TryTransform(x => new UwpStorage(x)) ?? (IKeyedDomainStorage)new EmptyStorage();

			Configuration = rootStorage?.LocalSettings.TryTransform(x => new UwpConfigurationProvider(x)) ?? (IKeyedConfigurationProvider)new EmptyConfigurationProvider();
			RoamingConfiguration = rootStorage?.RoamingSettings.TryTransform(x => new UwpConfigurationProvider(x)) ?? (IKeyedConfigurationProvider)new EmptyConfigurationProvider();

			UserSettings = new XmlConfigurationProvider(RoamingStorage, "user.config");
		}

		[NotNull]
		public IVersionInfo VersionInfo { get; }

		[NotNull]
		public IScopedLogProvider Log { get; }

		[NotNull]
		public IKeyedConfigurationProvider Configuration { get; }

		[NotNull]
		public IKeyedConfigurationProvider RoamingConfiguration { get; }

		[NotNull]
		public IKeyedConfigurationProvider UserSettings { get; }

		[NotNull]
		public IKeyedDomainStorage LocalStorage { get; }

		[NotNull]
		public IKeyedDomainStorage RoamingStorage { get; }

		[NotNull]
		public IKeyedDomainStorage SharedLocalStorage { get; }

		[NotNull]
		public IKeyedDomainStorage TemporaryStorage { get; }

		[NotNull]
		public IKeyedDomainStorage CacheStorage { get; }

		public void Initialize()
		{
			if (mIsActive)
			{
				return;
			}

			using (Log.Scope.Enter(CoreLogScope.DiagnosticsSubsystem))
			{
				Log.WriteLine(Messages.LogAppStarting);
				Log.WriteLine(Messages.LogAppVersion, VersionInfo.FileVersion);
			}
			
			OnStartup();
			mIsActive = true;
		}
		public void Shutdown()
		{
			if (!mIsActive)
			{
				return;
			}

			using (Log.Scope.Enter(CoreLogScope.DiagnosticsSubsystem))
			{
				Log.WriteLine(Messages.LogAppShuttingDown);
			}

			OnShutdown();
			mApplication.UnhandledException -= OnUnhandledException;
			mIsActive = false;
		}

		[CanBeNull]
		public static UwpApplicationHost GetCurrent()
		{
			return mInstance;
		}

		[CanBeNull]
		public static T GetCurrent<T>() where T : UwpApplicationHost
		{
			return mInstance as T;
		}

		public event UncleanShutdownEventHandler UncleanShutdown;
		public void RaiseUncleanShutdown(Exception exception)
		{
			if (exception != null)
			{
				UncleanShutdown?.Invoke(this, new UncleanShutdownEventArgs(exception));
			}
		}

		protected Application Application => mApplication;
		protected LaunchActivatedEventArgs LaunchArgs => mArgs;

		protected virtual void OnStartup()
		{

		}
		protected virtual void OnShutdown()
		{

		}
		protected virtual void OnUnhandledException([NotNull] Exception exception)
		{
		}

		private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
		{
			var exception = args.Exception;
			if (exception != null)
			{
				OnUnhandledException(exception);
				UncleanShutdown?.Invoke(this, new UncleanShutdownEventArgs(exception));
			}
		}
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			try
			{
				Shutdown();
			}
			finally
			{
				deferral.Complete();
			}
		}
		private void OnResuming(object sender, object e)
		{
			Initialize();
		}
	}
}
