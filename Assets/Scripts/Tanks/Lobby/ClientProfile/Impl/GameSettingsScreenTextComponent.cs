using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class GameSettingsScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI cameraShakerEnabled;

		[SerializeField]
		private TextMeshProUGUI targetFocusEnabled;

		[SerializeField]
		private TextMeshProUGUI laserSightEnabled;

		[SerializeField]
		private TextMeshProUGUI damageInfo;

		[SerializeField]
		private TextMeshProUGUI healthFeedback;

		[SerializeField]
		private TextMeshProUGUI selfTargetHitFeedback;

		[SerializeField]
		private TextMeshProUGUI disableNotificationsText;

		public string CameraShakerEnabled
		{
			set
			{
				cameraShakerEnabled.text = value;
			}
		}

		public string TargetFocusEnabled
		{
			set
			{
				targetFocusEnabled.text = value;
			}
		}

		public string LaserSightEnabled
		{
			set
			{
				laserSightEnabled.text = value;
			}
		}

		public string DamageInfo
		{
			set
			{
				damageInfo.text = value;
			}
		}

		public string HealthFeedback
		{
			set
			{
				healthFeedback.text = value;
			}
		}

		public string SelfTargetHitFeedback
		{
			set
			{
				selfTargetHitFeedback.text = value;
			}
		}

		public string DisableNotificationsText
		{
			set
			{
				disableNotificationsText.text = value;
			}
		}
	}
}
