using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class MobilePaymentScreenComponent : BasePaymentScreenComponent
	{
		[SerializeField]
		private Text mobilePhoneLabel;
		[SerializeField]
		private Text phoneCountryCode;
		[SerializeField]
		private InputField phoneNumber;
	}
}
