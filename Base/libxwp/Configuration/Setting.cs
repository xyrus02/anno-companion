using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class Setting
	{
		private readonly IList<SettingChoice> mChoices;
		private readonly IList<Constraint> mConstraints;

		private readonly string mDisplayName;
		private readonly SettingDataType mType;

		private object mValue;
		private object mDefaultValue;

		public Setting([NotNull] string displayName, SettingDataType type = SettingDataType.Undefined)
		{
			if (displayName == null) throw new ArgumentNullException(nameof(displayName));

			mDisplayName = displayName;
			mType = type;

			var constraints = new SimpleObservableList<Constraint>();
			constraints.AddAction = OnConstraintAdded;
			constraints.RemoveAction = OnConstraintRemoved;

			mChoices = new List<SettingChoice>();
			mConstraints = new SimpleObservableList<Constraint>();
		}

		public string DisplayName => mDisplayName;
		public string Group { get; set; }

		public SettingDataType Type => mType;

		public IList<SettingChoice> Choices => mChoices;
		public IList<Constraint> Constraints => mConstraints;

		public object DefaultValue
		{
			get { return mDefaultValue; }
			set
			{
				mDefaultValue = value;

				if (mValue == null)
				{
					mValue = mDefaultValue;
				}
			}
		}
		public object Value
		{
			get { return mValue; }
			set
			{
				if (value == null)
				{
					mValue = DefaultValue;
					return;
				}

				if (Choices.Any() && !Choices.Any(x => Equals(x.AssociatedValue, value)))
				{
					mValue = DefaultValue;
					return;
				}

				mValue = value;
			}
		}

		private void OnConstraintAdded(Constraint obj)
		{
			if (obj != null)
			{
				obj.Changed += OnConstraintChanged;
			}

			OnConstraintChanged(null);
		}
		private void OnConstraintRemoved(Constraint obj)
		{
			if (obj != null)
			{
				obj.Changed -= OnConstraintChanged;
			}

			OnConstraintChanged(null);
		}
		private void OnConstraintChanged(Constraint obj)
		{
			foreach (var constraint in mConstraints)
			{
				mDefaultValue = constraint?.Enforce(mDefaultValue) ?? mDefaultValue;
			}

			foreach (var constraint in mConstraints)
			{
				mValue = constraint?.Enforce(mValue) ?? mValue ?? mDefaultValue;
			}
		}
	}
}