using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestProgressGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private AnimatedProgress progress;
		[SerializeField]
		private TextMeshProUGUI currentProgressValue;
		[SerializeField]
		private TextMeshProUGUI targetProgressValue;
		[SerializeField]
		private TextMeshProUGUI deltaProgressValue;
		[SerializeField]
		private Animator deltaProgressAnimator;
	}
}
