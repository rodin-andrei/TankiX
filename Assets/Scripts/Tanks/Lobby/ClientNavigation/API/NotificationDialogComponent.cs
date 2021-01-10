using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class NotificationDialogComponent : UIBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI message;
		[SerializeField]
		private Button okButton;
	}
}
