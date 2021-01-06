using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PlatboxWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;
		[SerializeField]
		private TMP_InputField phone;
		[SerializeField]
		private TextMeshProUGUI code;
		[SerializeField]
		private Animator continueButton;
	}
}
