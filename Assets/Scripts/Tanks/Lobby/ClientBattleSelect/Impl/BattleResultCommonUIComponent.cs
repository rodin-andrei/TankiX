using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultCommonUIComponent : UIBehaviour
	{
		public Image tankPreviewImage1;
		public Image tankPreviewImage2;
		public TopPanelButtons topPanelButtons;
		public BottomPanelButtons bottomPanelButtons;
		[SerializeField]
		private GameObject[] screenParts;
	}
}
