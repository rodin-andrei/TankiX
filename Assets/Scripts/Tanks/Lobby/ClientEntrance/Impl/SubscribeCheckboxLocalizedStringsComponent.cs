using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class SubscribeCheckboxLocalizedStringsComponent : FromConfigBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI subscribeLine1Text;
		[SerializeField]
		private TextMeshProUGUI subscribeLine2Text;
	}
}
