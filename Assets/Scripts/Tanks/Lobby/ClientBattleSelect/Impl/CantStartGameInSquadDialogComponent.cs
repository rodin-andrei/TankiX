using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class CantStartGameInSquadDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI label;

		[SerializeField]
		private LocalizedField cantSearch;

		[SerializeField]
		private LocalizedField cantCreate;

		public bool CantSearch
		{
			set
			{
				label.text = ((!value) ? cantCreate.Value : cantSearch.Value);
			}
		}
	}
}
