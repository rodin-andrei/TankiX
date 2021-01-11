using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeLevelRestrictionBadgeGUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text restrictionValueText;

		public string RestrictionValue
		{
			set
			{
				restrictionValueText.text = value;
			}
		}
	}
}
