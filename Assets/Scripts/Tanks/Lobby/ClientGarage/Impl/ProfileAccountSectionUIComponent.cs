using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ProfileAccountSectionUIComponent : BehaviourComponent
	{
		public LocalizedField UnconfirmedLocalization;
		[SerializeField]
		private TextMeshProUGUI userChangeNickname;
		[SerializeField]
		private Color emailColor;
		[SerializeField]
		private int emailMessageSize;
		[SerializeField]
		private Toggle subscribeCheckbox;
		[SerializeField]
		private UserEmailUIComponent userEmail;
	}
}
