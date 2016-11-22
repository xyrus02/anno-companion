using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using XyrusWorx.IO;

namespace XyrusWorx.Gaming.AnnoCompanion.Data
{
	[PublicAPI]
	public class EmbeddedBlobStore : BlobStore
	{
		private readonly EmbeddedBlobStoreNamespace mData;

		public EmbeddedBlobStore([NotNull] Assembly assembly, StringKeySequence basePath = default(StringKeySequence))
		{
			if (assembly == null)
			{
				throw new ArgumentNullException(nameof(assembly));
			}

			mData = CreateHierarchicalStoreFromManifestResourceNames(assembly, basePath);
		}

		public override bool Exists(StringKey key) => mData.Exists(key);
		public override void Erase(StringKey key)
		{
			throw new NotSupportedException();
		}

		protected override BinaryReader OpenBinaryReader(StringKey key) => mData.Open(key).Read();
		protected override BinaryWriter OpenBinaryAppender(StringKey key)
		{
			throw new NotSupportedException();
		}
		protected override IEnumerable<StringKey> Enumerate() => mData.Keys.Select(x => x.AsKey());

		[SuppressMessage("ReSharper", "OptionalParameterHierarchyMismatch")]
		public override IBlobStore GetChildStore(StringKey childStorageKey, bool? isReadOnly = null) => mData.GetChildStore(childStorageKey, isReadOnly);
		public override IEnumerable<StringKey> GetChildStoreKeys() => mData.GetChildStoreKeys();
		public override bool HasChildStore(StringKey childStorageKey) => mData.HasChildStore(childStorageKey);

		public override StringKeySequence Identifier => mData.Identifier;

		private EmbeddedBlobStoreNamespace CreateHierarchicalStoreFromManifestResourceNames(Assembly assembly, StringKeySequence basePath)
		{
			var resourceNames = assembly.GetManifestResourceNames();
			var baseName = assembly.GetTypes().Select(x => x.Namespace).Distinct().Where(x => resourceNames.Any(y => y.StartsWith(x))).OrderBy(x => x.Length).FirstOrDefault();

			if (!basePath.IsEmpty)
			{
				baseName += "." + basePath.ToString(".");
			}

			StringKeySequence rootName;

			if (string.IsNullOrWhiteSpace(baseName))
			{
				rootName = new StringKeySequence();
			}
			else
			{
				rootName = new StringKeySequence(baseName.Split('.'));
			}

			var names = new HashSet<StringKeySequence>(resourceNames.Select(x => CreateKeySequence(baseName, x)).OrderBy(x => x.Segments.Length));
			if (names.Count == 0)
			{
				return new EmbeddedBlobStoreNamespace(rootName, new StringKeySequence(),  assembly, new Dictionary<StringKey, EmbeddedBlobStoreNamespace>(), new StringKey[0]);
			}

			var leafNames = new HashSet<StringKeySequence>(
				from ancestor in names

				let directDescendants =
					from descendant in names

					let isNextLevelDescendant = descendant.Segments.Length == ancestor.Segments.Length + 1
					let isDescendantInAncestorSet = descendant.ToString().StartsWith(ancestor.ToString())

					where isNextLevelDescendant && isDescendantInAncestorSet

					select descendant

				where !directDescendants.Any()
				select ancestor);

			var branchNames = new HashSet<StringKeySequence>();

			foreach (var leafName in leafNames)
			{
				for (var i = 0; i < leafName.Segments.Length - 1; i++)
				{
					var partialName = new StringKeySequence(leafName.Segments.Take(i + 1).ToArray());

					branchNames.Add(partialName);
				}
			}

			if (branchNames.Count == 0)
			{
				return new EmbeddedBlobStoreNamespace(rootName, new StringKeySequence(),  assembly, new Dictionary<StringKey, EmbeddedBlobStoreNamespace>(), leafNames.Select(x => x.ToString(".").AsKey()));
			}

			var structure =
				from branch in branchNames

				let childBranches =
				from childBranch in branchNames

				let isNextLevelDescendant = childBranch.Segments.Length == branch.Segments.Length + 1
				let isDescendantInAncestorSet = childBranch.ToString().StartsWith(branch.ToString())

				where isNextLevelDescendant && isDescendantInAncestorSet

				select childBranch

				let childLeaves =
				from childLeaf in leafNames

				let isNextLevelDescendant = childLeaf.Segments.Length == branch.Segments.Length + 1
				let isDescendantInAncestorSet = childLeaf.ToString().StartsWith(branch.ToString())

				where isNextLevelDescendant && isDescendantInAncestorSet

				select childLeaf

				let sortKey = childBranches.Any() ? 0 : 1
				let level = branch.Segments.Length

				orderby sortKey ascending
				orderby level descending

				select new
				{
					Name = branch,
					Branches = childBranches,
					Leaves = childLeaves,
					Level = level
				};

			var branchDictionary = new Dictionary<StringKeySequence, EmbeddedBlobStoreNamespace>();

			foreach (var element in structure)
			{
				var directChildren = element.Branches.ToDictionary(x => x.Segments.Last(), x => branchDictionary[x]);
				var childLeaves = element.Leaves.Select(x => x.Segments.Last()).ToArray();
				var container = new EmbeddedBlobStoreNamespace(rootName, element.Name, assembly, directChildren, childLeaves);

				branchDictionary.Add(element.Name, container);
			}

			var minLength = branchDictionary.Min(x => x.Key.Segments.Length);
			var bottomLevelBranches = branchDictionary.Where(x => x.Key.Segments.Length == minLength);
			var bottomLevelLeaves = leafNames.Where(x => x.Segments.Length == minLength);

			return new EmbeddedBlobStoreNamespace(
				rootName, 
				new StringKeySequence(), 
				assembly,
				bottomLevelBranches.ToDictionary(x => x.Key.Segments.Last(), x => x.Value), 
				bottomLevelLeaves.Select(x => x.Segments.Last()));
		}
		private StringKeySequence CreateKeySequence(string baseName, string qualifiedName)
		{
			if (qualifiedName.StartsWith(baseName + "."))
			{
				qualifiedName = qualifiedName.Substring(baseName.Length + 1);
			}

			var tokens = qualifiedName.Split('.');
			var lastToken = tokens.Last();

			if (!Regex.IsMatch(lastToken, @"^[A-Z].*$"))
			{
				// assume that last token is file ending when it doesn't start with an uppercase letter
				tokens = tokens.Take(tokens.Length - 1).ToArray();
				tokens[tokens.Length - 1] += "." + lastToken;
			}

			return new StringKeySequence(tokens);
		}
	}
}