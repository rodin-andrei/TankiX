using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class ConfirmButtonComponent : MonoBehaviour
	{
		[SerializeField]
		public Button button;
		[SerializeField]
		private Text buttonText;
		[SerializeField]
		private Text confirmText;
		[SerializeField]
		private Text cancelText;
		[SerializeField]
		private Button defaultButton;
	}
}
