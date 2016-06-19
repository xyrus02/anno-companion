using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class BatchResponse
	{
		public DataResponse[] ItemResponses { get; set; }
		public Result OperationResult { get; set; }
	}

	[PublicAPI]
	public class BatchResponse<T> : BatchResponse
	{
		public T[] Data { get; set; }
	}
}