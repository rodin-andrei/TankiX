using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CountingBadgeComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI counter;
	}
}
