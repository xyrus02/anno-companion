using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public class LogWrittenEventArgs
	{
		private readonly LogItem mItem;

		public LogWrittenEventArgs(LogItem item)
		{
			mItem = item;
		}

		public LogItem Item => mItem;
	}
}