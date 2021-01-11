using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.API
{
	public class IncomingFriendButtonsComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject acceptButton;

		[SerializeField]
		private GameObject declineButton;

		private EntityBehaviour _mainEntityBehaviour;

		private EntityBehaviour _acceptEntityBehaviour;

		private EntityBehaviour _declineEntityBehaviour;

		public bool IsIncoming
		{
			set
			{
				acceptButton.transform.parent.gameObject.SetActive(value);
				if (value)
				{
					Entity entity = _acceptEntityBehaviour.Entity;
					entity.RemoveComponentIfPresent<UserGroupComponent>();
					Entity entity2 = _declineEntityBehaviour.Entity;
					entity2.RemoveComponentIfPresent<UserGroupComponent>();
					_mainEntityBehaviour.Entity.GetComponent<UserGroupComponent>().Attach(entity).Attach(entity2);
				}
			}
		}

		private void OnEnable()
		{
			_mainEntityBehaviour = GetComponent<EntityBehaviour>();
			_acceptEntityBehaviour = acceptButton.GetComponent<EntityBehaviour>();
			_declineEntityBehaviour = declineButton.GetComponent<EntityBehaviour>();
		}
	}
}
