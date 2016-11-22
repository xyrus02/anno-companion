using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	class EmbeddedBlobStoreNamespace : BlobStore
	{
		private StringKeySequence mName;

		private readonly Assembly mAssembly;
		private readonly IDictionary<StringKey, EmbeddedBlobStoreNamespace> mChildren;
		private readonly HashSet<StringKey> mNames;

		internal EmbeddedBlobStoreNamespace(
			StringKeySequence name, 
			[NotNull] Assembly assembly, 
			[NotNull] IDictionary<StringKey, EmbeddedBlobStoreNamespace> children, 
			[NotNull] IEnumerable<StringKey> names)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException(nameof(assembly));
			}

			if (children == null)
			{
				throw new ArgumentNullException(nameof(children));
			}

			if (names == null)
			{
				throw new ArgumentNullException(nameof(names));
			}

			mAssembly = assembly;
			mName = name;
			mChildren = children;
			mNames = new HashSet<StringKey>(names);
		}

		public override bool Exists(StringKey key)
		{
			return mNames.Contains(key);
		}
		public override void Erase(StringKey key)
		{
			throw new NotSupportedException();
		}

		protected override BinaryReader OpenBinaryReader(StringKey key)
		{
			var completeName = mName.Concat(key).ToString(".");

			var stream = mAssembly.GetManifestResourceStream(completeName);
			if (stream == null)
			{
				return new BinaryReader(new MemoryStream());
			}

			return new BinaryReader(stream);
		}
		protected override BinaryWriter OpenBinaryAppender(StringKey key)
		{
			throw new NotSupportedException();
		}
		protected override IEnumerable<StringKey> Enumerate()
		{
			return mNames;
		}

		[SuppressMessage("ReSharper", "OptionalParameterHierarchyMismatch")]
		public override IBlobStore GetChildStore(StringKey childStorageKey, bool? isReadOnly = null)
		{
			if (!mChildren.ContainsKey(childStorageKey))
			{
				return new NullStorage();
			}

			return mChildren[childStorageKey];
		}
		public override IEnumerable<StringKey> GetChildStoreKeys()
		{
			return mChildren.Keys;
		}
		public override bool HasChildStore(StringKey childStorageKey)
		{
			return mChildren.ContainsKey(childStorageKey);
		}

		public override StringKeySequence Identifier => mName;
	}
}