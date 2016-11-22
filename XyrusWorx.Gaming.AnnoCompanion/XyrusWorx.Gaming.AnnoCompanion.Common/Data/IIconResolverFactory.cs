using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public interface IIconResolverFactory
	{
		IIconResolver GetIconResolver();
	}
}