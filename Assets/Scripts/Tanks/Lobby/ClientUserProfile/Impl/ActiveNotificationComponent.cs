using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ActiveNotificationComponent : BehaviourComponent
	{
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private string showState;
		[SerializeField]
		private string hideState;
		[SerializeField]
		private Text text;
	}
}
