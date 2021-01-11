using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatMessageInputComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private void Start()
		{
			base.gameObject.SetActive(false);
			base.gameObject.SetActive(true);
		}
	}
}
