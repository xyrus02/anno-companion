using JetBrains.Annotations;

namespace XW
{
	[PublicAPI, UsedImplicitly]
	public class PaginationRequest : Request
	{
		[PublicAPI, UsedImplicitly]
		public int PageOffset { get; set; }

		[PublicAPI, UsedImplicitly]
		public int PageSize { get; set; }
	}
}