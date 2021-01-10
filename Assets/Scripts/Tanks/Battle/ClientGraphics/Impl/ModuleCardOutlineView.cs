using UnityEngine;
using Tanks.Lobby.ClientGarage.Impl;

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
	}
}
