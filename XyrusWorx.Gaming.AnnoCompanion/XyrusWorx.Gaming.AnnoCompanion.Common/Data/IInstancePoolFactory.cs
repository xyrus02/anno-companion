using JetBrains.Annotations;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public interface IInstancePoolFactory
	{
		IInstancePool GetInstancePool();
	}
}