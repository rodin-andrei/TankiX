using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class UIListComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public IUIList List
		{
			get;
			private set;
		}

		private void Awake()
		{
			List = GetComponent<IUIList>();
		}
	}
}
