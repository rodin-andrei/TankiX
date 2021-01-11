using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateUserRankSoundEffectAssetComponent : BehaviourComponent
	{
		[SerializeField]
		private AudioSource selfUserRankSource;

		[SerializeField]
		private AudioSource remoteUserRankSource;

		public AudioSource SelfUserRankSource
		{
			get
			{
				return selfUserRankSource;
			}
		}

		public AudioSource RemoteUserRankSource
		{
			get
			{
				return remoteUserRankSource;
			}
		}
	}
}
