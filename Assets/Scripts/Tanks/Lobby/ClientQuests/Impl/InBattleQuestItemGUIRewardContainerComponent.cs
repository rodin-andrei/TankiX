using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class InBattleQuestItemGUIRewardContainerComponent : MonoBehaviour
	{
		[SerializeField]
		private InBattleQuestItemGUIRewardComponent itemReward;
		[SerializeField]
		private InBattleQuestItemGUIRewardComponent experienceReward;
		[SerializeField]
		private InBattleQuestItemGUIRewardComponent crystalReward;
	}
}
