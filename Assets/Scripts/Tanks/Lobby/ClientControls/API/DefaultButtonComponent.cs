using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class DefaultButtonComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI text;

		public virtual string Text
		{
			set
			{
				text.text = value.ToUpper();
			}
		}
	}
}
