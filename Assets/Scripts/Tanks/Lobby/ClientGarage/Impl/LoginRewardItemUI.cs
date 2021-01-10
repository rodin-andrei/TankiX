using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardItemUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI dayLabel;
		[SerializeField]
		private LoginRewardItemTooltip tooltip;
		[SerializeField]
		private ImageSkin imagePrefab;
		[SerializeField]
		private Transform imagesContainer;
		[SerializeField]
		private LoginRewardProgressBar progressBar;
		[SerializeField]
		private LocalizedField dayLocalizedField;
	}
}
