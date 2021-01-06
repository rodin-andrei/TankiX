using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class BattleTimeIndicatorComponent : MonoBehaviour
	{
		[SerializeField]
		private Text timeText;
		[SerializeField]
		private ProgressBar timeProgressBar;
	}
}
