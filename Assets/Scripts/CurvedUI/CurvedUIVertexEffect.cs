using UnityEngine.UI;
using UnityEngine;

namespace CurvedUI
{
	public class CurvedUIVertexEffect : BaseMeshEffect
	{
		public override void ModifyMesh(VertexHelper vh)
		{
		}

		public bool DoNotTesselate;
		[SerializeField]
		private Vector3 savedPos;
		[SerializeField]
		private Vector3 savedUp;
		[SerializeField]
		private Vector2 savedRectSize;
		[SerializeField]
		private Color savedColor;
		[SerializeField]
		private Vector2 savedTextUV0;
		[SerializeField]
		private float savedFill;
	}
}
