using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

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

		public void SetRank(int rankIconIndex, string rankName)
		{
			rank.text = rankName;
			rankIcon.SelectSprite((rankIconIndex + 1).ToString());
		}
	}
}
