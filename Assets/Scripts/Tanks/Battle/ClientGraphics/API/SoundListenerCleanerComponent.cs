using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class SoundListenerCleanerComponent : BehaviourComponent
	{
		[SerializeField]
		private float tankPartCleanTimeSec = 2f;

		[SerializeField]
		private float mineCleanTimeSec = 2.2f;

		[SerializeField]
		private float ctfCleanTimeSec = 5.2f;

		public float TankPartCleanTimeSec
		{
			get
			{
				return tankPartCleanTimeSec;
			}
		}

		public float MineCleanTimeSec
		{
			get
			{
				return mineCleanTimeSec;
			}
		}

		public float CTFCleanTimeSec
		{
			get
			{
				return ctfCleanTimeSec;
			}
		}
	}
}
