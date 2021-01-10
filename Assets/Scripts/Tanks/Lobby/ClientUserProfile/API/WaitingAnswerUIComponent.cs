using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class WaitingAnswerUIComponent : BehaviourComponent
	{
		[SerializeField]
		protected Slider slider;
		[SerializeField]
		protected GameObject waitingIcon;
		[SerializeField]
		protected GameObject inviteButton;
		[SerializeField]
		protected GameObject alreadyInLabel;
		public float maxTimerValue;
	}
}
