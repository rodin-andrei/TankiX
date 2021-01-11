using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class NotificationInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject Instance
		{
			get;
			set;
		}

		public NotificationInstanceComponent(GameObject instance)
		{
			Instance = instance;
		}
	}
}
