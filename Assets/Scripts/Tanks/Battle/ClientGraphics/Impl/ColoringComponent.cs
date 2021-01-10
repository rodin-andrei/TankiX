using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ColoringComponent : BehaviourComponent
	{
		public enum COLORING_MAP_ALPHA_MODE
		{
			NONE = -1,
			AS_EMISSION_MASK = 1,
			AS_SMOOTHNESS = 2,
		}

		public Color32 color;
		public Texture2D coloringTexture;
		public COLORING_MAP_ALPHA_MODE coloringTextureAlphaMode;
		public Texture2D coloringNormalMap;
		public float coloringNormalScale;
		public float metallic;
		public bool overwriteSmoothness;
		public float smoothnessStrength;
		public bool useColoringIntensityThreshold;
		public float coloringMaskThreshold;
		public bool overrideEmission;
		public Color emissionColor;
		public float emissionIntensity;
	}
}
