using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class MD5 : IDisposable
	{
		private const byte mS11 = 7;
		private const byte mS12 = 12;
		private const byte mS13 = 17;
		private const byte mS14 = 22;
		private const byte mS21 = 5;
		private const byte mS22 = 9;
		private const byte mS23 = 14;
		private const byte mS24 = 20;
		private const byte mS31 = 4;
		private const byte mS32 = 11;
		private const byte mS33 = 16;
		private const byte mS34 = 23;
		private const byte mS41 = 6;
		private const byte mS42 = 10;
		private const byte mS43 = 15;
		private const byte mS44 = 21;

		private static byte[] mPadding =
		{
			0x80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
		};

		protected int HashSizeValue = 128;

		protected byte[] HashValue;
		private byte[] mBuffer = new byte[64];
		private uint[] mCount = new uint[2];


		private uint[] mState = new uint[4];
		protected int State;

		internal MD5()
		{
			Initialize();
		}

		public bool CanReuseTransform => true;
		public bool CanTransformMultipleBlocks => true;

		public byte[] Hash
		{
			get
			{
				if (State != 0)
					throw new InvalidOperationException();
				return (byte[]) HashValue.Clone();
			}
		}

		public int HashSize => HashSizeValue;
		public int InputBlockSize => 1;
		public int OutputBlockSize => 1;

		public void Dispose()
		{
			Dispose(true);
		}
		private void Dispose(bool disposing)
		{
			if (!disposing)
			{
				Initialize();
			}
		}

		public static MD5 Create()
		{
			return new MD5();
		}
		public static MD5 Create(string hashName)
		{
			if (hashName == "MD5")
			{
				return new MD5();
			}

			throw new NotSupportedException();
		}
		public static string GetMd5String(string source)
		{
			var md = Create();
			var enc = new UTF8Encoding();

			var buffer = enc.GetBytes(source);
			var hash = md.ComputeHash(buffer);

			var sb = new StringBuilder();

			foreach (var b in hash)
			{
				sb.Append(b.ToString("x2"));
			}

			return sb.ToString();
		}

		private static uint F(uint x, uint y, uint z) => (x & y) | (~x & z);
		private static uint G(uint x, uint y, uint z) => (x & z) | (y & ~z);
		private static uint H(uint x, uint y, uint z) => x ^ y ^ z;
		private static uint I(uint x, uint y, uint z) => y ^ (x | ~z);

		private static uint RotateLeft(uint x, byte n)
		{
			return (x << n) | (x >> (32 - n));
		}

		[SuppressMessage("ReSharper", "InconsistentNaming")]
		private static void FF(ref uint a, uint b, uint c, uint d, uint x, byte s, uint ac)
		{
			a += F(b, c, d) + x + ac;
			a = RotateLeft(a, s);
			a += b;
		}

		[SuppressMessage("ReSharper", "InconsistentNaming")]
		private static void GG(ref uint a, uint b, uint c, uint d, uint x, byte s, uint ac)
		{
			a += G(b, c, d) + x + ac;
			a = RotateLeft(a, s);
			a += b;
		}

		[SuppressMessage("ReSharper", "InconsistentNaming")]
		private static void HH(ref uint a, uint b, uint c, uint d, uint x, byte s, uint ac)
		{
			a += H(b, c, d) + x + ac;
			a = RotateLeft(a, s);
			a += b;
		}

		[SuppressMessage("ReSharper", "InconsistentNaming")]
		private static void II(ref uint a, uint b, uint c, uint d, uint x, byte s, uint ac)
		{
			a += I(b, c, d) + x + ac;
			a = RotateLeft(a, s);
			a += b;
		}

		private void Initialize()
		{
			mCount[0] = mCount[1] = 0;

			// Load magic initialization constants.
			mState[0] = 0x67452301;
			mState[1] = 0xefcdab89;
			mState[2] = 0x98badcfe;
			mState[3] = 0x10325476;
		}

		protected void HashCore(byte[] input, int offset, int count)
		{
			int i;
			int index;
			int partLen;

			// Compute number of bytes mod 64
			index = (int) ((mCount[0] >> 3) & 0x3F);

			// Update number of bits
			if ((mCount[0] += (uint) count << 3) < (uint) count << 3)
				mCount[1]++;
			mCount[1] += (uint) count >> 29;

			partLen = 64 - index;

			// Transform as many times as possible.
			if (count >= partLen)
			{
				Buffer.BlockCopy(input, offset, mBuffer, index, partLen);
				Transform(mBuffer, 0);

				for (i = partLen; i + 63 < count; i += 64)
					Transform(input, offset + i);

				index = 0;
			}
			else
				i = 0;

			// Buffer remaining input
			Buffer.BlockCopy(input, offset + i, mBuffer, index, count - i);
		}
		protected byte[] HashFinal()
		{
			var digest = new byte[16];
			var bits = new byte[8];
			int index, padLen;

			// Save number of bits
			Encode(bits, 0, mCount, 0, 8);

			// Pad out to 56 mod 64.
			index = (int) (mCount[0] >> 3 & 0x3f);
			padLen = index < 56 ? 56 - index : 120 - index;
			HashCore(mPadding, 0, padLen);

			// Append length (before padding)
			HashCore(bits, 0, 8);

			// Store state in digest
			Encode(digest, 0, mState, 0, 16);

			// Zeroize sensitive information.
			mCount[0] = mCount[1] = 0;
			mState[0] = 0;
			mState[1] = 0;
			mState[2] = 0;
			mState[3] = 0;

			// initialize again, to be ready to use
			Initialize();

			return digest;
		}

		private void Transform(byte[] block, int offset)
		{
			uint a = mState[0], b = mState[1], c = mState[2], d = mState[3];
			var x = new uint[16];
			Decode(x, 0, block, offset, 64);

			// Round 1
			FF(ref a, b, c, d, x[0], mS11, 0xd76aa478); /* 1 */
			FF(ref d, a, b, c, x[1], mS12, 0xe8c7b756); /* 2 */
			FF(ref c, d, a, b, x[2], mS13, 0x242070db); /* 3 */
			FF(ref b, c, d, a, x[3], mS14, 0xc1bdceee); /* 4 */
			FF(ref a, b, c, d, x[4], mS11, 0xf57c0faf); /* 5 */
			FF(ref d, a, b, c, x[5], mS12, 0x4787c62a); /* 6 */
			FF(ref c, d, a, b, x[6], mS13, 0xa8304613); /* 7 */
			FF(ref b, c, d, a, x[7], mS14, 0xfd469501); /* 8 */
			FF(ref a, b, c, d, x[8], mS11, 0x698098d8); /* 9 */
			FF(ref d, a, b, c, x[9], mS12, 0x8b44f7af); /* 10 */
			FF(ref c, d, a, b, x[10], mS13, 0xffff5bb1); /* 11 */
			FF(ref b, c, d, a, x[11], mS14, 0x895cd7be); /* 12 */
			FF(ref a, b, c, d, x[12], mS11, 0x6b901122); /* 13 */
			FF(ref d, a, b, c, x[13], mS12, 0xfd987193); /* 14 */
			FF(ref c, d, a, b, x[14], mS13, 0xa679438e); /* 15 */
			FF(ref b, c, d, a, x[15], mS14, 0x49b40821); /* 16 */

			// Round 2
			GG(ref a, b, c, d, x[1], mS21, 0xf61e2562); /* 17 */
			GG(ref d, a, b, c, x[6], mS22, 0xc040b340); /* 18 */
			GG(ref c, d, a, b, x[11], mS23, 0x265e5a51); /* 19 */
			GG(ref b, c, d, a, x[0], mS24, 0xe9b6c7aa); /* 20 */
			GG(ref a, b, c, d, x[5], mS21, 0xd62f105d); /* 21 */
			GG(ref d, a, b, c, x[10], mS22, 0x2441453); /* 22 */
			GG(ref c, d, a, b, x[15], mS23, 0xd8a1e681); /* 23 */
			GG(ref b, c, d, a, x[4], mS24, 0xe7d3fbc8); /* 24 */
			GG(ref a, b, c, d, x[9], mS21, 0x21e1cde6); /* 25 */
			GG(ref d, a, b, c, x[14], mS22, 0xc33707d6); /* 26 */
			GG(ref c, d, a, b, x[3], mS23, 0xf4d50d87); /* 27 */
			GG(ref b, c, d, a, x[8], mS24, 0x455a14ed); /* 28 */
			GG(ref a, b, c, d, x[13], mS21, 0xa9e3e905); /* 29 */
			GG(ref d, a, b, c, x[2], mS22, 0xfcefa3f8); /* 30 */
			GG(ref c, d, a, b, x[7], mS23, 0x676f02d9); /* 31 */
			GG(ref b, c, d, a, x[12], mS24, 0x8d2a4c8a); /* 32 */

			// Round 3
			HH(ref a, b, c, d, x[5], mS31, 0xfffa3942); /* 33 */
			HH(ref d, a, b, c, x[8], mS32, 0x8771f681); /* 34 */
			HH(ref c, d, a, b, x[11], mS33, 0x6d9d6122); /* 35 */
			HH(ref b, c, d, a, x[14], mS34, 0xfde5380c); /* 36 */
			HH(ref a, b, c, d, x[1], mS31, 0xa4beea44); /* 37 */
			HH(ref d, a, b, c, x[4], mS32, 0x4bdecfa9); /* 38 */
			HH(ref c, d, a, b, x[7], mS33, 0xf6bb4b60); /* 39 */
			HH(ref b, c, d, a, x[10], mS34, 0xbebfbc70); /* 40 */
			HH(ref a, b, c, d, x[13], mS31, 0x289b7ec6); /* 41 */
			HH(ref d, a, b, c, x[0], mS32, 0xeaa127fa); /* 42 */
			HH(ref c, d, a, b, x[3], mS33, 0xd4ef3085); /* 43 */
			HH(ref b, c, d, a, x[6], mS34, 0x4881d05); /* 44 */
			HH(ref a, b, c, d, x[9], mS31, 0xd9d4d039); /* 45 */
			HH(ref d, a, b, c, x[12], mS32, 0xe6db99e5); /* 46 */
			HH(ref c, d, a, b, x[15], mS33, 0x1fa27cf8); /* 47 */
			HH(ref b, c, d, a, x[2], mS34, 0xc4ac5665); /* 48 */

			// Round 4
			II(ref a, b, c, d, x[0], mS41, 0xf4292244); /* 49 */
			II(ref d, a, b, c, x[7], mS42, 0x432aff97); /* 50 */
			II(ref c, d, a, b, x[14], mS43, 0xab9423a7); /* 51 */
			II(ref b, c, d, a, x[5], mS44, 0xfc93a039); /* 52 */
			II(ref a, b, c, d, x[12], mS41, 0x655b59c3); /* 53 */
			II(ref d, a, b, c, x[3], mS42, 0x8f0ccc92); /* 54 */
			II(ref c, d, a, b, x[10], mS43, 0xffeff47d); /* 55 */
			II(ref b, c, d, a, x[1], mS44, 0x85845dd1); /* 56 */
			II(ref a, b, c, d, x[8], mS41, 0x6fa87e4f); /* 57 */
			II(ref d, a, b, c, x[15], mS42, 0xfe2ce6e0); /* 58 */
			II(ref c, d, a, b, x[6], mS43, 0xa3014314); /* 59 */
			II(ref b, c, d, a, x[13], mS44, 0x4e0811a1); /* 60 */
			II(ref a, b, c, d, x[4], mS41, 0xf7537e82); /* 61 */
			II(ref d, a, b, c, x[11], mS42, 0xbd3af235); /* 62 */
			II(ref c, d, a, b, x[2], mS43, 0x2ad7d2bb); /* 63 */
			II(ref b, c, d, a, x[9], mS44, 0xeb86d391); /* 64 */

			mState[0] += a;
			mState[1] += b;
			mState[2] += c;
			mState[3] += d;

			// Zeroize sensitive information.
			for (var i = 0; i < x.Length; i++)
				x[i] = 0;
		}

		private static void Encode(byte[] output, int outputOffset, uint[] input, int inputOffset, int count)
		{
			int i, j;
			var end = outputOffset + count;
			for (i = inputOffset, j = outputOffset; j < end; i++, j += 4)
			{
				output[j] = (byte) (input[i] & 0xff);
				output[j + 1] = (byte) ((input[i] >> 8) & 0xff);
				output[j + 2] = (byte) ((input[i] >> 16) & 0xff);
				output[j + 3] = (byte) ((input[i] >> 24) & 0xff);
			}
		}
		private static void Decode(uint[] output, int outputOffset, byte[] input, int inputOffset, int count)
		{
			int i, j;
			var end = inputOffset + count;
			for (i = outputOffset, j = inputOffset; j < end; i++, j += 4)
				output[i] = input[j] | ((uint) input[j + 1] << 8) | ((uint) input[j + 2] << 16) | ((uint) input[j + 3] << 24);
		}

		public void Clear()
		{
			Dispose(true);
		}

		public byte[] ComputeHash(byte[] buffer)
		{
			return ComputeHash(buffer, 0, buffer.Length);
		}
		public byte[] ComputeHash(byte[] buffer, int offset, int count)
		{
			Initialize();
			HashCore(buffer, offset, count);
			HashValue = HashFinal();
			return (byte[]) HashValue.Clone();
		}
		public byte[] ComputeHash(Stream inputStream)
		{
			Initialize();
			int count;
			var buffer = new byte[4096];
			while (0 < (count = inputStream.Read(buffer, 0, 4096)))
			{
				HashCore(buffer, 0, count);
			}
			HashValue = HashFinal();
			return (byte[]) HashValue.Clone();
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			if (inputBuffer == null)
			{
				throw new ArgumentNullException("inputBuffer");
			}
			if (inputOffset < 0)
			{
				throw new ArgumentOutOfRangeException("inputOffset");
			}
			if ((inputCount < 0) || (inputCount > inputBuffer.Length))
			{
				throw new ArgumentException("inputCount");
			}
			if (inputBuffer.Length - inputCount < inputOffset)
			{
				throw new ArgumentOutOfRangeException("inputOffset");
			}
			if (State == 0)
			{
				Initialize();
				State = 1;
			}

			HashCore(inputBuffer, inputOffset, inputCount);
			if ((inputBuffer != outputBuffer) || (inputOffset != outputOffset))
			{
				Buffer.BlockCopy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
			}
			return inputCount;
		}
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			if (inputBuffer == null)
			{
				throw new ArgumentNullException("inputBuffer");
			}
			if (inputOffset < 0)
			{
				throw new ArgumentOutOfRangeException("inputOffset");
			}
			if ((inputCount < 0) || (inputCount > inputBuffer.Length))
			{
				throw new ArgumentException("inputCount");
			}
			if (inputBuffer.Length - inputCount < inputOffset)
			{
				throw new ArgumentOutOfRangeException("inputOffset");
			}
			if (State == 0)
			{
				Initialize();
			}
			HashCore(inputBuffer, inputOffset, inputCount);
			HashValue = HashFinal();
			var buffer = new byte[inputCount];
			Buffer.BlockCopy(inputBuffer, inputOffset, buffer, 0, inputCount);
			State = 0;
			return buffer;
		}
	}
}