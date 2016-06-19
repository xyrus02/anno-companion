using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public interface IMatrixType : IVectorType
	{
	}

	[PublicAPI]
	public interface IMatrixType<out T> : IVectorType<T>
	{
	}
}