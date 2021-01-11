using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ArmsRaceRewardNumberComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AnimatedLong quantity;

		public int initialVal;

		private void Start()
		{
			quantity.SetImmediate(-1L);
			quantity.Value = initialVal;
		}
	}
}
