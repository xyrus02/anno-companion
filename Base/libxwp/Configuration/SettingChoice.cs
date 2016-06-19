using System;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class SettingChoice
	{
		private readonly string mDisplayText;
		private readonly object mAssociatedValue;

		public SettingChoice([NotNull] string displayText, [NotNull] object associatedValue)
		{
			if (displayText == null) throw new ArgumentNullException(nameof(displayText));
			if (associatedValue == null) throw new ArgumentNullException(nameof(associatedValue));

			mDisplayText = displayText;
			mAssociatedValue = associatedValue;
		}

		public string DisplayText => mDisplayText;
		public object AssociatedValue => mAssociatedValue;
	}
}