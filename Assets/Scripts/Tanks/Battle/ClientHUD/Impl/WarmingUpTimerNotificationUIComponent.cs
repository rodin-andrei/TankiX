using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class WarmingUpTimerNotificationUIComponent : BehaviourComponent
	{
		[SerializeField]
		private AssetReference voiceReference;

		public AssetReference VoiceReference
		{
			get
			{
				return voiceReference;
			}
		}

		public void PlaySound(GameObject voice)
		{
			Object.Instantiate(voice);
		}
	}
}
