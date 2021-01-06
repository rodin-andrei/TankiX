using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PresetListItemComponent : UIBehaviour
	{
		[SerializeField]
		private GameObject iconObject;
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private Graphic bgGraphic;
		[SerializeField]
		private Color lockedColor;
		[SerializeField]
		private Color unlockedColor;
	}
}
