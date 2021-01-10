using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CantChangeEquiptmentDialog : UIBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI message;
		[SerializeField]
		private Button okButton;
		public LocalizedField messageLocalizedField;
	}
}
