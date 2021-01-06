using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientHome.API
{
	public class HomeScreenLocalizedStringsComponent : BehaviourComponent
	{
		[SerializeField]
		private Text playButtonLabel;
		[SerializeField]
		private Text battlesButtonLabel;
		[SerializeField]
		private Text garageButtonLabel;
		[SerializeField]
		private Text questsButtonLabel;
		[SerializeField]
		private Text containersButtonLabel;
	}
}
