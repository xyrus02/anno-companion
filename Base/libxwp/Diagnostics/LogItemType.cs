using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public enum LogItemType
	{
		Notice = 0,
		Warning = 1,
		Error = 2,

		Debug = -1
	}
}