using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UidHighlightingComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public FontStyles friend;

		public FontStyles selfUser;

		public FontStyles normal;
	}
}
