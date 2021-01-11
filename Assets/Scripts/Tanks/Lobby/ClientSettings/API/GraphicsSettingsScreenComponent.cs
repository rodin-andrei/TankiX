using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class GraphicsSettingsScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject applyButton;

		[SerializeField]
		private GameObject cancelButton;

		[SerializeField]
		private GameObject defaultButton;

		[SerializeField]
		private TextMeshProUGUI reloadText;

		[SerializeField]
		private TextMeshProUGUI perfomanceChangeText;

		[SerializeField]
		private TextMeshProUGUI currentPerfomanceText;

		private bool needToReloadApplication;

		public bool NeedToReloadApplication
		{
			get
			{
				return needToReloadApplication;
			}
			set
			{
				needToReloadApplication = value;
				reloadText.gameObject.SetActive(needToReloadApplication);
			}
		}

		public void SetPerfomanceWarningVisibility(bool needToShowChangePerfomance, bool isCurrentQuality)
		{
			perfomanceChangeText.gameObject.SetActive(!isCurrentQuality && needToShowChangePerfomance);
			currentPerfomanceText.gameObject.SetActive(isCurrentQuality && needToShowChangePerfomance);
		}

		public void SetVisibilityForChangeSettingsControls(bool needToShowReload, bool needToShowButtons)
		{
			applyButton.gameObject.SetActive(needToShowButtons);
			cancelButton.gameObject.SetActive(needToShowButtons);
			NeedToReloadApplication = needToShowReload;
		}

		public void SetDefaultButtonVisibility(bool needToShow)
		{
			defaultButton.gameObject.SetActive(needToShow);
		}
	}
}
