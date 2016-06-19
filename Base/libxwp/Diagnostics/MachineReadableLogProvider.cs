using System;
using JetBrains.Annotations;
using XW.Configuration;

namespace XW.Diagnostics
{
	[PublicAPI]
	public abstract class MachineReadableLogProvider : FileLogProvider
	{
		protected MachineReadableLogProvider([NotNull] IKeyedDomainStorage storage, string key = null) : base(storage, key)
		{
		}

		protected abstract override string FormatOverride(string message, object scope, LogItemType type, DateTime timestamp);
		protected abstract bool ParseOverride(string serializedMessage, out LogItem item);

		public LogItem? Parse([NotNull] string serializedMessage)
		{
			if (serializedMessage == null)
			{
				throw new ArgumentNullException(nameof(serializedMessage));
			}

			LogItem item;

			var result = ParseOverride(serializedMessage, out item);
			if (!result)
			{
				return null;
			}

			return item;
		}

		internal void WriteMessage(LogItem message)
		{
			var data = FormatOverride(message.Message, message.Scope, message.Type, message.Timestamp);
			WriteOverride(data);
		}
	}
}