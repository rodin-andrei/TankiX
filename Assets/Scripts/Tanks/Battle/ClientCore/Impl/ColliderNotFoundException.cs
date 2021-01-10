using System;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ColliderNotFoundException : Exception
	{
		public ColliderNotFoundException(TankCollidersUnityComponent tankColliders, string colliderName)
		{
		}

	}
}
