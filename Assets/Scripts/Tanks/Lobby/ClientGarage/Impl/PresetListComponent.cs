using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PresetListComponent : UIBehaviour
	{
		[SerializeField]
		private GameObject elementPrefab;
		[SerializeField]
		private RectTransform contentRoot;
		[SerializeField]
		private Button leftButton;
		[SerializeField]
		private Button rightButton;
		[SerializeField]
		private float speed;
		[SerializeField]
		private GameObject buyButton;
		[SerializeField]
		private GaragePrice xBuyPrice;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private LocalizedField lockedByRankLocalizedText;
		[SerializeField]
		private TextMeshProUGUI lockedByRankText;
	}
}
