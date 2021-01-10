using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class InBattleQuestItemGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI taskText;
		[SerializeField]
		private ImageSkin taskImageSkin;
		[SerializeField]
		private TextMeshProUGUI currentProgressValue;
		[SerializeField]
		private TextMeshProUGUI targetProgressValue;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private InBattleQuestItemGUIRewardContainerComponent rewardContainer;
	}
}
