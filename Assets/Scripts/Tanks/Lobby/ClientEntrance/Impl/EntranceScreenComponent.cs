using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class EntranceScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TMP_InputField loginField;
		[SerializeField]
		private TMP_InputField passwordField;
		[SerializeField]
		private TMP_InputField captchaField;
		[SerializeField]
		private GameObject captcha;
		[SerializeField]
		private Toggle rememberMeCheckbox;
		[SerializeField]
		private TextMeshProUGUI serverStatusLabel;
		public GameObject loginText;
		public GameObject loginWaitIndicator;
		public GameObject locker;
		[SerializeField]
		private TextMeshProUGUI enterNameOrEmail;
		[SerializeField]
		private TextMeshProUGUI enterPassword;
		[SerializeField]
		private TextMeshProUGUI rememberMe;
		[SerializeField]
		private TextMeshProUGUI play;
	}
}
