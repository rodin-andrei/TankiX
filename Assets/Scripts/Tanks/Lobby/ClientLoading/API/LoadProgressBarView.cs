using UnityEngine;
using Tanks.Battle.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientLoading.API
{
	public class LoadProgressBarView : MonoBehaviour
	{
		public ProgressBarComponent progressBar;
		public RectTransform endLine;
		public TextMeshProUGUI progressText;
	}
}
