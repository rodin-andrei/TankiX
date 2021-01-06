using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class UITableView : ScrollRect
	{
		[SerializeField]
		private UITableViewCell cellPrefab;
		[SerializeField]
		private float CellsSpacing;
		[SerializeField]
		private float CellHeight;
	}
}
