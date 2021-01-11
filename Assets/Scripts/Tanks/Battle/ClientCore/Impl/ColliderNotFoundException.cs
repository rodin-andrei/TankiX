using System;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ColliderNotFoundException : Exception
	{
		public TankCollidersUnityComponent TankColliders
		{
			get;
			set;
		}

		public string ColliderName
		{
			get;
			set;
		}

		public ColliderNotFoundException(TankCollidersUnityComponent tankColliders, string colliderName)
			: base(string.Concat("TankColliders=", tankColliders, " colliderName=", colliderName))
		{
			TankColliders = tankColliders;
			ColliderName = colliderName;
		}
	}
}
