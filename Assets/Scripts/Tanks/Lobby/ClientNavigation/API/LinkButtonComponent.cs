using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class LinkButtonComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string link;

		public string Link
		{
			get
			{
				return link;
			}
			set
			{
				link = value;
			}
		}
	}
}
