using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TeamFinishWindow : MonoBehaviour
	{
		public Color[] titleColors;
		[SerializeField]
		private LocalizedField WinText;
		[SerializeField]
		private LocalizedField LoseText;
		[SerializeField]
		private LocalizedField TieText;
		[SerializeField]
		private GameObject earnedContainer;
		[SerializeField]
		private TextMeshProUGUI outcomeText;
		[SerializeField]
		private Text earnedText;
		[SerializeField]
		private Text amountValue;
	}
}
