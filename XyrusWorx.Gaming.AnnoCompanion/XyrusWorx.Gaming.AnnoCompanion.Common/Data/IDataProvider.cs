using System.Collections.Generic;
using JetBrains.Annotations;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public interface IDataProvider
	{
		T Get<T>(StringKey key) where T : Persistable;
		IEnumerable<T> GetAll<T>() where T : Persistable;

		void Clear();
		void Import([NotNull] IBlobStore source);
		void Export([NotNull] IBlobStore target);
	}
}