using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CombatEventLogUser : BaseCombatLogMessageElement
	{
		[SerializeField]
		private ImageListSkin rankIcon;

		[SerializeField]
		private TextMeshProUGUI userName;

		public ImageListSkin RankIcon
		{
			get
			{
				return rankIcon;
			}
		}

		public TextMeshProUGUI UserName
		{
			get
			{
				return userName;
			}
		}
	}
}
