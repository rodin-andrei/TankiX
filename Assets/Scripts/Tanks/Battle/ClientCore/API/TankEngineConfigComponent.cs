using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class TankEngineConfigComponent : MonoBehaviour
	{
		[SerializeField]
		private float minEngineMovingBorder;
		[SerializeField]
		private float maxEngineMovingBorder;
		[SerializeField]
		private float engineTurningBorder;
		[SerializeField]
		private float engineCollisionIntervalSec;
	}
}
