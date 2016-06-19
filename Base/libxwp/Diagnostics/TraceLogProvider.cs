using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public sealed class TraceLogProvider : InteractiveLogProvider
	{
		protected override string FormatOverride(string message, object scope, LogItemType type, DateTime timestamp)
		{
			switch (type)
			{
				case LogItemType.Debug:
					Debug.WriteLine($"DEBUG: {message}");
					break;
				case LogItemType.Notice:
					Debug.WriteLine($"{message}");
					break;
				case LogItemType.Warning:
					Debug.WriteLine($"WARN: {message}");
					break;
				case LogItemType.Error:
					Debug.WriteLine($"ERROR: {message}");
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}

			return message;
		}
	}
}