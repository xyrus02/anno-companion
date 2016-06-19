using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;
using JetBrains.Annotations;
using XW.Configuration;

namespace XW
{
	[PublicAPI]
	public class UwpStorage : IKeyedDomainStorage
	{
		private const int mTaskTimeout = 2000;
		private readonly StorageFolder mWinrtStorageFolder;
		private readonly bool mIsReadOnly;

		public UwpStorage([NotNull] StorageFolder winrtStorageFolder, bool isReadOnly = false)
		{
			if (winrtStorageFolder == null)
			{
				throw new ArgumentNullException(nameof(winrtStorageFolder));
			}

			mWinrtStorageFolder = winrtStorageFolder;
			mIsReadOnly = isReadOnly;
		}

		public Encoding Encoding { get; set; } = Encoding.UTF8;
		public bool IsReadOnly => mIsReadOnly;

		public StreamReader ReadContainer(string key)
		{
			var task = ReadContainerAsync(key);

			task.Wait(mTaskTimeout);

			return task.Result;
		}
		public StreamWriter WriteContainer(string key)
		{
			var task = WriteContainerAsync(key);

			task.Wait(mTaskTimeout);

			return task.Result;
		}
		public StreamWriter AppendToContainer(string key)
		{
			var task = AppendToContainerAsync(key);

			task.Wait(mTaskTimeout);

			return task.Result;
		}

		public bool HasContainer(string key)
		{
			var task = HasContainerAsync(key);

			task.Wait(mTaskTimeout);

			return task.Result;
		}
		public void PurgeContainer(string key)
		{
			var task = PurgeContainerAsync(key);

			task.Wait(mTaskTimeout);
		}
		public long GetContainerLength(string key)
		{
			var task = GetContainerLengthAsync(key);

			task.Wait(mTaskTimeout);

			return task.Result;
		}

		public IEnumerable<string> GetKeys()
		{
			var task = GetKeysAsync();

			task.Wait(mTaskTimeout);

			return task.Result;
		}
		public IKeyedDomainStorage CreateChildStorage(string key, bool? isReadOnly = null)
		{
			var task = CreateChildStorageAsync(key, isReadOnly);

			task.Wait(mTaskTimeout);

			return task.Result;
		}

		public async Task<StreamReader> ReadContainerAsync(string key)
		{
			try
			{
				var item = await mWinrtStorageFolder.CreateFileAsync(key, CreationCollisionOption.OpenIfExists);
				if (item != null)
				{
					return new StreamReader(await item.OpenStreamForReadAsync(), Encoding ?? Encoding.UTF8);
				}
			}
			catch(FileNotFoundException)
			{
				// ignored
			}
			
			return new StreamReader(new MemoryStream());
		}
		public async Task<StreamWriter> WriteContainerAsync(string key)
		{
			if (IsReadOnly)
			{
				throw new InvalidOperationException(Messages.ErrReadonlyStorage);
			}

			try
			{
				var item = await mWinrtStorageFolder.CreateFileAsync(key, CreationCollisionOption.ReplaceExisting);
				if (item != null)
				{
					return new StreamWriter(await item.OpenStreamForWriteAsync());
				}
			}
			catch (FileNotFoundException)
			{
				// ignored
			}

			return new StreamWriter(new MemoryStream(), Encoding ?? Encoding.UTF8);
		}
		public async Task<StreamWriter> AppendToContainerAsync(string key)
		{
			if (IsReadOnly)
			{
				throw new InvalidOperationException(Messages.ErrReadonlyStorage);
			}

			try
			{
				var item = await mWinrtStorageFolder.CreateFileAsync(key, CreationCollisionOption.OpenIfExists);
				if (item != null)
				{
					var stream = await item.OpenStreamForWriteAsync();

					stream.Seek(0, SeekOrigin.End);

					return new StreamWriter(stream, Encoding ?? Encoding.UTF8);
				}
			}
			catch (FileNotFoundException)
			{
				// ignored
			}

			return new StreamWriter(new MemoryStream());
		}

		public async Task<bool> HasContainerAsync(string key)
		{
			try
			{
				var item = await mWinrtStorageFolder.GetFileAsync(key);
				if (item != null)
				{
					return true;
				}
			}
			catch (FileNotFoundException)
			{
				// ignored
			}

			return false;
		}
		public async Task<bool> PurgeContainerAsync(string key)
		{
			if (IsReadOnly)
			{
				throw new InvalidOperationException(Messages.ErrReadonlyStorage);
			}

			try
			{
				var item = await mWinrtStorageFolder.GetFileAsync(key);
				if (item != null)
				{
					await item.DeleteAsync(StorageDeleteOption.PermanentDelete);
					return true;
				}
			}
			catch (FileNotFoundException)
			{
				// ignored
			}

			return false;
		}
		public async Task<long> GetContainerLengthAsync(string key)
		{
			try
			{
				var item = await mWinrtStorageFolder.GetFileAsync(key);
				if (item != null)
				{
					using (var stream = await item.OpenReadAsync())
					{
						return (long)stream.Size;
					}
				}
			}
			catch (FileNotFoundException)
			{
				// ignored
			}

			return 0;
		}

		public async Task<IEnumerable<string>> GetKeysAsync()
		{
			var query = mWinrtStorageFolder.CreateFileQuery(CommonFileQuery.DefaultQuery);
			var items = await query.GetFilesAsync();

			return items.Select(x => x.Name).ToArray();
		}
		public async Task<IKeyedDomainStorage> CreateChildStorageAsync(string key, bool? isReadOnly = null)
		{
			var folder = await mWinrtStorageFolder.CreateFolderAsync(key, CreationCollisionOption.OpenIfExists);
			if (folder == null)
			{
				throw new DirectoryNotFoundException();
			}

			return new UwpStorage(folder, isReadOnly ?? IsReadOnly);
		}

		public object GetPhysicalLocator()
		{
			return mWinrtStorageFolder.Path;
		}
	}
}