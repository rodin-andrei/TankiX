using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public class VisibilityPeriodsComponent : MonoBehaviour
	{
		public int firstIntervalInSec;
		public int lastIntervalInSec;
		public int spaceIntervalInSec;
		public int lastBlinkingIntervalInSec;
	}
}
