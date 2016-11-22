using System.Collections.Generic;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	interface IDataProvider
	{
		T Get<T>(StringKey key) where T : Persistable;
		IEnumerable<T> GetAll<T>() where T : Persistable;
	}
}