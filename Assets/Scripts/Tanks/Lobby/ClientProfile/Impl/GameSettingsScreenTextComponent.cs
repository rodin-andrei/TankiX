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
	}
}
