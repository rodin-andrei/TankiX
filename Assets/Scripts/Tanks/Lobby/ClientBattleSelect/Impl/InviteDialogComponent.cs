using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteDialogComponent : UIBehaviour
	{
		[SerializeField]
		private GameObject buttons;
		[SerializeField]
		private GameObject keys;
		public float maxTimerValue;
		[SerializeField]
		private Slider timerSlider;
		[SerializeField]
		private TextMeshProUGUI message;
		[SerializeField]
		private Button acceptButton;
		[SerializeField]
		private Button declineButton;
		[SerializeField]
		private AudioSource sound;
	}
}
