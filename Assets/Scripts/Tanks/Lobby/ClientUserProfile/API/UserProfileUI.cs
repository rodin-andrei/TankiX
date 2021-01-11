using Lobby.ClientUserProfile.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientProfile.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

		public bool CanCreateSquad
		{
			set
			{
				createSquadButton.GetComponent<Button>().interactable = value;
			}
		}

		private void OnEnable()
		{
			if (SelfUserComponent.SelfUser != null)
			{
				UpdateNickname();
				LevelInfo info = this.SendEvent<GetUserLevelInfoEvent>(SelfUserComponent.SelfUser).Info;
				level.text = (info.Level + 1).ToString();
				nextLevel.text = ((info.Experience >= info.MaxExperience) ? string.Empty : (info.Level + 2).ToString());
				expProgress.value = info.Progress;
				expValue.text = string.Format(expValueLocalizedField.Value, info.Experience, info.MaxExperience);
			}
		}

		public void UpdateNickname()
		{
			nickname.text = SelfUserComponent.SelfUser.GetComponent<UserUidComponent>().Uid;
		}

		public void SwitchButtons(bool showCreateSquadButton)
		{
			createSquadButton.SetActive(showCreateSquadButton);
			cancelButton.SetActive(!showCreateSquadButton);
		}
	}
}
