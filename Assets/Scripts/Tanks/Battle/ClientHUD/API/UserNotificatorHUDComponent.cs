using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public class UserNotificatorHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private UserRankNotificationMessageBehaviour userRankNotificationMessagePrefab;
		[SerializeField]
		private CanvasGroup serviseMessagesCanvasGroup;
		[SerializeField]
		private float serviceMessagesFadeTime;
	}
}
