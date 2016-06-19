using System;
using System.Collections.Generic;
using Windows.Storage;
using JetBrains.Annotations;
using XW.Configuration;

namespace XW
{
	[PublicAPI]
	public class UwpConfigurationProvider : IKeyedConfigurationProvider
	{
		private readonly ApplicationDataContainer mContainer;

		public UwpConfigurationProvider([NotNull] ApplicationDataContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException(nameof(container));
			}

			mContainer = container;
		}

		public string ReadValue(string key) => mContainer.Values[key]?.ToString();
		public void WriteValue(string key, string value) => mContainer.Values[key] = value;
		public bool HasValue(string key) => string.IsNullOrEmpty(mContainer.Values[key]?.ToString());
		public void SetDefault(string key, string defaultValue)
		{
			if (HasValue(key))
			{
				return;
			}

			WriteValue(key, defaultValue);
		}

		public bool IsReadOnly => false;

		public IEnumerable<string> GetKeys()
		{
			foreach (var value in mContainer.Values)
			{
				yield return value.Key;
			}
		}
	}
}