using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPUserMainInfoComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI nickname;
		[SerializeField]
		private ImageSkin avatar;
		[SerializeField]
		private ImageListSkin league;
		[SerializeField]
		private RankIconComponent rank;
	}
}
