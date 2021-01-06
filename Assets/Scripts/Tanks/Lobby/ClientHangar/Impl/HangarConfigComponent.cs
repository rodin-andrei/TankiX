using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarConfigComponent : MonoBehaviour
	{
		[SerializeField]
		private float autoRotateSpeed;
		[SerializeField]
		private float keyboardRotateSpeed;
		[SerializeField]
		private float mouseRotateFactor;
		[SerializeField]
		private float decelerationRotateFactor;
		[SerializeField]
		private float autoRotateDelay;
		[SerializeField]
		private float flightToLocationTime;
		[SerializeField]
		private float flightToLocationHigh;
		[SerializeField]
		private float flightToTankTime;
		[SerializeField]
		private float flightToTankRadius;
	}
}
