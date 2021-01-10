using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ParallaxContainer : MonoBehaviour
	{
		[SerializeField]
		private bool isActive;
		[SerializeField]
		private Camera camera;
		[SerializeField]
		private RectTransform layer;
		[SerializeField]
		private RectTransform background;
		[SerializeField]
		private RectTransform container;
		[SerializeField]
		private float mainTransformRotateFactor;
		[SerializeField]
		private float layerMoveFactor;
		[SerializeField]
		private float backgroundMoveFactor;
		[SerializeField]
		private float lerpSpeed;
	}
}
