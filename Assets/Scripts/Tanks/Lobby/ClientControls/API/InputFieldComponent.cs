using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class InputFieldComponent : EventMappingComponent
	{
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private Text errorMessageLabel;
		[SerializeField]
		private TextMeshProUGUI errorMessageTMPLabel;
	}
}
