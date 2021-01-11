using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class NormalRPMSoundModifier : AbstractRPMSoundModifier
	{
		public override bool CheckLoad(float smoothedLoad)
		{
			return smoothedLoad < 1f;
		}

		public override float CalculateLoadPartForModifier(float smoothedLoad)
		{
			return Mathf.Sqrt(1f - CalculateLinearLoadModifier(smoothedLoad));
		}
	}
}
