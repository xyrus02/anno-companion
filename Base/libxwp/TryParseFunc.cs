using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public delegate bool TryParseFunc<T>(string data, out T value);
}