using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectRandomRotateOnStart : MonoBehaviour
	{
		public Vector3 NormalizedRotateVector = new Vector3(0f, 1f, 0f);

		private Transform t;

		private bool isInitialized;

		private void Start()
		{
			t = base.transform;
			t.Rotate(NormalizedRotateVector * Random.Range(0, 360));
			isInitialized = true;
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				t.Rotate(NormalizedRotateVector * Random.Range(0, 360));
			}
		}
	}
}
