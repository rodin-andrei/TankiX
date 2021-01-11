using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EMPWaveGraphicsEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private EMPWaveGraphicsBehaviour empWaveAsset;

		public EMPWaveGraphicsBehaviour EMPWaveAsset
		{
			get
			{
				return empWaveAsset;
			}
		}
	}
}
