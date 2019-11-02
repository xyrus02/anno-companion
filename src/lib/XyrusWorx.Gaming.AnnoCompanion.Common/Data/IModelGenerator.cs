using JetBrains.Annotations;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public interface IModelGenerator
	{
		string Key { get; }
		string DisplayName { get; }

		void Generate([NotNull] IInstancePool instancePool);

		IBlobStore Icons { get; }
	}
}