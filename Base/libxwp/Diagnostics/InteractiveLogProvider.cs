using System;
using System.Text;
using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public abstract class InteractiveLogProvider : LogProvider
	{
		protected InteractiveLogProvider()
		{
			ScopeBlacklist.Add(CoreLogScope.DiagnosticsSubsystem);
		}

		public int ScopeLength { get; set; } = 8;

		protected override string FormatOverride(string message, object scope, LogItemType type, DateTime timestamp)
		{
			const int maxTypeLength = 7;

			const char space = ' ';
			const string separator = " | ";

			var state = Scope.State as string ?? string.Empty;
			var origin = !string.IsNullOrEmpty(state)
				? state.Substring(0, Math.Min(state.Length, ScopeLength)).PadLeft(ScopeLength, space)
				: new string(' ', ScopeLength);

			var padString = new string(space, ScopeLength) + separator + new string(space, maxTypeLength);
			var wrappedText = message.WordWrap(MaxLineLength.GetValueOrDefault(300) - 1, padString + separator, string.Empty);
			var lineBuilder = new StringBuilder();

			lineBuilder.Append(origin);
			lineBuilder.Append(separator);

			lineBuilder.Append(type.ToString().ToUpper().PadRight(maxTypeLength, space));
			lineBuilder.Append(separator);

			lineBuilder.Append(wrappedText);

			var text = lineBuilder.ToString();

			WriteFormatted(text, type);
			return text;
		}
		protected override void WriteOverride(string data)
		{
		}

		protected virtual void WriteFormatted(string text, LogItemType type)
		{
		}
		protected virtual int? MaxLineLength { get; }
	}
}