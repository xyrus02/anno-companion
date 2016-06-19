using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class ConfigurationProviderSection : IKeyedConfigurationProvider
	{
		private readonly string mPrefix;
		private readonly IKeyedConfigurationProvider mParent;

		public ConfigurationProviderSection([NotNull] string prefix, [NotNull] IKeyedConfigurationProvider parent)
		{
			if (string.IsNullOrWhiteSpace(prefix))
			{
				throw new ArgumentNullException(nameof(prefix));
			}

			if (parent == null)
			{
				throw new ArgumentNullException(nameof(parent));
			}

			mPrefix = prefix;
			mParent = parent;
		}

		public string ReadValue(string key)
		{
			return mParent.ReadValue($"{mPrefix}{key}");
		}
		public void WriteValue(string key, string value)
		{
			mParent.WriteValue($"{mPrefix}{key}", value);
		}
		public void SetDefault(string key, string defaultValue)
		{
			mParent.SetDefault($"{mPrefix}{key}", defaultValue);
		}

		public bool HasValue(string key)
		{
			return mParent.HasValue($"{mPrefix}{key}");
		}
		public bool IsReadOnly
		{
			get { return mParent.IsReadOnly; }
		}

		public IEnumerable<string> GetKeys()
		{
			return mParent.GetKeys().Select(x => $"{mPrefix}{x}").ToArray();
		}
	}
}