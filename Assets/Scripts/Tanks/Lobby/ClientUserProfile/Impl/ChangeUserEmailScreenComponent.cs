using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ChangeUserEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text sendButtonText;

		[SerializeField]
		private Text rightPanelHint;

		public string SendButton
		{
			set
			{
				sendButtonText.text = value.ToUpper();
			}
		}

		public string RightPanelHint
		{
			set
			{
				rightPanelHint.text = value;
			}
		}

		public void DeactivateHint()
		{
			rightPanelHint.gameObject.SetActive(false);
		}

		public void OnEnable()
		{
			rightPanelHint.gameObject.SetActive(true);
		}
	}
}
