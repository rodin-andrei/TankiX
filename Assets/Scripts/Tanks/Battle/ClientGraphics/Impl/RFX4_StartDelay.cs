using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RFX4_StartDelay : MonoBehaviour
	{
		public GameObject ActivatedGameObject;

		public float Delay = 1f;

		private void OnEnable()
		{
			ActivatedGameObject.SetActive(false);
			Invoke("ActivateGO", Delay);
		}

		private void ActivateGO()
		{
			ActivatedGameObject.SetActive(true);
		}

		private void OnDisable()
		{
			CancelInvoke("ActivateGO");
		}
	}
}
