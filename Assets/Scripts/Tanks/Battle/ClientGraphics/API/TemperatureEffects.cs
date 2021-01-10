using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TemperatureEffects : MonoBehaviour
	{
		[SerializeField]
		private GameObject freezingPrefab;
		[SerializeField]
		private GameObject burningPrefab;
		[SerializeField]
		private Transform mountPoint;
	}
}
