using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class UsersEnergyCellsListUIComponent : BehaviourComponent
	{
		[SerializeField]
		private RectTransform content;

		[SerializeField]
		private UserEnergyCellUIComponent cell;

		private List<UserEnergyCellUIComponent> cells = new List<UserEnergyCellUIComponent>();

		public UserEnergyCellUIComponent AddUserCell()
		{
			UserEnergyCellUIComponent userEnergyCellUIComponent = Object.Instantiate(cell);
			userEnergyCellUIComponent.transform.SetParent(content, false);
			userEnergyCellUIComponent.gameObject.SetActive(true);
			cells.Add(userEnergyCellUIComponent);
			UpdateCells();
			return userEnergyCellUIComponent;
		}

		public void RemoveUserCell(UserEnergyCellUIComponent user)
		{
			if (cells.Contains(user))
			{
				cells.Remove(user);
			}
			Object.Destroy(user.gameObject);
			UpdateCells();
		}

		private void UpdateCells()
		{
			for (int i = 0; i < cells.Count; i++)
			{
				cells[i].CellIsFirst = i == 0;
			}
		}

		private void OnDisable()
		{
			content.DestroyChildren();
			cells.Clear();
		}
	}
}
