using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class RotationDisabled : MonoBehaviour
	{
		public void LateUpdate()
		{
			base.transform.rotation = Quaternion.identity;
		}
	}
}
