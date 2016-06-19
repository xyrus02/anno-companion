using System;
using System.Text;
using JetBrains.Annotations;
using XW.Configuration;

namespace XW.Diagnostics
{
	[PublicAPI]
	public class HumanReadableFileLogProvider : FileLogProvider
	{
		private const int mTextFileLineLength = 300;

		public HumanReadableFileLogProvider([NotNull] IKeyedDomainStorage storage, string key = null) : base(storage, key)
		{
		}

		public int ScopeLength { get; set; } = 8;

		protected override string FormatOverride(string message, object scope, LogItemType type, DateTime timestamp)
		{
			const string dateFormat = @"yyyy-MM-dd HH:mm:ss";

			var formattedTimestamp = timestamp.ToString(dateFormat);
			var dateLength = formattedTimestamp.Length;

			const int maxTypeLength = 7;

			const char space = ' ';
			const string separator = " | ";

			var state = Scope.State as string ?? string.Empty;
			var origin = !string.IsNullOrEmpty(state)
				? state.Substring(0, Math.Min(state.Length, ScopeLength)).PadRight(ScopeLength, space)
				: new string(' ', ScopeLength);

			var padString = new string(space, dateLength) + separator + new string(space, ScopeLength) + separator + new string(space, maxTypeLength);
			var wrappedText = message.WordWrap(mTextFileLineLength - 1, padString + separator, string.Empty);
			var lineBuilder = new StringBuilder();

			lineBuilder.Append(formattedTimestamp.PadLeft(dateLength, space));
			lineBuilder.Append(separator);

			lineBuilder.Append(origin);
			lineBuilder.Append(separator);

			lineBuilder.Append(type.ToString().ToUpper().PadRight(maxTypeLength, space));
			lineBuilder.Append(separator);

			lineBuilder.Append(wrappedText);

			return lineBuilder.ToString();
		}
	}
}