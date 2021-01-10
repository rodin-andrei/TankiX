using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class RegistrationScreenLocalizedStringsComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI finishButtonText;
		[SerializeField]
		private TextMeshProUGUI skipButtonText;
		[SerializeField]
		private TextMeshProUGUI nicknameHintText;
		[SerializeField]
		private TextMeshProUGUI passwordHintText;
		[SerializeField]
		private TextMeshProUGUI repeatPasswordHintText;
		[SerializeField]
		private TextMeshProUGUI iAcceptTermsPart1Text;
		[SerializeField]
		private TextMeshProUGUI iAcceptTermsPart2EULAText;
		[SerializeField]
		private TextMeshProUGUI iAcceptTermsPart4RulesText;
		[SerializeField]
		private TextMeshProUGUI iAcceptTermsPart5PrivacyPolicyText;
	}
}
