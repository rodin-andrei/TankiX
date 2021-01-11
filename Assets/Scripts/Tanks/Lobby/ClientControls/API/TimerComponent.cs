using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class TimerComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TimerUIComponent timer;

		public TimerUIComponent Timer
		{
			get
			{
				return timer;
			}
		}
	}
}
