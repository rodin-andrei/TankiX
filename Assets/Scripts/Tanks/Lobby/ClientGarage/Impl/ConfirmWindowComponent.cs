using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ConfirmWindowComponent : UIBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI confirmText;
		[SerializeField]
		protected TextMeshProUGUI declineText;
		[SerializeField]
		protected TextMeshProUGUI headerText;
		[SerializeField]
		protected TextMeshProUGUI mainText;
		[SerializeField]
		protected Button confirmButton;
		[SerializeField]
		protected Button declineButton;
	}
}
