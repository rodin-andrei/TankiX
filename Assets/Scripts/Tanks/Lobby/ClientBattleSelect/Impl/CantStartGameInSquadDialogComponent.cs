using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

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
	}
}
