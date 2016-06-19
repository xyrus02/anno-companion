using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class ServiceConfiguration
	{
		private string mHostname;
		private ushort mPort;

		public const string ServiceHostnameKey = @"ServiceHostname";
		public const string ServicePortKey = @"ServicePort";
		public const string ServiceProtocolKey = @"ServiceProtocol";

		public const string DefaultHostname = "localhost";
		public const ushort DefaultPort = 8080;
		public const ServiceProtocol DefaultProtocol = ServiceProtocol.Http;

		public ServiceConfiguration([NotNull] IKeyedConfigurationProvider config)
		{
			if (config == null)
			{
				throw new ArgumentNullException(nameof(config));
			}

			var readConfiguration = config.ReadServiceConfiguration();

			Hostname = readConfiguration.Hostname;
			Port = readConfiguration.Port;
			Protocol = readConfiguration.Protocol;
		}
		public ServiceConfiguration(
			[CanBeNull] string hostname = null, 
			[CanBeNull] ushort? port = null,
			[CanBeNull] ServiceProtocol? protocol = null)
		{
			if (string.IsNullOrWhiteSpace(hostname))
			{
				hostname = DefaultHostname;
			}

			if (!port.HasValue)
			{
				port = DefaultPort;
			}

			if (!protocol.HasValue)
			{
				protocol = DefaultProtocol;
			}

			Hostname = hostname;
			Port = port.Value;
			Protocol = protocol.Value;
		}

		[NotNull]
		public string Hostname
		{
			get { return mHostname; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(value));
				}

				if (!Regex.IsMatch(value, @"^[a-z0-9\-._~%]+|\[[a-z0-9\-._~%!$&'()*+,;=:]+\]$", RegexOptions.IgnoreCase))
				{
					throw new ArgumentException(Messages.ErrInvalidHostnameInConfiguration, nameof(value));
				}

				mHostname = value;
			}
		}
		public ushort Port
		{
			get { return mPort; }
			set
			{
				if (0 == value)
				{
					throw new ArgumentOutOfRangeException(nameof(value));
				}

				if (value == 0)
				{
					throw new ArgumentException(Messages.ErrInvalidPortInConfiguration, nameof(value));
				}

				mPort = value;
			}
		}
		public ServiceProtocol Protocol
		{
			get;
			set;
		}

		public Uri GetUri()
		{
			var schema = Protocol.ToString().ToLower();
			switch (Protocol)
			{
				case ServiceProtocol.Http:
					schema = "http";
					break;
				case ServiceProtocol.NetTcp:
					schema = "net.tcp";
					break;
			}

			return new Uri($"{schema}://{Hostname}:{Port}");
		}
	}
}