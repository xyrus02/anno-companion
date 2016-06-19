using System;
using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public struct LogItem
	{
		public string Message;
		public string Scope;
		public LogItemType Type;
		public DateTime Timestamp;
	}
}