using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteFriendListItemComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject userLabelContainer;

		[SerializeField]
		private GameObject battleLabelContainer;

		[SerializeField]
		private GameObject notificationContainer;

		[SerializeField]
		private Text notificationText;

		public GameObject UserLabelContainer
		{
			get
			{
				return userLabelContainer;
			}
		}

		public GameObject BattleLabelContainer
		{
			get
			{
				return battleLabelContainer;
			}
		}

		public GameObject NotificationContainer
		{
			get
			{
				return notificationContainer;
			}
		}

		public Text NotificationText
		{
			get
			{
				return notificationText;
			}
		}
	}
}
