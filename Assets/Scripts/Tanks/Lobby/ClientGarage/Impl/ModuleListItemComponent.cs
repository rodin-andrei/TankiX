using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleListItemComponent : UIBehaviour
	{
		[SerializeField]
		private GameObject moduleEffectsInfoPrefab;
		[SerializeField]
		private RectTransform moduleIconRoot;
		[SerializeField]
		private RectTransform moduleNameRoot;
		[SerializeField]
		private TextMeshProUGUI craftableLabelText;
		[SerializeField]
		private RectTransform moduleEffectsInfoRoot;
		[SerializeField]
		private TextMeshProUGUI moduleNameText;
		[SerializeField]
		private PaletteColorField exceptionalColor;
		[SerializeField]
		private PaletteColorField epicColor;
		[SerializeField]
		private Image moduleIcon;
		[SerializeField]
		private TextMeshProUGUI moduleText;
		[SerializeField]
		private Color craftableTextColor;
		[SerializeField]
		private Color notCraftableTextColor;
		[SerializeField]
		private GameObject mountedSelection;
	}
}
