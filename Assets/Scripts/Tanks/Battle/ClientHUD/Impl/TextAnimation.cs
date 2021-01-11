using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(NormalizedAnimatedValue))]
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextAnimation : MonoBehaviour
	{
		private string targetText;

		private bool inFadeMode;

		public string Text
		{
			set
			{
				if (targetText != value)
				{
					GetComponent<TextMeshProUGUI>().text = value;
					GetComponent<Animator>().SetTrigger("Start");
				}
			}
		}

		private void SwitchMode()
		{
		}

		private void OnDisable()
		{
			targetText = string.Empty;
			GetComponent<TextMeshProUGUI>().text = string.Empty;
		}
	}
}
