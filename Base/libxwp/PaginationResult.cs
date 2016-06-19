using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, UsedImplicitly]
	public abstract class PaginationResult : Result
	{
		public abstract int Length { get; }
	}
}