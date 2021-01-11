using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DisplayDescriptionItemComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TopTextDescriptionItem description;

		public void SetDescription(string text)
		{
			description.text = text;
		}
	}
}
