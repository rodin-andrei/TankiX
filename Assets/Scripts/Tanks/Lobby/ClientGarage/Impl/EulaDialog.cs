using System.Collections;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class EulaDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private LocalizedField fileName;

		[SerializeField]
		private TextMeshProUGUI pageLabel;

		[SerializeField]
		private LocalizedField pageLocalizedField;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private GameObject prevPage;

		[SerializeField]
		private GameObject nextPage;

		[SerializeField]
		private GameObject pageButtons;

		[SerializeField]
		private GameObject agreeButton;

		[SerializeField]
		private GameObject loadingIndicator;

		private IEnumerator LoadText()
		{
			string path = "file://" + Application.dataPath + "/config/clientlocal/eula/" + fileName.Value + ".txt";
			WWW www = new WWW(path);
			yield return www;
			text.text = www.text;
			text.pageToDisplay = 1;
			loadingIndicator.SetActive(false);
			yield return new WaitForEndOfFrame();
			pageButtons.SetActive(true);
			agreeButton.SetActive(true);
			UpdatePageLabel();
		}

		public void NextPage()
		{
			text.pageToDisplay = Mathf.Min(text.pageToDisplay + 1, text.textInfo.pageCount);
			UpdatePageLabel();
		}

		public void PrevPage()
		{
			text.pageToDisplay = Mathf.Max(text.pageToDisplay - 1, 1);
			UpdatePageLabel();
		}

		private void UpdatePageLabel()
		{
			pageLabel.text = string.Format("{0} {1}/{2}", pageLocalizedField.Value, text.pageToDisplay, text.textInfo.pageCount);
			UpdatePageButtons();
		}

		private void UpdatePageButtons()
		{
			prevPage.gameObject.SetActive(text.pageToDisplay > 1);
			nextPage.gameObject.SetActive(text.pageToDisplay < text.textInfo.pageCount);
		}

		public new virtual void OnHide()
		{
			base.OnHide();
			text.text = string.Empty;
			pageButtons.SetActive(false);
			agreeButton.SetActive(false);
			loadingIndicator.SetActive(true);
		}

		public override void OnShow()
		{
			base.OnShow();
			StartCoroutine(LoadText());
		}

		public override void Hide()
		{
		}

		public void HideByAcceptButton()
		{
			if (base.show)
			{
				MainScreenComponent.Instance.ClearOnBackOverride();
				base.show = false;
				if (this != null)
				{
					GetComponent<Animator>().SetBool("show", false);
				}
				ShowHiddenScreenParts();
			}
		}
	}
}
