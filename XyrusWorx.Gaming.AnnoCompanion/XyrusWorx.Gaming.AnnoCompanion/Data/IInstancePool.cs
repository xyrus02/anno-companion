using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	interface IInstancePool
	{
		void Clear();
		void Register([NotNull] Persistable obj);

		Persistable Resolve(StringKey key);

		IEnumerable<T> GetAll<T>() where T : Persistable;
		IEnumerable<Persistable> GetAll([NotNull] Type type);
	}
}