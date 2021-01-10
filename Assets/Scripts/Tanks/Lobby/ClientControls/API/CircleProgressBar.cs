using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class CircleProgressBar : MonoBehaviour
	{
		[SerializeField]
		private float animationSpeed;
		[SerializeField]
		private Image mainProgressImage;
		[SerializeField]
		private Image additionalProgressImage;
		[SerializeField]
		private Image additionalProgressContainer;
		[SerializeField]
		private Image additionalProgressImage1;
		[SerializeField]
		private Image additionalProgressContainer1;
		[SerializeField]
		private float progress;
		[SerializeField]
		private float additionalProgress;
		[SerializeField]
		private float additionalProgress1;
	}
}
