using System.Windows.Media;
using JetBrains.Annotations;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public interface IIconResolver
	{
		ImageSource GetIcon<T>(StringKey key);
		ImageSource GetIcon(StringKey key, StringKey category);

		void AddExternalDataSource([NotNull] IBlobStore store);
	}
}