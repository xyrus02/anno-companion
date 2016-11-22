using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Serialization;
using XyrusWorx.Collections;
using XyrusWorx.Gaming.AnnoCompanion.Data;

namespace XyrusWorx.Gaming.AnnoCompanion.Serialization
{
	class JsonReferenceResolver : IReferenceResolver, IInstancePool
	{
		private readonly Dictionary<StringKey, Persistable> mObjects;

		public JsonReferenceResolver()
		{
			mObjects = new Dictionary<StringKey, Persistable>();
		}

		public void Clear()
		{
			mObjects.Clear();
		}

		public void Register(Persistable obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj));
			}

			mObjects.AddOrUpdate(new StringKey(obj.Key), obj);
		}

		[CanBeNull]
		public Persistable Resolve(StringKey key)
		{
			if (key.IsEmpty)
			{
				return null;
			}

			return mObjects.GetValueByKeyOrDefault(key);
		}

		[NotNull]
		public IEnumerable<T> GetAll<T>() where T : Persistable
		{
			return mObjects.Values.OfType<T>();
		}

		[NotNull]
		public IEnumerable<Persistable> GetAll(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			return mObjects.Values.Where(type.IsInstanceOfType);
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
			return value.CastTo<Persistable>()?.Key;
		}
		bool IReferenceResolver.IsReferenced(object context, object value)
		{
			var key = value.CastTo<Persistable>()?.Key;

			if (string.IsNullOrWhiteSpace(key))
			{
				return false;
			}

			return mObjects.ContainsKey(new StringKey(key));
		}
		void IReferenceResolver.AddReference(object context, string reference, object value)
		{
			var io = value as Persistable;
			if (io == null)
			{
				return;
			}

			Register(io);
		}
	}
}