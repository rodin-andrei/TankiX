using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientUserProfile.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SquadInfoUIComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject addButton;

		[SerializeField]
		private GameObject teammate;

		[SerializeField]
		private RectTransform teammatesList;

		public void SwitchAddButton(bool value)
		{
			addButton.SetActive(value);
		}

		public void AddTeammate(long id, string avatarId, int rank)
		{
			UserLabelComponent[] componentsInChildren = teammatesList.GetComponentsInChildren<UserLabelComponent>(true);
			UserLabelComponent[] array = componentsInChildren;
			foreach (UserLabelComponent userLabelComponent in array)
			{
				if (userLabelComponent.UserId == id)
				{
					return;
				}
			}
			UserLabelBuilder userLabelBuilder = new UserLabelBuilder(id, Object.Instantiate(teammate.gameObject), avatarId, false);
			userLabelBuilder.SetLeague(rank);
			GameObject gameObject = userLabelBuilder.Build();
			gameObject.transform.SetParent(teammatesList, false);
			gameObject.gameObject.SetActive(true);
		}

		public void RemoveTeammate(long id)
		{
			UserLabelComponent[] componentsInChildren = teammatesList.GetComponentsInChildren<UserLabelComponent>(true);
			foreach (UserLabelComponent userLabelComponent in componentsInChildren)
			{
				if (userLabelComponent.UserId == id)
				{
					Object.Destroy(userLabelComponent.gameObject);
					break;
				}
			}
		}

		private void OnDisable()
		{
			UserLabelComponent[] componentsInChildren = teammatesList.GetComponentsInChildren<UserLabelComponent>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Object.Destroy(componentsInChildren[i].gameObject);
			}
		}
	}
}
