using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	[ExecuteInEditMode]
	public class CurvedUITMPSubmesh : MonoBehaviour
	{
		private VertexHelper vh;

		private Mesh savedMesh;

		public void UpdateSubmesh(bool tesselate, bool curve)
		{
			TMP_SubMeshUI component = base.gameObject.GetComponent<TMP_SubMeshUI>();
			if (!(component == null))
			{
				CurvedUIVertexEffect curvedUIVertexEffect = base.gameObject.AddComponentIfMissing<CurvedUIVertexEffect>();
				if (tesselate || savedMesh == null || vh == null || !Application.isPlaying)
				{
					vh = new VertexHelper(component.mesh);
					ModifyMesh(curvedUIVertexEffect);
					savedMesh = new Mesh();
					vh.FillMesh(savedMesh);
					curvedUIVertexEffect.TesselationRequired = true;
				}
				else if (curve)
				{
					ModifyMesh(curvedUIVertexEffect);
					vh.FillMesh(savedMesh);
					curvedUIVertexEffect.CurvingRequired = true;
				}
				component.canvasRenderer.SetMesh(savedMesh);
			}
		}

		private void ModifyMesh(CurvedUIVertexEffect crvdVE)
		{
			crvdVE.ModifyMesh(vh);
		}
	}
}
