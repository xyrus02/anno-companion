using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace XW.Configuration
{
	/// <summary>
	/// Erweiterung des Interfaces IKeyedConfigurationProvider um Hilfsmethoden, die die im Interface angebotenen Methoden verwenden, um Standardszenarien zu verarbeiten
	/// </summary>
	[PublicAPI]
	public static class KeyedConfigurationProvider
	{
		private static readonly Dictionary<string, Type> mAuthenticationMethods = new Dictionary<string, Type>();
		private const string mOmittableAuthenticationMethodClassSuffix = @"Authentication";

		[NotNull]
		public static ServiceConfiguration ReadServiceConfiguration([NotNull] this IKeyedConfigurationProvider instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}

			var hostname = instance.HasValue(ServiceConfiguration.ServiceHostnameKey) ? instance.ReadValue(ServiceConfiguration.ServiceHostnameKey) : ServiceConfiguration.DefaultHostname;
			var port = instance.HasValue(ServiceConfiguration.ServicePortKey) ? instance.ReadValue(ServiceConfiguration.ServicePortKey) : ServiceConfiguration.DefaultPort.ToString();
			var protocol = instance.HasValue(ServiceConfiguration.ServiceProtocolKey) ? instance.ReadValue(ServiceConfiguration.ServiceProtocolKey) : ServiceConfiguration.DefaultProtocol.ToString();

			if (string.IsNullOrWhiteSpace(hostname) || !Regex.IsMatch(hostname, @"^[a-z0-9\-._~%]+|\[[a-z0-9\-._~%!$&'()*+,;=:]+\]$", RegexOptions.IgnoreCase))
			{
				throw new FormatException($@"{Messages.ErrInvalidConfigurationValue} {Messages.ErrInvalidHostnameInConfiguration}");
			}

			var portNumber = port.TryDeserialize<ushort>();
			if (portNumber == 0)
			{
				throw new FormatException($@"{Messages.ErrInvalidConfigurationValue} {Messages.ErrInvalidPortInConfiguration}");
			}

			ServiceProtocol protocolValue;
			if (string.IsNullOrWhiteSpace(protocol) || !Enum.TryParse(protocol, true, out protocolValue))
			{
				throw new FormatException(string.Format(Messages.ErrInvalidConfigurationValue, ServiceConfiguration.ServiceProtocolKey));
			}

			return new ServiceConfiguration(hostname, portNumber, protocolValue);
		}

		[NotNull]
		public static DatabaseConfiguration ReadDatabaseConfiguration([NotNull] this IKeyedConfigurationProvider instance, bool skipValidation = false)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}

			var databaseInstance = instance.HasValue(DatabaseConfiguration.DatabaseServerKey) ? instance.ReadValue(DatabaseConfiguration.DatabaseServerKey) : DatabaseConfiguration.DefaultServer;
			var databaseName = instance.HasValue(DatabaseConfiguration.DatabaseNameKey) ? instance.ReadValue(DatabaseConfiguration.DatabaseNameKey) : DatabaseConfiguration.DefaultDatabase;
			var authenticationMethod = instance.HasValue(DatabaseConfiguration.DatabaseAuthenticationMethodKey) 
				? instance.ReadValue(DatabaseConfiguration.DatabaseAuthenticationMethodKey) 
				: DatabaseConfiguration.DefaultAuthenticationMethod.ToAuthenticationMethodKey();

			if (!skipValidation && string.IsNullOrWhiteSpace(databaseInstance))
			{
				throw new FormatException($@"{Messages.ErrInvalidConfigurationValue} {Messages.ErrInvalidDatabaseInstanceInConfiguration}");
			}

			if (!skipValidation && string.IsNullOrWhiteSpace(databaseName))
			{
				throw new FormatException($@"{Messages.ErrInvalidConfigurationValue} {Messages.ErrInvalidDatabaseNameInConfiguration}");
			}

			var authenticationMethodKey = NormalizeAuthenticationMethodKey(authenticationMethod ?? string.Empty);
			if (!skipValidation && (string.IsNullOrWhiteSpace(authenticationMethod) || !mAuthenticationMethods.ContainsKey(authenticationMethodKey)))
			{
				throw new NotSupportedException(Messages.ErrInvalidAuthenticationMethodInConfiguration);
			}

			IDatabaseAuthentication authenticationMethodInstance;

			if (skipValidation && !mAuthenticationMethods.ContainsKey(authenticationMethodKey))
			{
				authenticationMethodInstance = new IntegratedSecurityAuthentication();
			}
			else
			{
				authenticationMethodInstance = (IDatabaseAuthentication)Activator.CreateInstance(mAuthenticationMethods[authenticationMethodKey]);
				authenticationMethodInstance.Read(instance);
			}

			return new DatabaseConfiguration(databaseInstance, databaseName, authenticationMethodInstance);
		}

		[NotNull]
		public static string ToAuthenticationMethodKey([NotNull] this IDatabaseAuthentication instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}

			return NormalizeAuthenticationMethodKey(instance.GetType().Name);
		}

		[NotNull]
		public static string NormalizeAuthenticationMethodKey([NotNull] string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException(nameof(input));
			}

			var key = input.ToLower();
			if (key.EndsWith(mOmittableAuthenticationMethodClassSuffix.ToLower()))
			{
				key = key.Substring(0, key.Length - mOmittableAuthenticationMethodClassSuffix.Length);
			}

			return key;
		}

		[NotNull]
		public static IDictionary<string, Type> AuthenticationMethods => mAuthenticationMethods;
	}
}
