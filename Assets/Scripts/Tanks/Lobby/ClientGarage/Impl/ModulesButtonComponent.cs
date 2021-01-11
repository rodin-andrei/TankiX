using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesButtonComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text text;

		public string Text
		{
			set
			{
				text.text = value.ToUpper();
			}
		}
	}
}
