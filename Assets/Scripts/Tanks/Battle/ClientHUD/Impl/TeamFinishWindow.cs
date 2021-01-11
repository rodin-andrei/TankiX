using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TeamFinishWindow : MonoBehaviour
	{
		[Tooltip("WIN = 0, DEFEAT = 1, DRAW = 2")]
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

		public string EarnedText
		{
			set
			{
				earnedText.text = value;
			}
		}

		public bool CustomBattle
		{
			set
			{
				earnedContainer.SetActive(false);
			}
		}

		public void ShowWin()
		{
			outcomeText.color = titleColors[0];
			outcomeText.text = WinText.Value;
			Show();
		}

		public void ShowLose()
		{
			outcomeText.color = titleColors[1];
			outcomeText.text = LoseText.Value;
			Show();
		}

		public void ShowTie()
		{
			outcomeText.color = titleColors[2];
			outcomeText.text = TieText.Value;
			Show();
		}

		private void Show()
		{
			base.gameObject.SetActive(true);
			GetComponent<CanvasGroup>().alpha = 0f;
			GetComponent<Animator>().SetTrigger("Show");
		}
	}
}
