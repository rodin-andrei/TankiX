using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class TooltipDataRequestComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 MousePosition
		{
			get;
			set;
		}

		public GameObject TooltipPrefab
		{
			get;
			set;
		}

		public InteractionSource InteractionSource
		{
			get;
			set;
		}

		public long idOfRequestedUser
		{
			get;
			internal set;
		}

		public long InteractableSourceId
		{
			get;
			set;
		}
	}
}
