using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.API
{
	[RequireComponent(typeof(Button))]
	public class ReportButtonBehaviour : MonoBehaviour
	{
		[SerializeField]
		private string defaultReportUrl;

		public string ReportUrl
		{
			get;
			set;
		}

		private void Awake()
		{
			ReportUrl = defaultReportUrl;
			GetComponent<Button>().onClick.AddListener(OpenUrl);
		}

		private void OpenUrl()
		{
			Application.OpenURL(ReportUrl);
		}
	}
}
