using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientLoading.API
{
	public class LoadingStatusView : MonoBehaviour
	{
		public LocalizedField loadFromNetworkText;
		public LocalizedField mbText;
		public LocalizedField loadFromDiskText;
		public TextMeshProUGUI loadingStatus;
	}
}
