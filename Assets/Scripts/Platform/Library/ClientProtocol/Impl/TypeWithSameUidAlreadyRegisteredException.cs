using System;

namespace Platform.Library.ClientProtocol.Impl
{
	public class TypeWithSameUidAlreadyRegisteredException : Exception
	{
		public TypeWithSameUidAlreadyRegisteredException(long uid, Type existsType, Type type)
		{
		}

	}
}
