using System;
using JetBrains.Annotations;

namespace XW.Diagnostics
{
	[PublicAPI]
	public interface IScopedLogProvider
	{
		[NotNull]
		Scope Scope { get; }

		[StringFormatMethod("message")]
		void WriteDebug([NotNull, LocalizationRequired] string message, params object[] parameters);

		[StringFormatMethod("message")]
		void WriteLine([NotNull, LocalizationRequired] string message, params object[] parameters);

		[StringFormatMethod("message")]
		void WriteWarning([NotNull, LocalizationRequired] string message, params object[] parameters);

		[StringFormatMethod("message")]
		void WriteError([NotNull, LocalizationRequired] string message, params object[] parameters);
		void WriteError([NotNull] Exception exception);

		void Attach([NotNull] IScopedLogProvider provider);
		bool Detach([NotNull] IScopedLogProvider provider);
		void ClearAttachedLogs();

		bool AcceptsDebugMessages { get; set; }
	}
}