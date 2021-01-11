using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNotifications.Impl
{
	public class CardCountComponent : MonoBehaviour
	{
		[SerializeField]
		private AnimatedLong count;

		[SerializeField]
		private NewItemNotificationUnityComponent card;

		private void Awake()
		{
			count.SetImmediate(-1L);
			count.Value = card.GetComponent<NewItemNotificationUnityComponent>().count;
		}
	}
}
