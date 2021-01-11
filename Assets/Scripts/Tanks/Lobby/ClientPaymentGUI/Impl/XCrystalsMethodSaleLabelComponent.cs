using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class XCrystalsMethodSaleLabelComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text timerText;

		public string Text
		{
			set
			{
				timerText.text = value;
			}
		}
	}
}
