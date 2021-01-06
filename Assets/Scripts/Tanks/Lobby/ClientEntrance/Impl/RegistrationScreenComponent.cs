using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class RegistrationScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private TMP_InputField uidInput;
		[SerializeField]
		private TMP_InputField passwordInput;
		[SerializeField]
		private TMP_InputField emailInput;
		public GameObject locker;
	}
}
