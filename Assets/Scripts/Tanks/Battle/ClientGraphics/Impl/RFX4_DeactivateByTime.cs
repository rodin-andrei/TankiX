using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RFX4_DeactivateByTime : MonoBehaviour
	{
		public float DeactivateTime = 3f;

		private bool canUpdateState;

		private void OnEnable()
		{
			canUpdateState = true;
		}

		private void Update()
		{
			if (canUpdateState)
			{
				canUpdateState = false;
				Invoke("DeactivateThis", DeactivateTime);
			}
		}

		private void DeactivateThis()
		{
			base.gameObject.SetActive(false);
		}
	}
}
