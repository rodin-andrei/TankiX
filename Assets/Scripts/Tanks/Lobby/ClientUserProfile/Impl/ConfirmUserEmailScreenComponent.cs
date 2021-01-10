using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ConfirmUserEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text confirmationHintWithUserEmail;
		[SerializeField]
		private Text sendNewsText;
		[SerializeField]
		private Text confirmText;
		[SerializeField]
		private Text sendAgainText;
		[SerializeField]
		private Text rightPanelHint;
		[SerializeField]
		private Text confirmationCodeText;
		[SerializeField]
		private Color emailColor;
		[SerializeField]
		private GameObject cancelButton;
		[SerializeField]
		private GameObject changeEmailButton;
	}
}
