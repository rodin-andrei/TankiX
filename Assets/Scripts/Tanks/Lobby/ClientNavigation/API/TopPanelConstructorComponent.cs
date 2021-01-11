using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class TopPanelConstructorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private bool showBackground;

		[SerializeField]
		private bool showBackButton;

		[SerializeField]
		private bool showHeader;

		public bool ShowBackground
		{
			get
			{
				return showBackground;
			}
		}

		public bool ShowBackButton
		{
			get
			{
				return showBackButton;
			}
		}

		public bool ShowHeader
		{
			get
			{
				return showHeader;
			}
		}
	}
}
