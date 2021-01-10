using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ColoredProgressBar : MonoBehaviour
	{
		[SerializeField]
		private float initialProgress;
		[SerializeField]
		private float coloredProgress;
		[SerializeField]
		private RectTransform initialMask;
		[SerializeField]
		private RectTransform initialFiller;
		[SerializeField]
		private RectTransform coloredMask;
		[SerializeField]
		private RectTransform coloredInnerMask;
		[SerializeField]
		private RectTransform coloredFiller;
	}
}
