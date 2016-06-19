using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public delegate void LogWrittenEventHandler(object sender, LogWrittenEventArgs args);
}