using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionButtonComponent : BehaviourComponent
	{
		public enum FractionActions
		{
			SELECT,
			AWARDS,
			LEARN_MORE
		}

		public FractionActions Action;

		[HideInInspector]
		public Entity FractionEntity;
	}
}
