using System.Collections.Generic;
using System.IO;
using System.Text;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public interface IKeyedDomainStorage
	{
		[NotNull]
		StreamReader ReadContainer([NotNull] string key);

		[NotNull]
		StreamWriter WriteContainer([NotNull] string key);

		[NotNull]
		StreamWriter AppendToContainer(string key);

		[CanBeNull]
		Encoding Encoding { get; set; }

		bool HasContainer([NotNull] string key);
		bool IsReadOnly { get; }

		void PurgeContainer([NotNull] string key);
		long GetContainerLength([NotNull] string key);

		[NotNull]
		IEnumerable<string> GetKeys();

		[NotNull]
		IKeyedDomainStorage CreateChildStorage(string key, bool? isReadOnly = null);

		object GetPhysicalLocator();
	}
}