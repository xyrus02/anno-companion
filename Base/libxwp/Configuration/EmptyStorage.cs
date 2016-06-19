using System.Collections.Generic;
using System.IO;
using System.Text;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class EmptyStorage : IKeyedDomainStorage
	{
		public IKeyedDomainStorage CreateChildStorage(string key, bool? isReadOnly = null) => new EmptyStorage();

		public StreamReader ReadContainer(string key) => new StreamReader(new MemoryStream());
		public StreamWriter WriteContainer(string key) => new StreamWriter(new MemoryStream());
		public StreamWriter AppendToContainer(string key) => new StreamWriter(new MemoryStream());

		public bool HasContainer(string key) => false;
		public void PurgeContainer(string key) { }
		public long GetContainerLength(string key) => 0;

		public Encoding Encoding { get; set; } = Encoding.UTF8;
		public bool IsReadOnly => false;
		public IEnumerable<string> GetKeys() => new string[0];
		public object GetPhysicalLocator() => null;
	}
}