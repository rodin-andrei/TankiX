using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewCardNotificationComponent : BehaviourComponent
	{
		[SerializeField]
		private bool clickAnywhere;
		[SerializeField]
		private Transform container;
	}
}
