using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserProfileUI : BehaviourComponent
	{
		[SerializeField]
		private Slider expProgress;
		[SerializeField]
		private TextMeshProUGUI level;
		[SerializeField]
		private TextMeshProUGUI nextLevel;
		[SerializeField]
		private TextMeshProUGUI expValue;
		[SerializeField]
		private TextMeshProUGUI nickname;
		[SerializeField]
		private GameObject createSquadButton;
		[SerializeField]
		private GameObject cancelButton;
		[SerializeField]
		private LocalizedField expValueLocalizedField;
	}
}
