using System;

namespace Platform.Library.ClientDataStructures.API
{
	public class TypeByIdRegistry
	{
		private readonly IBiMap<Type, long> storage = new HashBiMap<Type, long>();

		private readonly Func<Type, long> idGenerator;

		public TypeByIdRegistry(Func<Type, long> idGenerator)
		{
			this.idGenerator = idGenerator;
		}

		protected virtual long Register(Type clazz)
		{
			long value;
			if (storage.TryGetValue(clazz, out value))
			{
				return value;
			}
			value = idGenerator(clazz);
			if (storage.Inverse.ContainsKey(value))
			{
				throw new TypeAlreadyRegisteredException(clazz);
			}
			storage.Add(clazz, value);
			return value;
		}

		protected virtual long GetId(Type clazz)
		{
			long value;
			if (storage.TryGetValue(clazz, out value))
			{
				return value;
			}
			return Register(clazz);
		}

		protected internal virtual Type GetClass(long id)
		{
			Type value;
			if (storage.Inverse.TryGetValue(id, out value))
			{
				return value;
			}
			throw new ClassNotFoundException(id);
		}
	}
}
