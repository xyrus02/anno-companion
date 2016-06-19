using System;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using XW.Configuration;

namespace XW.Diagnostics
{
	[PublicAPI]
	public class CsvFileLogProvider : MachineReadableLogProvider
	{
		private readonly Regex mParseRegex;

		public CsvFileLogProvider([NotNull] IKeyedDomainStorage storage, string key = null) : base(storage, key)
		{
			mParseRegex = new Regex(@"^(.+?);(.+?);(.+?);""(.+)""$");
		}

		protected override string FormatOverride(string message, object scope, LogItemType type, DateTime timestamp)
		{
			const string dateFormat = @"O";

			var state = Scope.State as string ?? string.Empty;
			var origin = !string.IsNullOrEmpty(state) ? state : "<null>";

			return $"{timestamp.ToString(dateFormat)};{type.ToString().ToLower()};{origin};\"{message.Escape()}\"";
		}
		protected override bool ParseOverride(string serializedMessage, out LogItem item)
		{
			item = new LogItem();

			var match = mParseRegex.Match(serializedMessage);
			if (!match.Success)
			{
				return false;
			}

			item.Timestamp = DateTime.ParseExact(match.Groups[1].Value, "O", CultureInfo.CurrentCulture);
			item.Type = (LogItemType)Enum.Parse(typeof(LogItemType), match.Groups[2].Value, true);
			item.Scope = match.Groups[3].Value == "<null>" ? null : match.Groups[3].Value;
			item.Message = match.Groups[4].Value.Unescape();

			return true;
		}
	}
}