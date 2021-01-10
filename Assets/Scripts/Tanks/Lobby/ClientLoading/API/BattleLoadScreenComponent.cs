using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientLoading.API
{
	public class BattleLoadScreenComponent : MonoBehaviour
	{
		public Image mapPreview;
		public TextMeshProUGUI mapName;
		public TextMeshProUGUI battleInfo;
		public ResourcesLoadProgressBarComponent progressBar;
		public TextMeshProUGUI flavorText;
		public TextMeshProUGUI initialization;
		public LocalizedField arcadeBattleText;
		public LocalizedField energyBattleText;
		public LocalizedField ratingBattleText;
		public LoadingStatusView loadingStatusView;
	}
}
