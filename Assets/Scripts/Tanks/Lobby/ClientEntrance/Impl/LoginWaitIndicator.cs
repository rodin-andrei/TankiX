using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class LoginWaitIndicator : MonoBehaviour
	{
		public float angle = 1f;

		private void Update()
		{
			base.transform.Rotate(Vector3.back, angle);
		}
	}
}
