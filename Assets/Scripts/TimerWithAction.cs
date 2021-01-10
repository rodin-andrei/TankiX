using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;
using TMPro;

public class TimerWithAction : MonoBehaviour
{
	[SerializeField]
	private float _startTime;
	[SerializeField]
	private Button.ButtonClickedEvent _onTimeEndAction;
	[SerializeField]
	private LocalizedField _actionDescription;
	[SerializeField]
	private TextMeshProUGUI _descriptionText;
}
