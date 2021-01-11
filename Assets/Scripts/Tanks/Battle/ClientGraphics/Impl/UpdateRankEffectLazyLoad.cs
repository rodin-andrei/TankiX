using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectLazyLoad : MonoBehaviour
	{
		public GameObject GO;

		public float TimeDelay = 0.3f;

		private void Awake()
		{
			GO.SetActive(false);
		}

		private void LazyEnable()
		{
			GO.SetActive(true);
		}

		private void OnEnable()
		{
			Invoke("LazyEnable", TimeDelay);
		}

		private void OnDisable()
		{
			CancelInvoke("LazyEnable");
			GO.SetActive(false);
		}
	}
}
