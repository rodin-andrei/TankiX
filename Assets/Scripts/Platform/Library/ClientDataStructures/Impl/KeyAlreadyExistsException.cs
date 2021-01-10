using System;

namespace Platform.Library.ClientDataStructures.Impl
{
	public class KeyAlreadyExistsException : ArgumentException
	{
		public KeyAlreadyExistsException(object key)
		{
		}

	}
}
