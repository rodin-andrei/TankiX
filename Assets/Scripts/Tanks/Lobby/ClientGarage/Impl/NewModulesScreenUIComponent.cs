using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using Tanks.Lobby.ClientProfile.Impl;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class NewModulesScreenUIComponent : BehaviourComponent
	{
		[SerializeField]
		private LocalizedField hullHealth;
		[SerializeField]
		private LocalizedField turretDamage;
		[SerializeField]
		private LocalizedField level;
		[SerializeField]
		private PresetsDropDownList presetsDropDownList;
		public XCrystalsIndicatorComponent xCrystalButton;
		public CrystalsIndicatorComponent crystalButton;
		public TankPartCollectionView turretCollectionView;
		public TankPartCollectionView hullCollectionView;
		public CollectionView collectionView;
		public Button backButton;
		public SelectedModuleView selectedModuleView;
		public GameObject background;
		public DragAndDropController dragAndDropController;
		public GameObject slotItemPrefab;
		public bool showAnimationFinished;
	}
}
