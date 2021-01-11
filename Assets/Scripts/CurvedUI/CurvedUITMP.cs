using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	[ExecuteInEditMode]
	public class CurvedUITMP : MonoBehaviour
	{
		private CurvedUIVertexEffect crvdVE;

		private TextMeshProUGUI tmp;

		private CurvedUISettings mySettings;

		private Mesh savedMesh;

		private VertexHelper vh;

		private Vector2 savedSize;

		private Vector3 savedUp;

		private Vector3 savedPos;

		private Vector3 savedCanvasSize;

		private List<CurvedUITMPSubmesh> subMeshes = new List<CurvedUITMPSubmesh>();

		[HideInInspector]
		public bool Dirty;

		private bool curvingRequired;

		private bool tesselationRequired;

		private void FindTMP()
		{
			if (GetComponent<TextMeshProUGUI>() != null)
			{
				tmp = base.gameObject.GetComponent<TextMeshProUGUI>();
				crvdVE = base.gameObject.GetComponent<CurvedUIVertexEffect>();
				mySettings = GetComponentInParent<CurvedUISettings>();
				base.transform.hasChanged = false;
				FindSubmeshes();
			}
		}

		private void FindSubmeshes()
		{
			TMP_SubMeshUI[] componentsInChildren = GetComponentsInChildren<TMP_SubMeshUI>();
			foreach (TMP_SubMeshUI tMP_SubMeshUI in componentsInChildren)
			{
				CurvedUITMPSubmesh item = tMP_SubMeshUI.gameObject.AddComponentIfMissing<CurvedUITMPSubmesh>();
				if (!subMeshes.Contains(item))
				{
					subMeshes.Add(item);
				}
			}
		}

		private void OnEnable()
		{
			FindTMP();
			if (tmp != null)
			{
				tmp.RegisterDirtyMaterialCallback(TesselationRequiredCallback);
				TMPro_EventManager.TEXT_CHANGED_EVENT.Add(TMPTextChangedCallback);
			}
		}

		private void OnDisable()
		{
			if (tmp != null)
			{
				tmp.UnregisterDirtyMaterialCallback(TesselationRequiredCallback);
				TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(TMPTextChangedCallback);
			}
		}

		private void TMPTextChangedCallback(object obj)
		{
			if (obj == tmp)
			{
				tesselationRequired = true;
			}
		}

		private void TesselationRequiredCallback()
		{
			tesselationRequired = true;
			curvingRequired = true;
		}

		private void LateUpdate()
		{
			if (tmp != null)
			{
				if (savedSize != (base.transform as RectTransform).rect.size)
				{
					tesselationRequired = true;
				}
				else if (savedCanvasSize != mySettings.transform.localScale)
				{
					tesselationRequired = true;
				}
				else if (!savedPos.AlmostEqual(mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(base.transform.position)))
				{
					curvingRequired = true;
				}
				else if (!savedUp.AlmostEqual(mySettings.transform.worldToLocalMatrix.MultiplyVector(base.transform.up)))
				{
					curvingRequired = true;
				}
				if (Dirty || tesselationRequired || savedMesh == null || vh == null || (curvingRequired && !Application.isPlaying))
				{
					tmp.renderMode = TextRenderFlags.Render;
					tmp.ForceMeshUpdate();
					vh = new VertexHelper(tmp.mesh);
					crvdVE.TesselationRequired = true;
					crvdVE.ModifyMesh(vh);
					savedMesh = new Mesh();
					vh.FillMesh(savedMesh);
					tmp.renderMode = TextRenderFlags.DontRender;
					tesselationRequired = false;
					Dirty = false;
					savedSize = (base.transform as RectTransform).rect.size;
					savedUp = mySettings.transform.worldToLocalMatrix.MultiplyVector(base.transform.up);
					savedPos = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(base.transform.position);
					savedCanvasSize = mySettings.transform.localScale;
					FindSubmeshes();
					foreach (CurvedUITMPSubmesh subMesh in subMeshes)
					{
						subMesh.UpdateSubmesh(true, false);
					}
				}
				if (curvingRequired)
				{
					crvdVE.TesselationRequired = false;
					crvdVE.CurvingRequired = true;
					crvdVE.ModifyMesh(vh);
					vh.FillMesh(savedMesh);
					curvingRequired = false;
					savedSize = (base.transform as RectTransform).rect.size;
					savedUp = mySettings.transform.worldToLocalMatrix.MultiplyVector(base.transform.up);
					savedPos = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(base.transform.position);
					foreach (CurvedUITMPSubmesh subMesh2 in subMeshes)
					{
						subMesh2.UpdateSubmesh(false, true);
					}
				}
				tmp.canvasRenderer.SetMesh(savedMesh);
			}
			else
			{
				FindTMP();
			}
		}
	}
}
