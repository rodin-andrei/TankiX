using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class InBattleQuestItemGUIRewardComponent : MonoBehaviour
	{
		[SerializeField]
		private TankPartItemIcon itemIcon;
		[SerializeField]
		private TextMeshProUGUI quantityText;
	}
}
