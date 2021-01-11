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
		private Color emailColor = Color.green;

		[SerializeField]
		private int emailMessageSize = 18;

		[SerializeField]
		private Toggle subscribeCheckbox;

		[SerializeField]
		private UserEmailUIComponent userEmail;

		public Color EmailColor
		{
			get
			{
				return emailColor;
			}
		}

		public int EmailMessageSize
		{
			get
			{
				return emailMessageSize;
			}
		}

		public string UserNickname
		{
			get
			{
				return userChangeNickname.text;
			}
			set
			{
				userChangeNickname.text = value;
			}
		}

		public virtual bool Subscribe
		{
			get
			{
				return subscribeCheckbox.isOn;
			}
			set
			{
				subscribeCheckbox.isOn = value;
			}
		}

		public void SetEmail(string format, string email, string unconfirmedEmail)
		{
			userEmail.FormatText = format;
			userEmail.UnconfirmedEmail = unconfirmedEmail;
			userEmail.Email = email;
		}
	}
}
