using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MainScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private ItemSelectUI itemSelect;
		[SerializeField]
		private GameObject backButton;
		[SerializeField]
		private TextMeshProUGUI modeTitleInSearchingScreen;
		[SerializeField]
		private GameObject deserterIcon;
		[SerializeField]
		private DeserterDescriptionUIComponent deserterDesc;
		[SerializeField]
		private LocalizedField deserterDescLocalized;
		[SerializeField]
		private LocalizedField battlesDef;
		[SerializeField]
		private LocalizedField battlesOne;
		[SerializeField]
		private LocalizedField battlesTwo;
		[SerializeField]
		private GameObject starterPackButton;
		[SerializeField]
		private GameObject starterPackScreen;
		[SerializeField]
		private GameObject questsBtn;
		[SerializeField]
		private GameObject dailyBonusBtn;
		public GameObject playButton;
	}
}
