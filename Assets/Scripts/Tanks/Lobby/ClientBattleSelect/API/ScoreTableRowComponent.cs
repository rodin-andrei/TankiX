using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableRowComponent : MonoBehaviour
	{
		[SerializeField]
		private RectTransform indicatorsContainer;
		[SerializeField]
		private Text position;
		[SerializeField]
		private Image background;
	}
}
