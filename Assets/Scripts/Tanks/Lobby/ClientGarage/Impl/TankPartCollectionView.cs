using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TankPartCollectionView : MonoBehaviour
	{
		public TankSlotView activeSlot;
		public TankSlotView activeSlot2;
		public TankSlotView passiveSlot;
		public GameObject tankPartView;
		public ImageSkin preview;
		public TextMeshProUGUI partName;
		public LineCollectionView lineCollectionView;
		public CanvasGroup slotContainer;
		[SerializeField]
		private UpgradeStars upgradeStars;
		[SerializeField]
		private TextMeshProUGUI bonusFromModules;
		[SerializeField]
		private TextMeshProUGUI basePartParam;
		[SerializeField]
		private TextMeshProUGUI partLevel;
		[SerializeField]
		private LocalizedField basePartParamName;
	}
}
