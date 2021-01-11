using Tanks.Battle.ClientCore.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

		private void Start()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			if (ErrorScreenData.data != null)
			{
				header.text = ErrorScreenData.data.HeaderText;
				text.text = ErrorScreenData.data.ErrorText;
				restart.text = ErrorScreenData.data.RestartButtonLabel;
				quit.text = ErrorScreenData.data.ExitButtonLabel;
				report.text = ErrorScreenData.data.ReportButtonLabel;
				if (ErrorScreenData.data.ReConnectTime > 0)
				{
					base.gameObject.AddComponent<ReConnectBehaviour>().ReConnectTime = ErrorScreenData.data.ReConnectTime;
					restart.transform.parent.gameObject.SetActive(false);
				}
			}
		}
	}
}
