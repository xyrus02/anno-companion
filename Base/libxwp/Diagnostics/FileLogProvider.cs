using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using XW.Configuration;

namespace XW.Diagnostics
{
	[PublicAPI]
	public abstract class FileLogProvider : LogProvider
	{
		private readonly object mAppendSerializationLock = new object();

		private readonly IKeyedDomainStorage mStorage;
		private readonly string mKey;

		private readonly DelayQueue<string> mDelayWriter;

		protected FileLogProvider([NotNull] IKeyedDomainStorage storage, string key = null)
		{
			if (storage == null)
			{
				throw new ArgumentNullException(nameof(storage));
			}

			MaxLogFileLength = 268435456; // 256 MB
			mStorage = storage;
			mKey = key?.Trim();

			if (string.IsNullOrWhiteSpace(key))
			{
				mKey = @"application.log";
			}

			InitialOffset = mStorage.GetContainerLength(mKey);
			mDelayWriter = new DelayQueue<string>(TimeSpan.FromSeconds(2))
			{
				Callback = Append
			};
		}
		protected override void WriteOverride(string data)
		{
			try
			{
				var length = mStorage.GetContainerLength(mKey);
				if (!IgnoreMaxLogFileLength && length > MaxLogFileLength)
				{
					var baseName = Path.GetFileNameWithoutExtension(mKey);
					var extension = Path.GetExtension(mKey);

					var index = 1;
					var indexedName = $"{baseName}.{index}.{extension}";

					while (File.Exists(indexedName))
					{
						indexedName = $"{baseName}.{++index}.{extension}";
					}

					using (var source = mStorage.ReadContainer(mKey))
					using (var target = mStorage.WriteContainer(indexedName))
					{
						source.BaseStream.CopyTo(target.BaseStream);
					}

					mStorage.PurgeContainer(mKey);
				}

				if (mDelayWriter != null)
				{
					mDelayWriter.Enqueue(data);
				}
				else
				{
					Append(new [] { data });
				}
			}
			catch (Exception writeException)
			{
				new TraceLogProvider().WriteError(writeException);
			}
		}

		public StreamReader OpenStream()
		{
			return mStorage.ReadContainer(mKey);
		}

		public long InitialOffset { get; }
		public long MaxLogFileLength { get; set; }
		public virtual bool IgnoreMaxLogFileLength => false;
		public bool IsDelayed
		{
			get { return mDelayWriter.IsDelayEnabled; }
			set { mDelayWriter.IsDelayEnabled = value; }
		}

		private void Append(IList<string> lines)
		{
			lock (mAppendSerializationLock)
			{
				using (var writer = mStorage.AppendToContainer(mKey))
				{
					foreach (var line in lines)
					{
						writer.Write($"{line}{Environment.NewLine}");
					}
				}
			}
		}

		protected override void CleanupOverride()
		{
			mDelayWriter.Dispose();
		}
	}
}