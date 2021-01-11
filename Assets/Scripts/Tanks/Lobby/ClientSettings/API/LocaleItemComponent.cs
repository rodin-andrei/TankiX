using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class LocaleItemComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI caption;

		public void SetText(string caption, string localizedCaption)
		{
			this.caption.text = caption;
		}
	}
}
