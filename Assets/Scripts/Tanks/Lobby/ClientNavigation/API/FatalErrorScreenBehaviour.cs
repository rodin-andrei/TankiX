using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class FatalErrorScreenBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Text header;
		[SerializeField]
		private Text text;
		[SerializeField]
		private TextMeshProUGUI restart;
		[SerializeField]
		private TextMeshProUGUI quit;
		[SerializeField]
		private TextMeshProUGUI report;
		[SerializeField]
		private ReportButtonBehaviour reportButtonBehaviour;
	}
}
