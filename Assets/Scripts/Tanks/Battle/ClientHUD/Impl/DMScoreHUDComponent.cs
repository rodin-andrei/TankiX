using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class DMScoreHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI place;
		[SerializeField]
		private TextMeshProUGUI playerScore;
	}
}
