using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class UserExperienceProgressBarComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private ProgressBar progressBar;

		public void SetProgress(float progressValue)
		{
			progressBar.ProgressValue = progressValue;
		}
	}
}
