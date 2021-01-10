using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientLoading.API
{
	public class LobbyLoadScreenComponent : MonoBehaviour
	{
		public TextMeshProUGUI initialization;
		public ResourcesLoadProgressBarComponent progressBar;
		public LoadingStatusView loadingStatus;
	}
}
