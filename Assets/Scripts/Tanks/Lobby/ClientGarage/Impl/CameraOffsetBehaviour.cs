using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CameraOffsetBehaviour : BehaviourComponent
	{
		[SerializeField]
		private float offsetX;
		[SerializeField]
		private float offsetY;
		[SerializeField]
		private float animationDuration;
	}
}
