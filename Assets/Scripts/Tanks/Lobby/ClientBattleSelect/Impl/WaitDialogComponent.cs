using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class WaitDialogComponent : UIBehaviour
	{
		public float maxTimerValue;
		[SerializeField]
		private Slider timerSlider;
		[SerializeField]
		private TextMeshProUGUI message;
	}
}
