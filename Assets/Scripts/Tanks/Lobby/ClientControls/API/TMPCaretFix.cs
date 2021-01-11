using System.Collections;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class TMPCaretFix : MonoBehaviour
	{
		private void OnEnable()
		{
			StartCoroutine(Delay());
		}

		private IEnumerator Delay()
		{
			yield return new WaitForEndOfFrame();
			TMP_SelectionCaret caret = GetComponentInChildren<TMP_SelectionCaret>();
			if (caret != null)
			{
				caret.rectTransform.anchoredPosition = new Vector2(-5f, 0f);
				caret.rectTransform.sizeDelta = new Vector2(-10f, 0f);
			}
		}
	}
}
