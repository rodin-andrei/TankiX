using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ModuleCardOutlineView : MonoBehaviour
	{
		[SerializeField]
		private Color[] tierColor;

		[SerializeField]
		private OutlineObject outline;

		[SerializeField]
		private ModuleCardView card;

		public void Start()
		{
			outline.GlowColor = tierColor[card.tierNumber];
		}
	}
}
