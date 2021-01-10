using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class CharacterShadowCommonSettingsComponent : MonoBehaviour
	{
		public Shader blurShader;
		public Shader casterShader;
		public Shader receiverShader;
		public LayerMask ignoreLayers;
		public int maxShadowMapAtlasSize;
		public int textureSize;
		public int blurSize;
		public Transform virtualLight;
		public RenderTexture shadowMap;
	}
}
