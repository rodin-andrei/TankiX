using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableHeaderComponent : MonoBehaviour
	{
		public List<ScoreTableRowIndicator> headers;
		[SerializeField]
		private RectTransform headerTitle;
		[SerializeField]
		private RectTransform scoreHeaderContainer;
	}
}
