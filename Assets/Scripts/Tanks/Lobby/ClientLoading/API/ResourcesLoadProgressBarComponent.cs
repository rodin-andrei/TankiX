using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientLoading.API
{
	public class ResourcesLoadProgressBarComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public static float PROGRESS_VISUAL_KOEFF = 0.95f;

		[SerializeField]
		private float timeBeforeProgressCalculation = 0.1f;

		[SerializeField]
		private float timeToFakeLoad = 2f;

		[SerializeField]
		private float bytesToFakeLoad = 1048576f;

		public LoadProgressBarView ProgressBar;

		public float TimeBeforeProgressCalculation
		{
			get
			{
				return timeBeforeProgressCalculation;
			}
			set
			{
				timeBeforeProgressCalculation = value;
			}
		}

		public float TimeToFakeLoad
		{
			get
			{
				return timeToFakeLoad;
			}
			set
			{
				timeToFakeLoad = value;
			}
		}

		public float BytesToFakeLoad
		{
			get
			{
				return bytesToFakeLoad;
			}
			set
			{
				bytesToFakeLoad = value;
			}
		}

		private void OnEnable()
		{
			ProgressBar.ProgressValue = 0f;
		}

		public void UpdateView(LoadBundlesTaskComponent loadBundlesTask)
		{
			float num = Mathf.Clamp(Time.realtimeSinceStartup - loadBundlesTask.LoadingStartTime, 0f, TimeToFakeLoad);
			float num2 = Mathf.Clamp(num / TimeToFakeLoad, 0f, 1f);
			float num3 = num2 * BytesToFakeLoad;
			float num4 = 0f;
			num4 = ((loadBundlesTask.BytesToLoad <= 0) ? (num3 / BytesToFakeLoad) : (((float)loadBundlesTask.BytesLoaded + num3) / ((float)loadBundlesTask.BytesToLoad + BytesToFakeLoad)));
			float num5 = num4 * PROGRESS_VISUAL_KOEFF;
			if (ProgressBar.ProgressValue < num5)
			{
				ProgressBar.ProgressValue = num4 * PROGRESS_VISUAL_KOEFF;
			}
			if (loadBundlesTask.AllBundlesLoaded())
			{
				ProgressBar.ProgressValue = 1f;
			}
		}
	}
}
