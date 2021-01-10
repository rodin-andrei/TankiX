using UnityEngine;
using Edelweiss.TextureAtlas;

namespace Edelweiss.DecalSystem
{
	public class GenericDecalsBase : MonoBehaviour
	{
		[SerializeField]
		private ProjectionMode m_ProjectionMode;
		[SerializeField]
		private UVMode m_UVMode;
		[SerializeField]
		private UV2Mode m_UV2Mode;
		[SerializeField]
		private NormalsMode m_NormalsMode;
		[SerializeField]
		private TangentsMode m_TangentsMode;
		[SerializeField]
		private bool m_UseVertexColors;
		[SerializeField]
		private Color m_VertexColorTint;
		[SerializeField]
		private bool m_AffectSameLODOnly;
		[SerializeField]
		private LightmapUpdateMode m_LightmapUpdateMode;
		[SerializeField]
		private bool m_AreRenderersEditable;
		[SerializeField]
		private TextureAtlasType m_TextureAtlasType;
		[SerializeField]
		private TextureAtlasAsset m_TextureAtlasAsset;
		[SerializeField]
		private Material m_Material;
		public UVRectangle[] uvRectangles;
		public UVRectangle[] uv2Rectangles;
		[SerializeField]
		private bool m_AreDecalsMeshesOptimized;
		[SerializeField]
		private string m_MeshAssetFolder;
	}
}
