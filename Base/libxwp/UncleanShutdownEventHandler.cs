using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public delegate void UncleanShutdownEventHandler(object sender, UncleanShutdownEventArgs args);
}