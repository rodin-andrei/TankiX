using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

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

		public ImageListSkin RankImageSkin
		{
			get
			{
				return rankImageSkin;
			}
		}

		public Text RankHeaderElement
		{
			get
			{
				return rankHeaderElement;
			}
		}

		public Text RankNameElement
		{
			get
			{
				return rankNameElement;
			}
		}

		public UserRankRewardMoneyBlock XCrystalsBlock
		{
			get
			{
				return xCrystalsBlock;
			}
		}

		public UserRankRewardMoneyBlock CrystalsBlock
		{
			get
			{
				return crystalsBlock;
			}
		}
	}
}
