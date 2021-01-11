using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class RegisterScreensEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public IEnumerable<GameObject> Screens
		{
			get;
			set;
		}
	}
}
