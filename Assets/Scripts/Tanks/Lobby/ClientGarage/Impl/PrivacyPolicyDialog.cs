using System.Collections;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PrivacyPolicyDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private LocalizedField fileName;

		[SerializeField]
		private TextMeshProUGUI text;

		private IEnumerator LoadText()
		{
			string path = "file://" + Application.dataPath + "/config/clientlocal/privacypolicy/" + fileName.Value + ".txt";
			WWW www = new WWW(path);
			yield return www;
			text.text = www.text;
			text.gameObject.AddComponent<TMPLink>();
		}

		public new virtual void OnHide()
		{
			base.OnHide();
			text.text = string.Empty;
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
