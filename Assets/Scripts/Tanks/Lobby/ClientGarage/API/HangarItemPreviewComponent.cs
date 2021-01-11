using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class HangarItemPreviewComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject Instance
		{
			get;
			set;
		}
	}
}
