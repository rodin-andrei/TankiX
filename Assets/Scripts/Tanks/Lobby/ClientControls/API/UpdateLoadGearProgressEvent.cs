using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class UpdateLoadGearProgressEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public float Value
		{
			get;
			set;
		}

		public UpdateLoadGearProgressEvent(float value)
		{
			Value = Mathf.Clamp01(value);
		}
	}
}
