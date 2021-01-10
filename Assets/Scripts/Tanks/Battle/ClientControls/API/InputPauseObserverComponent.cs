using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientControls.API
{
	public class InputPauseObserverComponent : ECSBehaviour
	{
		[SerializeField]
		private float delayInSec;
	}
}
