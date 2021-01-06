using UnityEngine;

namespace Tanks.Lobby.ClientLoading.API
{
	public class ResourcesLoadProgressBarComponent : MonoBehaviour
	{
		[SerializeField]
		private float timeBeforeProgressCalculation;
		[SerializeField]
		private float timeToFakeLoad;
		[SerializeField]
		private float bytesToFakeLoad;
		public LoadProgressBarView ProgressBar;
	}
}
