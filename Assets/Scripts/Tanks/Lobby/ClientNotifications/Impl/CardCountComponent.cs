using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientNotifications.Impl
{
	public class CardCountComponent : MonoBehaviour
	{
		[SerializeField]
		private AnimatedLong count;
		[SerializeField]
		private NewItemNotificationUnityComponent card;
	}
}
