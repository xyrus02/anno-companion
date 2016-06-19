using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class ErrorDetails
	{
		[PublicAPI]
		public int HResult { get; set; }

		[PublicAPI, CanBeNull]
		public string StackTrace { get; set; }
	}
}