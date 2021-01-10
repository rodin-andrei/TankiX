using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.Impl
{
	public class CombatEventLogMessageContainter : MonoBehaviour
	{
		[SerializeField]
		private int maxVisibleMessages;
		[SerializeField]
		private CombatEventLogMessage messagePrefab;
		[SerializeField]
		private CombatEventLogText textPrefab;
		[SerializeField]
		private CombatEventLogUser userPrefab;
		[SerializeField]
		private TankPartItemIcon tankPartItemIconPrefab;
		[SerializeField]
		private RectTransform rectTransform;
		[SerializeField]
		private RectTransform rectTransformForMoving;
		[SerializeField]
		private VerticalLayoutGroup verticalLayout;
		public Vector2 anchoredPos;
	}
}
