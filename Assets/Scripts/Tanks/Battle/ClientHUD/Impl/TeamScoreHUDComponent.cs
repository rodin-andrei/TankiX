using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TeamScoreHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI redScore;

		[SerializeField]
		private LayoutElement space;

		[SerializeField]
		private RectTransform leftScoreBack;

		[SerializeField]
		private RectTransform rightScoreBack;

		[SerializeField]
		private TextMeshProUGUI blueScore;

		public int RedScore
		{
			set
			{
				redScore.text = value.ToString();
			}
		}

		public int BlueScore
		{
			set
			{
				blueScore.text = value.ToString();
			}
		}

		private void OnDisable()
		{
			base.gameObject.SetActive(false);
		}

		public void SetTdmMode()
		{
			space.preferredWidth = 130.6f;
			GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -37f);
			rightScoreBack.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-20f, 0f);
			leftScoreBack.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(20f, 0f);
		}

		public void SetCtfMode()
		{
			space.preferredWidth = 391f;
			GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -76f);
			RectTransform rectTransform = rightScoreBack;
			Vector2 vector = new Vector2(0f, 0f);
			leftScoreBack.offsetMax = vector;
			rectTransform.offsetMin = vector;
		}
	}
}
