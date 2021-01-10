using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableComponent : MonoBehaviour
	{
		[SerializeField]
		private RectTransform headerContainer;
		[SerializeField]
		protected ScoreTableRowComponent rowPrefab;
		public float rowHeight;
		public float rowSpacing;
	}
}
