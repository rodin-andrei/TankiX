using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	[SerialVersionUID(635824351226675226L)]
	public class SelectLocaleScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject applyButton;

		[SerializeField]
		private GameObject cancelButton;

		public void EnableButtons()
		{
			applyButton.SetActive(true);
		}

		public void DisableButtons()
		{
			if (applyButton.activeSelf)
			{
				applyButton.SetActive(false);
				cancelButton.SetActive(false);
			}
		}
	}
}
