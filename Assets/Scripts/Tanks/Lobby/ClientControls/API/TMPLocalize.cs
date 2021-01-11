using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class TMPLocalize : MonoBehaviour
	{
		[SerializeField]
		private string uid;

		public string TextUid
		{
			get
			{
				return uid;
			}
		}

		protected void Awake()
		{
			if (Application.isPlaying)
			{
				string text = LocalizationUtils.Localize(uid);
				TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
				if (!string.IsNullOrEmpty(text) && component != null)
				{
					text = (component.text = text.Replace("\\n", "\n"));
				}
			}
		}
	}
}
