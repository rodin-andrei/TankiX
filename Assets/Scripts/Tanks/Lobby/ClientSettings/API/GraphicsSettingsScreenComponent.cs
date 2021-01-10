using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientSettings.API
{
	public class GraphicsSettingsScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject applyButton;
		[SerializeField]
		private GameObject cancelButton;
		[SerializeField]
		private GameObject defaultButton;
		[SerializeField]
		private TextMeshProUGUI reloadText;
		[SerializeField]
		private TextMeshProUGUI perfomanceChangeText;
		[SerializeField]
		private TextMeshProUGUI currentPerfomanceText;
	}
}
