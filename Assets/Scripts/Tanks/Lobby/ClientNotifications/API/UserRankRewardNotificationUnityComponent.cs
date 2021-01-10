using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientNotifications.API
{
	public class UserRankRewardNotificationUnityComponent : BehaviourComponent
	{
		[SerializeField]
		private Text rankHeaderElement;
		[SerializeField]
		private Text rankNameElement;
		[SerializeField]
		private ImageListSkin rankImageSkin;
		[SerializeField]
		private UserRankRewardMoneyBlock xCrystalsBlock;
		[SerializeField]
		private UserRankRewardMoneyBlock crystalsBlock;
	}
}
