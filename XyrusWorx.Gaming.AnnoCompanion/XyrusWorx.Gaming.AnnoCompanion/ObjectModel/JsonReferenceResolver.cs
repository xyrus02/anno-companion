using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Serialization;
using XyrusWorx.Collections;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	class JsonReferenceResolver : IReferenceResolver
	{
		private readonly Dictionary<StringKey, IndexedObject> mObjects;

		public JsonReferenceResolver()
		{
			mObjects = new Dictionary<StringKey, IndexedObject>();
		}

		public void Clear()
		{
			mObjects.Clear();
		}

		public void Register([NotNull] IndexedObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj));
			}

			mObjects.AddOrUpdate(new StringKey(obj.Key), obj);
		}

		[CanBeNull]
		public IndexedObject Resolve(StringKey key)
		{
			return mObjects.GetValueByKeyOrDefault(key);
		}

		[NotNull]
		public IEnumerable<T> GetAll<T>() where T : IndexedObject
		{
			return mObjects.Values.OfType<T>();
		}

		object IReferenceResolver.ResolveReference(object context, string reference)
		{
			if (string.IsNullOrWhiteSpace(reference))
			{
				return null;
			}

			return Resolve(new StringKey(reference));
		}
		string IReferenceResolver.GetReference(object context, object value)
		{
			return value.CastTo<IndexedObject>()?.Key;
		}
		bool IReferenceResolver.IsReferenced(object context, object value)
		{
			var key = value.CastTo<IndexedObject>()?.Key;

			if (string.IsNullOrWhiteSpace(key))
			{
				return false;
			}

			return mObjects.ContainsKey(new StringKey(key));
		}
		void IReferenceResolver.AddReference(object context, string reference, object value)
		{
			var io = value as IndexedObject;
			if (io == null)
			{
				return;
			}

			Register(io);
		}
	}
}