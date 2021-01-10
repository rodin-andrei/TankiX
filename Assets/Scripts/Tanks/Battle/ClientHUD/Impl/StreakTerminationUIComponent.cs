using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class StreakTerminationUIComponent : BehaviourComponent
	{
		public TextMeshProUGUI streakTerminationText;
		public LocalizedField streakTerminationLocalization;
	}
}
