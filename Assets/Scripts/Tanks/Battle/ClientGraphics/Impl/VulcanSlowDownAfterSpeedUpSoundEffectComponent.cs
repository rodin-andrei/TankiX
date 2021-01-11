using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class VulcanSlowDownAfterSpeedUpSoundEffectComponent : AbstractVulcanSoundEffectComponent
	{
		[SerializeField]
		private float additionalStartTimeOffset;

		public float AdditionalStartTimeOffset
		{
			get
			{
				return additionalStartTimeOffset;
			}
			set
			{
				additionalStartTimeOffset = value;
			}
		}
	}
}
