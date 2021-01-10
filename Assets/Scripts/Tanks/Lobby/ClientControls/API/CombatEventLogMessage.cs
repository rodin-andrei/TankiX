using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class CombatEventLogMessage : BaseCombatLogMessageElement
	{
		[SerializeField]
		private float messageTimeout;
		[SerializeField]
		private LayoutElement layoutElement;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		protected RectTransform placeholder;
	}
}
