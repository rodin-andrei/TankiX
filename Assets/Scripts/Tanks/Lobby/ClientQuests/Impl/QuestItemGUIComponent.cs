using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestItemGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI taskText;
		[SerializeField]
		private TextMeshProUGUI conditionText;
		[SerializeField]
		private QuestProgressGUIComponent questProgressGUIComponent;
		[SerializeField]
		private QuestRewardGUIComponent questRewardGUIComponent;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private GameObject premiumBackground;
		[SerializeField]
		private TextMeshProUGUI questsCount;
		[SerializeField]
		private GameObject changeButton;
	}
}
