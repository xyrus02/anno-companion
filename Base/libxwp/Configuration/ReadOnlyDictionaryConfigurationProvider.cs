using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class ReadOnlyDictionaryConfigurationProvider : IKeyedConfigurationProvider
	{
		private readonly IReadOnlyDictionary<string, string> mDictionary;
		private readonly IDictionary<string, string> mDefaultOverrideDictionary;

		public ReadOnlyDictionaryConfigurationProvider([NotNull] IReadOnlyDictionary<string, string> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException(nameof(dictionary));
			}

			mDictionary = dictionary;
			mDefaultOverrideDictionary = new Dictionary<string, string>();
        }

		public string ReadValue(string key)
		{
			if (!HasValue(key))
			{
				if (!mDefaultOverrideDictionary.ContainsKey(key))
				{
					return null;
				}

				return mDefaultOverrideDictionary[key];
			}

			return mDictionary[key];
		}
		public bool HasValue(string key)
		{
			return mDictionary.ContainsKey(key) || mDefaultOverrideDictionary.ContainsKey(key);
		}
		public void WriteValue(string key, string value)
		{
			throw new NotSupportedException();
		}

		public void SetDefault(string key, string defaultValue)
		{
			mDefaultOverrideDictionary.AddOrUpdate(key, defaultValue);
		}

		public IEnumerable<string> GetKeys()
		{
			return mDictionary.Keys.Concat(mDefaultOverrideDictionary.Keys).Distinct().ToArray();
		}
		public bool IsReadOnly => true;
	}
}