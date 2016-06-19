using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class DatabaseConfiguration
	{
		private string mServer;
		private string mDatabase;

		private IDatabaseAuthentication mAuthenticationMethod;

		public const string DatabaseServerKey = @"DatabaseServer";
		public const string DatabaseNameKey = @"DatabaseName";
		public const string DatabaseUserKey = @"DatabaseUser";
		public const string DatabasePasswordKey = @"DatabasePassword";
		public const string DatabaseAuthenticationMethodKey = @"DatabaseAuthenticationMethod";

		public const string DefaultServer = "localhost";
		public const string DefaultDatabase = "tempdb";

		public static readonly IDatabaseAuthentication DefaultAuthenticationMethod = new IntegratedSecurityAuthentication();

		public DatabaseConfiguration([NotNull] IKeyedConfigurationProvider config)
		{
			if (config == null)
			{
				throw new ArgumentNullException(nameof(config));
			}

			var readConfiguration = config.ReadDatabaseConfiguration();

			Server = readConfiguration.Server;
			Database = readConfiguration.Database;
			AuthenticationMethod = readConfiguration.AuthenticationMethod;
		}
		public DatabaseConfiguration([CanBeNull] string server = null, [CanBeNull] string database = null, [CanBeNull] IDatabaseAuthentication authenticationMethod = null)
		{
			if (String.IsNullOrWhiteSpace(server))
			{
				server = DefaultServer;
			}

			if (String.IsNullOrWhiteSpace(database))
			{
				database = DefaultDatabase;
			}

			if (authenticationMethod == null)
			{
				authenticationMethod = DefaultAuthenticationMethod;
			}

			Server = server;
			Database = database;
			AuthenticationMethod = authenticationMethod;
		}

		public string Server
		{
			get { return mServer; }
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, @"^(?:[a-z0-9\-._~%]+|\[[a-z0-9\-._~%!$&'()*+,;=:]+\])(?:[a-z0-9\-_~%\\]+)?$", RegexOptions.IgnoreCase))
				{
					throw new ArgumentException(Messages.ErrInvalidDatabaseInstanceInConfiguration, nameof(value));
				}

				mServer = value;
			}
		}
		public string Database
		{
			get { return mDatabase; }
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, @"^[a-z0-9\-_~%]+$", RegexOptions.IgnoreCase))
				{
					throw new ArgumentException(Messages.ErrInvalidDatabaseNameInConfiguration, nameof(value));
				}

				mDatabase = value;
			}
		}

		[NotNull]
		public IDatabaseAuthentication AuthenticationMethod
		{
			get { return mAuthenticationMethod; }
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));
				mAuthenticationMethod = value;
			}
		}
	}
}