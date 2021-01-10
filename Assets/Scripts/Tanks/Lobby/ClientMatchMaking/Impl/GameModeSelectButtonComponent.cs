using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class GameModeSelectButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI modeTitle;
		[SerializeField]
		private TextMeshProUGUI modeDescription;
		[SerializeField]
		private GameObject blockLayer;
		[SerializeField]
		private GameObject restriction;
		[SerializeField]
		private ImageSkin modeImage;
		[SerializeField]
		private Material grayscaleMaterial;
		[SerializeField]
		private GameObject notAvailableForNotSquadLeaderLabel;
		[SerializeField]
		private GameObject notAvailableInSquadLabel;
	}
}
