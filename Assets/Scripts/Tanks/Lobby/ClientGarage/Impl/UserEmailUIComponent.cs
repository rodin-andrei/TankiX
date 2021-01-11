using System.Text.RegularExpressions;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UserEmailUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI text;

		private string formatText = string.Empty;

		private string unconfirmedEmail = string.Empty;

		private string email = string.Empty;

		private bool emailIsVisible;

		public string FormatText
		{
			get
			{
				return formatText;
			}
			set
			{
				formatText = value;
			}
		}

		public string UnconfirmedEmail
		{
			get
			{
				return unconfirmedEmail;
			}
			set
			{
				unconfirmedEmail = value;
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
				EmailIsVisible = emailIsVisible;
			}
		}

		public bool EmailIsVisible
		{
			get
			{
				return emailIsVisible;
			}
			set
			{
				emailIsVisible = value;
				string newValue = ((!emailIsVisible) ? Regex.Replace(email, "[A-Za-z0-9]", "*") : email);
				string newValue2 = ((!emailIsVisible) ? Regex.Replace(unconfirmedEmail, "[A-Za-z0-9]", "*") : unconfirmedEmail);
				text.text = formatText.Replace("%EMAIL%", newValue).Replace("%UNCEMAIL%", newValue2);
			}
		}
	}
}
