using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class RankUI : MonoBehaviour
	{
		[SerializeField]
		private ImageListSkin rankIcon;
		[SerializeField]
		private TextMeshProUGUI rank;
		[SerializeField]
		private LocalizedField rankLocalizedField;
	}
}
