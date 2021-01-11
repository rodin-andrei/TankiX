using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CombatEventLogText : BaseCombatLogMessageElement
	{
		[SerializeField]
		private TMP_Text text;

		public TMP_Text Text
		{
			get
			{
				return text;
			}
		}
	}
}
