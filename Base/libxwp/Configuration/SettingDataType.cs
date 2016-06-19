using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public enum SettingDataType
	{
		Undefined = 0,
		String,
		Boolean,
		Float,
		Integer,
		Enumeration
	}
}