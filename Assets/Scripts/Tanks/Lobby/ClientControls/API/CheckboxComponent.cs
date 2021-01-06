using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class CheckboxComponent : EventMappingComponent
	{
		[SerializeField]
		private Text label;
		[SerializeField]
		private TextMeshProUGUI TMPLabel;
		[SerializeField]
		private Toggle toggle;
	}
}
