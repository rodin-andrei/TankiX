using UnityEngine;

namespace Edelweiss.DecalSystem
{
	public class GenericDecalProjectorBaseComponent : MonoBehaviour
	{
		public LayerMask affectedLayers;
		public bool affectInactiveRenderers;
		public bool affectOtherDecals;
		public bool skipUnreadableMeshes;
		public DetailsMode detailsMode;
		public AffectedDetail[] affectedDetails;
		public float cullingAngle;
		public float meshOffset;
		public bool projectAfterOffset;
		public float normalsSmoothing;
		public int uv1RectangleIndex;
		public int uv2RectangleIndex;
		public Color vertexColor;
		[SerializeField]
		private float m_VertexColorBlending;
	}
}
