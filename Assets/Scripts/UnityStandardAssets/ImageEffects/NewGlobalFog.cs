using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	internal class NewGlobalFog : PostEffectsBase
	{
		public bool distanceFog;
		public bool useRadialDistance;
		public bool heightFog;
		public float height;
		public float heightDensity;
		public float startDistance;
		public float ShaftDensity;
		public Shader fogShader;
		public Color fogColor;
		public float fogFacCoef;
		public bool horizontalFog;
	}
}
