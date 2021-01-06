using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class FlagsHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private FlagController blueFlag;
		[SerializeField]
		private RectTransform blueFlagTransform;
		[SerializeField]
		private FlagController redFlag;
		[SerializeField]
		private RectTransform redFlagTransform;
	}
}
