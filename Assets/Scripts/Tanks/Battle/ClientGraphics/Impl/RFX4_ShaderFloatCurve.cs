using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RFX4_ShaderFloatCurve : MonoBehaviour
	{
		public RFX4_ShaderProperties ShaderFloatProperty;
		public AnimationCurve FloatCurve;
		public float GraphTimeMultiplier;
		public float GraphIntensityMultiplier;
		public bool IsLoop;
		public bool UseSharedMaterial;
	}
}
