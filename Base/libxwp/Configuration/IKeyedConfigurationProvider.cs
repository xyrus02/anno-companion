using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public interface IKeyedConfigurationProvider
	{
		string ReadValue(string key);
		void WriteValue(string key, string value);

		bool HasValue(string key);
		bool IsReadOnly { get; }

		void SetDefault(string key, string defaultValue);

		IEnumerable<string> GetKeys();
	}
}
