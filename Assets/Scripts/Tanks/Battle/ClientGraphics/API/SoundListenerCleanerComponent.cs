using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class SoundListenerCleanerComponent : BehaviourComponent
	{
		[SerializeField]
		private float tankPartCleanTimeSec;
		[SerializeField]
		private float mineCleanTimeSec;
		[SerializeField]
		private float ctfCleanTimeSec;
	}
}
