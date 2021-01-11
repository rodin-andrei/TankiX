using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	[RequireComponent(typeof(Animator))]
	public class BackgroundComponent : BackgroundDimensionsChangeComponent, Platform.Kernel.ECS.ClientEntitySystem.API.Component, NoScaleScreen
	{
		private const string VISIBLE_ANIMATION_PARAM = "Visible";

		public virtual void Hide()
		{
			GetComponent<Animator>().SetBool("Visible", false);
		}

		public virtual void Show()
		{
			GetComponent<Animator>().SetBool("Visible", true);
		}
	}
}
