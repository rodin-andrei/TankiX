using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class CombatEventLogUser : BaseCombatLogMessageElement
	{
		[SerializeField]
		private ImageListSkin rankIcon;
		[SerializeField]
		private TextMeshProUGUI userName;
	}
}
