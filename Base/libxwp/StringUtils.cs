using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public static class StringUtils
	{
		private static readonly byte[] mEncryptionInitialVector =
			{
				0x74, 0x75, 0x38, 0x39, 0x67, 0x65,
				0x6A, 0x69, 0x33, 0x34, 0x30, 0x74,
				0x38, 0x39, 0x75, 0x32
			};

		private static readonly byte[] mEncryptionKey =
			{
				0x8E, 0xC2, 0x2B, 0x5D, 0xE3, 0x18,
				0x4A, 0xBD, 0xB1, 0xE0, 0xD0, 0x26,
				0xE3, 0xCF, 0x49, 0x82
			};

		private static readonly byte[] mEncryptionSalt =
			{
				0xE9, 0xDE, 0x45, 0xC8, 0x5D, 0x29,
				0x47, 0xB5, 0x85, 0xE0, 0xCF, 0x2F,
				0xAC, 0x60, 0x89, 0x20
			};

		private const int mEncryptionKeySize = 256;

		public static string Hash(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return new string('0', 32);
			}

			var md5 = MD5.Create();
			var inputBytes = Encoding.ASCII.GetBytes(input);
			var hash = md5.ComputeHash(inputBytes);

			var builder = new StringBuilder();
			foreach (var b in hash)
			{
				builder.Append(b.ToString("X2").ToLower());
			}
			return builder.ToString();
		}

		public static T TryDeserialize<T>(this string instance, T defaultValue = default(T), IFormatProvider formatProvider = null) where T: struct
		{
			instance = instance ?? string.Empty;
			formatProvider = formatProvider ?? CultureInfo.CurrentCulture;

			if (typeof (T) == typeof (bool))
			{
				if (string.Equals(instance, "true", StringComparison.CurrentCultureIgnoreCase))
				{
					return (T)(object)true;
				}

				if (string.Equals(instance, "false", StringComparison.CurrentCultureIgnoreCase))
				{
					return (T)(object)false;
				}

				return defaultValue;
			}

			if (typeof(T) == typeof(byte))
			{
				byte value;
				return (T)(byte.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(sbyte))
			{
				sbyte value;
				return (T)(sbyte.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(short))
			{
				short value;
				return (T)(short.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(ushort))
			{
				ushort value;
				return (T)(ushort.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(int))
			{
				int value;
				return (T)(int.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(uint))
			{
				uint value;
				return (T)(uint.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(long))
			{
				long value;
				return (T)(long.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(ulong))
			{
				ulong value;
				return (T)(ulong.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(float))
			{
				float value;
				return (T)(float.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(double))
			{
				double value;
				return (T)(double.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : (object)defaultValue);
			}

			if (typeof(T) == typeof(decimal))
			{
				decimal value;
				return (T)(decimal.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : (object)defaultValue);
			}

			// gk: in this implementation, this is terminal!!
			{
				T value;
				return Enum.TryParse(instance, true, out value) ? value : defaultValue;
			}
		}

		public static T? TryDeserializeOrNull<T>(this string instance, IFormatProvider formatProvider = null) where T : struct
		{
			instance = instance ?? string.Empty;
			formatProvider = formatProvider ?? CultureInfo.CurrentCulture;

			if (string.IsNullOrWhiteSpace(instance))
			{
				return null;
			}

			if (typeof(T) == typeof(bool))
			{
				bool value;
				return (T?)(bool.TryParse(instance, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(byte))
			{
				byte value;
				return (T?)(byte.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(sbyte))
			{
				sbyte value;
				return (T?)(sbyte.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(short))
			{
				short value;
				return (T?)(short.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(ushort))
			{
				ushort value;
				return (T?)(ushort.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(int))
			{
				int value;
				return (T?)(int.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(uint))
			{
				uint value;
				return (T?)(uint.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(long))
			{
				long value;
				return (T?)(long.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(ulong))
			{
				ulong value;
				return (T?)(ulong.TryParse(instance, NumberStyles.Integer, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(float))
			{
				float value;
				return (T?)(float.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(double))
			{
				double value;
				return (T?)(double.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(decimal))
			{
				decimal value;
				return (T?)(decimal.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : (object)null);
			}

			if (typeof(T) == typeof(DateTime))
			{
				DateTime value;
				return (T?)(DateTime.TryParse(instance, out value) ? value : (object)null);
			}

			// gk: in this implementation, this is terminal!!
			{
				T value;
				return Enum.TryParse(instance, true, out value) ? value : (T?)null;
			}
		}

		public static T? TryParse<T>(this string instance, [NotNull] TryParseFunc<T> parseFunc, T? defaultValue = null) where T : struct
		{
			if (parseFunc == null)
			{
				throw new ArgumentNullException(nameof(parseFunc));
			}

			if (string.IsNullOrEmpty(instance))
			{
				return null;
			}

			T t;
			if (!parseFunc(instance, out t))
			{
				return null;
			}

			return t;
		}

		public static TOut? TryTransform<TIn, TOut>(this TIn? instance, [NotNull] Func<TIn, TOut> transform, TOut? elseValue = null)
			where TIn : struct
			where TOut : struct
		{
			if (transform == null)
			{
				throw new ArgumentNullException(nameof(transform));
			}

			if (instance == null)
			{
				return elseValue;
			}

			return transform(instance.Value);
		}

		public static TOut TryTransform<TIn, TOut>(this TIn instance, [NotNull] Func<TIn, TOut> transform, TOut elseValue = default(TOut))
			where TIn : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException(nameof(transform));
			}

			if (instance == null)
			{
				return elseValue;
			}

			return transform(instance);
		}

		public static double TryDeserializeNumericValue(this string instance, double defaultValue = 0, IFormatProvider formatProvider = null)
		{
			instance = instance ?? string.Empty;
			formatProvider = formatProvider ?? CultureInfo.CurrentCulture;

			double value;
			return double.TryParse(instance, NumberStyles.Float, formatProvider, out value) ? value : defaultValue;
		}

		public static string WordWrap(this string instance, int wrapRight, string prefix = null, string firstPrefix = null)
		{
			if (instance == null)
			{
				return null;
			}

			var wrapLeft = (prefix?.Length).GetValueOrDefault();
			if (wrapRight <= wrapLeft)
			{
				throw new ArgumentOutOfRangeException(nameof(wrapRight));
			}

			var currentLine = firstPrefix ?? prefix ?? string.Empty;
			var lineLength = wrapRight - wrapLeft;
			var lines = new List<string>();

			var paragraphs = instance.Replace("\r", "").Split('\n');

			foreach (var paragraph in paragraphs)
			{
				var words = paragraph.Split(' ');
				foreach (var word in words)
				{
					if (currentLine.Length + word.Length + 1 > lineLength)
					{
						lines.Add(currentLine.TrimEnd());
						currentLine = string.Empty;
					}

					currentLine += word + ' ';

					while (currentLine.Length > lineLength)
					{
						currentLine = currentLine.TrimEnd();

						var chunk = currentLine.Substring(0, lineLength);
						var rest = currentLine.Substring(lineLength);

						lines.Add(chunk.TrimEnd());
						currentLine = rest + ' ';
					}
				}

				if (!string.IsNullOrWhiteSpace(currentLine))
				{
					lines.Add(currentLine);
				}

				currentLine = string.Empty;
			}

			return string.Join(Environment.NewLine, 
				lines.Take(1).Select(x => firstPrefix + x).Concat(
				lines.Skip(1).Select(x => prefix + x)));
		}

		public static string ToSingleLine(this string instance)
		{
			if (instance == null)
			{
				return null;
			}

			var text = instance.Replace("\r", "").Replace("\n", " ").Replace("\t", " ");
			var regex = new Regex(@"(\x20)\x20+", RegexOptions.Singleline);

			return regex.Replace(text, "$1");
		}

		public static string Escape(this string instance)
		{
			if (instance == null)
			{
				return null;
			}

			instance = instance.Replace("\\", @"\\" );
			instance = instance.Replace("\r", @"\r" );
			instance = instance.Replace("\n", @"\n" );
			instance = instance.Replace("\t", @"\t" );
			instance = instance.Replace("\0", @"\0" );
			instance = instance.Replace("\"", @"\""");

			return instance;
		}

		public static string Unescape(this string instance)
		{
			if (instance == null)
			{
				return null;
			}

			instance = Regex.Replace(instance, @"([^\\])\\r",   "$1\r");
			instance = Regex.Replace(instance, @"([^\\])\\n",   "$1\n");
			instance = Regex.Replace(instance, @"([^\\])\\t",   "$1\t");
			instance = Regex.Replace(instance, @"([^\\])\\0",   "$1\0");
			instance = Regex.Replace(instance, @"([^\\])\\""",  "$1\"");
			instance = Regex.Replace(instance, @"([^\\])\\\\",  "$1\\");

			return instance;
		}

		public static string NormalizeNull(this string instance)
		{
			return string.IsNullOrWhiteSpace(instance) ? null : instance;
		}

		public static string GetAcronym(this string instance, IDictionary<string, string> knownAbbreviations = null, int maxLength = int.MaxValue)
		{
			if (string.IsNullOrWhiteSpace(instance))
			{
				return instance?.Trim();
			}

			if (knownAbbreviations == null)
			{
				knownAbbreviations = new Dictionary<string, string>();
			}

			var result = string
				.Join("", instance
				.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => knownAbbreviations
					.GetValueByKeyOrDefault(x.ToLower(), new string(x[0], 1))?.ToUpper()));

			if (result.Length > maxLength)
			{
				result = result.Substring(0, maxLength);
			}

			return result;
		}

		public static string GetStringXmlCompliant(this string stringValue)
		{
			if (string.IsNullOrWhiteSpace(stringValue))
			{
				return stringValue;
			}

			for (var i = stringValue.Length - 1; i >= 0; i--)
			{
				//alle Kontrollzeichen außer Leertaste, Tab und Zeilenumbruch entfernen
				if (char.IsControl(stringValue, i) && stringValue[i] != ' ' && stringValue[i] != '\n' && stringValue[i] != '\t')
				{
					stringValue = stringValue.Remove(i, 1);
				}
			}

			return stringValue.Replace("<QM>", "\"").Replace("<CRLF>", "\n\r").Trim();
		}

		public static string Limit(this string stringValue, int maxLength = int.MaxValue)
		{
			if (string.IsNullOrWhiteSpace(stringValue))
			{
				return stringValue;
			}

			return stringValue.Length > maxLength ? stringValue.Substring(0, maxLength) : stringValue;
		}

		public static string ToRegexLiteral(this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}

			var sb = new StringBuilder();
			foreach (var c in input)
			{
				sb.AppendFormat("\\u{0:x4}", (ushort)c);
			}
			return sb.ToString();
		}

		public static string Concat(this IEnumerable<string> strings, string separator = " ")
		{
			var resultValue = string.Empty;
			if (strings == null)
			{
				return resultValue;
			}

			separator = separator ?? string.Empty;

			foreach (var str in strings)
			{
				var currentSeparator = string.IsNullOrWhiteSpace(resultValue)
					? string.Empty
					: separator;

				if (!string.IsNullOrWhiteSpace(str))
				{
					resultValue += currentSeparator + str;
				}
			}

			if (!string.IsNullOrEmpty(separator))
			{
				var reSeparator = separator.ToRegexLiteral();
				var reMoreThanOneSubsequentSeparator = $"{reSeparator}[{reSeparator}]+";

				resultValue = Regex.Replace(resultValue, reMoreThanOneSubsequentSeparator, separator);
			}

			return resultValue?.Trim();
		}
	}
}
