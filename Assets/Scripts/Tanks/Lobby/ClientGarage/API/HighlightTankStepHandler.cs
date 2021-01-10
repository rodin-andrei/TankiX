using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class HighlightTankStepHandler : TutorialStepHandler
	{
		[SerializeField]
		private RectTransform popupPositionRect;
		[SerializeField]
		private float cameraOffset;
		[SerializeField]
		private GameObject outlinePrefab;
		[SerializeField]
		private bool useOverlay;
	}
}
