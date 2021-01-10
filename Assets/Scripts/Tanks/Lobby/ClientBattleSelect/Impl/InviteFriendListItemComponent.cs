using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteFriendListItemComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject userLabelContainer;
		[SerializeField]
		private GameObject battleLabelContainer;
		[SerializeField]
		private GameObject notificationContainer;
		[SerializeField]
		private Text notificationText;
	}
}
