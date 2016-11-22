using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public interface IModelGenerator
	{
		void Generate([NotNull] IInstancePool instancePool);
		void AddToIconResolver([NotNull] IIconResolver iconResolver);
	}
}