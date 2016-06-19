using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class DictionaryConfigurationProvider : IKeyedConfigurationProvider
	{
		private readonly IDictionary<string, string> mDictionary;

		public DictionaryConfigurationProvider([NotNull] IDictionary<string, string> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException(nameof(dictionary));
			}

			mDictionary = dictionary;
		}

		public string ReadValue(string key)
		{
			if (!HasValue(key))
			{
				return null;
			}

			return mDictionary[key];
		}
		public bool HasValue(string key)
		{
			return mDictionary.ContainsKey(key);
		}
		public void WriteValue(string key, string value)
		{
			if (!HasValue(key))
			{
				mDictionary.Add(key, value);
			}
			else
			{
				mDictionary[key] = value;
			}
		}
		public void SetDefault(string key, string defaultValue)
		{
			if (!HasValue(key))
			{
				WriteValue(key, defaultValue);
			}
		}

		public IEnumerable<string> GetKeys()
		{
			return mDictionary.Keys;
		}
		public bool IsReadOnly => false;
	}
}