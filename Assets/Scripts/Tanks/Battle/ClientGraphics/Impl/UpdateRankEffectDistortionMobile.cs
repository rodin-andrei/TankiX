using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectDistortionMobile : MonoBehaviour
	{
		public float TextureScale;
		public RenderTextureFormat RenderTextureFormat;
		public FilterMode FilterMode;
		public LayerMask CullingMask;
		public RenderingPath RenderingPath;
		public int FPSWhenMoveCamera;
		public int FPSWhenStaticCamera;
	}
}
