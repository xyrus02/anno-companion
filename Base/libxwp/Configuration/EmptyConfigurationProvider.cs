using System.Collections.Generic;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class EmptyConfigurationProvider : IKeyedConfigurationProvider
	{
		public bool IsReadOnly => true;

		public bool HasValue(string key) => false;
		public string ReadValue(string key) => null;

		public void WriteValue(string key, string value) { }
		public void SetDefault(string key, string defaultValue) { }

		public IEnumerable<string> GetKeys() => new string[0];
	}
}