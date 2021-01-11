using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class SubscribeCheckboxLocalizedStringsComponent : FromConfigBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI subscribeLine1Text;

		[SerializeField]
		private TextMeshProUGUI subscribeLine2Text;

		public string SubscribeLine1Text
		{
			set
			{
				subscribeLine1Text.text = value;
			}
		}

		public string SubscribeLine2Text
		{
			set
			{
				subscribeLine2Text.text = value;
			}
		}

		protected override string GetRelativeConfigPath()
		{
			return "/ui/element";
		}
	}
}
