using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EnterUserEmailScreenComponent : LocalizedScreenComponent, NoScaleScreen
	{
		[SerializeField]
		private TextMeshProUGUI rightPanelHint;

		[SerializeField]
		private TextMeshProUGUI continueButton;

		public virtual string RightPanelHint
		{
			set
			{
				rightPanelHint.text = value;
			}
		}

		public virtual string ContinueButton
		{
			set
			{
				continueButton.text = value.ToUpper();
			}
		}
	}
}
