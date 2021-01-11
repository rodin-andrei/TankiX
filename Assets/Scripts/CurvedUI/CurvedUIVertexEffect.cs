using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CurvedUIVertexEffect : BaseMeshEffect
	{
		[Tooltip("Check to skip tesselation pass on this object. CurvedUI will not create additional vertices to make this object have a smoother curve. Checking this can solve some issues if you create your own procedural mesh for this object. Default false.")]
		public bool DoNotTesselate;

		private Canvas myCanvas;

		private CurvedUISettings mySettings;

		private Graphic myGraphic;

		private Image myImage;

		private Text myText;

		private TextMeshProUGUI myTMP;

		private CurvedUITMPSubmesh myTMPSubMesh;

		private bool tesselationRequired = true;

		private bool curvingRequired = true;

		private float angle = 90f;

		private bool TransformMisaligned;

		private Matrix4x4 CanvasToWorld;

		private Matrix4x4 CanvasToLocal;

		private Matrix4x4 MyToWorld;

		private Matrix4x4 MyToLocal;

		private VertexHelper SavedVertexHelper;

		private List<UIVertex> SavedVerteees;

		private List<UIVertex> tesselatedVerts;

		[SerializeField]
		[HideInInspector]
		private Vector3 savedPos;

		[SerializeField]
		[HideInInspector]
		private Vector3 savedUp;

		[SerializeField]
		[HideInInspector]
		private Vector2 savedRectSize;

		[SerializeField]
		[HideInInspector]
		private Color savedColor;

		[SerializeField]
		[HideInInspector]
		private Vector2 savedTextUV0;

		[SerializeField]
		[HideInInspector]
		private float savedFill;

		public bool TesselationRequired
		{
			get
			{
				return tesselationRequired;
			}
			set
			{
				tesselationRequired = value;
			}
		}

		public bool CurvingRequired
		{
			get
			{
				return curvingRequired;
			}
			set
			{
				curvingRequired = value;
			}
		}

		protected override void OnEnable()
		{
			FindParentSettings();
			myGraphic = GetComponent<Graphic>();
			if ((bool)myGraphic)
			{
				myGraphic.RegisterDirtyMaterialCallback(TesselationRequiredCallback);
				myGraphic.SetVerticesDirty();
			}
			myText = GetComponent<Text>();
			if ((bool)myText)
			{
				myText.RegisterDirtyVerticesCallback(TesselationRequiredCallback);
				Font.textureRebuilt += FontTextureRebuiltCallback;
			}
			myTMP = GetComponent<TextMeshProUGUI>();
			myTMPSubMesh = GetComponent<CurvedUITMPSubmesh>();
		}

		protected override void OnDisable()
		{
			if ((bool)myGraphic)
			{
				myGraphic.UnregisterDirtyMaterialCallback(TesselationRequiredCallback);
			}
			if ((bool)myText)
			{
				myText.UnregisterDirtyVerticesCallback(TesselationRequiredCallback);
				Font.textureRebuilt -= FontTextureRebuiltCallback;
			}
		}

		private void TesselationRequiredCallback()
		{
			tesselationRequired = true;
		}

		private void FontTextureRebuiltCallback(Font fontie)
		{
			if (myText.font == fontie)
			{
				tesselationRequired = true;
			}
		}

		private void Update()
		{
			if ((bool)myTMP || (bool)myTMPSubMesh)
			{
				return;
			}
			if (!tesselationRequired)
			{
				if ((base.transform as RectTransform).rect.size != savedRectSize)
				{
					tesselationRequired = true;
				}
				else if (myGraphic != null)
				{
					if (myGraphic.color != savedColor)
					{
						tesselationRequired = true;
						savedColor = myGraphic.color;
					}
					else if (myImage != null && myImage.fillAmount != savedFill)
					{
						tesselationRequired = true;
						savedFill = myImage.fillAmount;
					}
				}
			}
			if (!tesselationRequired && !curvingRequired)
			{
				Vector3 a = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(base.transform.position);
				if (!a.AlmostEqual(savedPos) && (mySettings.Shape != 0 || (double)Mathf.Pow(a.x - savedPos.x, 2f) > 1E-05 || (double)Mathf.Pow(a.z - savedPos.z, 2f) > 1E-05))
				{
					savedPos = a;
					curvingRequired = true;
				}
				Vector3 normalized = mySettings.transform.worldToLocalMatrix.MultiplyVector(base.transform.up).normalized;
				if (!savedUp.AlmostEqual(normalized, 0.0001))
				{
					bool flag = normalized.AlmostEqual(Vector3.up.normalized);
					bool flag2 = savedUp.AlmostEqual(Vector3.up.normalized);
					if ((!flag && flag2) || (flag && !flag2))
					{
						tesselationRequired = true;
					}
					savedUp = normalized;
					curvingRequired = true;
				}
			}
			if ((bool)myGraphic && (tesselationRequired || curvingRequired))
			{
				myGraphic.SetVerticesDirty();
			}
		}

		public override void ModifyMesh(VertexHelper vh)
		{
			if (!IsActive())
			{
				return;
			}
			if (mySettings == null)
			{
				FindParentSettings();
			}
			if (mySettings == null || !mySettings.enabled)
			{
				return;
			}
			CheckTextFontMaterial();
			if (tesselationRequired || curvingRequired || SavedVertexHelper == null || SavedVertexHelper.currentVertCount == 0)
			{
				SavedVerteees = new List<UIVertex>();
				vh.GetUIVertexStream(SavedVerteees);
				ModifyVerts(SavedVerteees);
				if (SavedVertexHelper == null)
				{
					SavedVertexHelper = new VertexHelper();
				}
				else
				{
					SavedVertexHelper.Clear();
				}
				if (SavedVerteees.Count % 4 == 0)
				{
					for (int i = 0; i < SavedVerteees.Count; i += 4)
					{
						SavedVertexHelper.AddUIVertexQuad(new UIVertex[4]
						{
							SavedVerteees[i],
							SavedVerteees[i + 1],
							SavedVerteees[i + 2],
							SavedVerteees[i + 3]
						});
					}
				}
				else
				{
					SavedVertexHelper.AddUIVertexTriangleStream(SavedVerteees);
				}
				SavedVertexHelper.GetUIVertexStream(SavedVerteees);
				curvingRequired = false;
			}
			vh.Clear();
			vh.AddUIVertexTriangleStream(SavedVerteees);
		}

		private void CheckTextFontMaterial()
		{
			if ((bool)myText && myText.cachedTextGenerator.verts.Count > 0 && myText.cachedTextGenerator.verts[0].uv0 != savedTextUV0)
			{
				savedTextUV0 = myText.cachedTextGenerator.verts[0].uv0;
				tesselationRequired = true;
			}
		}

		public CurvedUISettings FindParentSettings(bool forceNew = false)
		{
			if (mySettings == null || forceNew)
			{
				mySettings = GetComponentInParent<CurvedUISettings>();
				if (mySettings == null)
				{
					return null;
				}
				myCanvas = mySettings.GetComponent<Canvas>();
				angle = mySettings.Angle;
				myImage = GetComponent<Image>();
			}
			return mySettings;
		}

		private void ModifyVerts(List<UIVertex> verts)
		{
			if (verts == null || verts.Count == 0)
			{
				return;
			}
			CanvasToWorld = myCanvas.transform.localToWorldMatrix;
			CanvasToLocal = myCanvas.transform.worldToLocalMatrix;
			MyToWorld = base.transform.localToWorldMatrix;
			MyToLocal = base.transform.worldToLocalMatrix;
			if (tesselationRequired || !Application.isPlaying)
			{
				TesselateGeometry(verts);
				tesselatedVerts = new List<UIVertex>(verts);
				savedRectSize = (base.transform as RectTransform).rect.size;
				tesselationRequired = false;
			}
			angle = mySettings.Angle;
			float cyllinderRadiusInCanvasSpace = mySettings.GetCyllinderRadiusInCanvasSpace();
			Vector2 size = (myCanvas.transform as RectTransform).rect.size;
			int count = verts.Count;
			if (tesselatedVerts != null)
			{
				UIVertex[] array = new UIVertex[tesselatedVerts.Count];
				for (int i = 0; i < tesselatedVerts.Count; i++)
				{
					array[i] = CurveVertex(tesselatedVerts[i], angle, cyllinderRadiusInCanvasSpace, size);
				}
				verts.AddRange(array);
				verts.RemoveRange(0, count);
			}
			else
			{
				UIVertex[] array2 = new UIVertex[verts.Count];
				for (int j = 0; j < count; j++)
				{
					array2[j] = CurveVertex(verts[j], angle, cyllinderRadiusInCanvasSpace, size);
				}
				verts.AddRange(array2);
				verts.RemoveRange(0, count);
			}
		}

		private UIVertex CurveVertex(UIVertex input, float cylinder_angle, float radius, Vector2 canvasSize)
		{
			Vector3 v = input.position;
			v = CanvasToLocal.MultiplyPoint3x4(MyToWorld.MultiplyPoint3x4(v));
			if (mySettings.Shape == CurvedUISettings.CurvedUIShape.CYLINDER && mySettings.Angle != 0)
			{
				float f = v.x / canvasSize.x * cylinder_angle * ((float)Math.PI / 180f);
				radius += v.z;
				v.x = Mathf.Sin(f) * radius;
				v.z += Mathf.Cos(f) * radius - radius;
			}
			else if (mySettings.Shape == CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL && mySettings.Angle != 0)
			{
				float f2 = v.y / canvasSize.y * cylinder_angle * ((float)Math.PI / 180f);
				radius += v.z;
				v.y = Mathf.Sin(f2) * radius;
				v.z += Mathf.Cos(f2) * radius - radius;
			}
			else if (mySettings.Shape == CurvedUISettings.CurvedUIShape.RING)
			{
				float num = 0f;
				float num2 = v.y.Remap(canvasSize.y * 0.5f * (float)(mySettings.RingFlipVertical ? 1 : (-1)), (0f - canvasSize.y) * 0.5f * (float)(mySettings.RingFlipVertical ? 1 : (-1)), (float)mySettings.RingExternalDiameter * (1f - mySettings.RingFill) * 0.5f, (float)mySettings.RingExternalDiameter * 0.5f);
				float f3 = (v.x / canvasSize.x).Remap(-0.5f, 0.5f, (float)Math.PI / 2f, cylinder_angle * ((float)Math.PI / 180f) + (float)Math.PI / 2f) - num;
				v.x = num2 * Mathf.Cos(f3);
				v.y = num2 * Mathf.Sin(f3);
			}
			else if (mySettings.Shape == CurvedUISettings.CurvedUIShape.SPHERE && mySettings.Angle != 0)
			{
				float num3 = mySettings.VerticalAngle;
				float num4 = 0f - v.z;
				if (mySettings.PreserveAspect)
				{
					num3 = cylinder_angle * (canvasSize.y / canvasSize.x);
				}
				else
				{
					radius = canvasSize.x / 2f;
					if (num3 == 0f)
					{
						return input;
					}
				}
				float num5 = (v.x / canvasSize.x).Remap(-0.5f, 0.5f, (180f - cylinder_angle) / 2f - 90f, 180f - (180f - cylinder_angle) / 2f - 90f);
				num5 *= (float)Math.PI / 180f;
				float num6 = (v.y / canvasSize.y).Remap(-0.5f, 0.5f, (180f - num3) / 2f, 180f - (180f - num3) / 2f);
				num6 *= (float)Math.PI / 180f;
				v.z = Mathf.Sin(num6) * Mathf.Cos(num5) * (radius + num4);
				v.y = (0f - (radius + num4)) * Mathf.Cos(num6);
				v.x = Mathf.Sin(num6) * Mathf.Sin(num5) * (radius + num4);
				if (mySettings.PreserveAspect)
				{
					v.z -= radius;
				}
			}
			input.position = MyToLocal.MultiplyPoint3x4(CanvasToWorld.MultiplyPoint3x4(v));
			return input;
		}

		private void TesselateGeometry(List<UIVertex> verts)
		{
			Vector2 tesslationSize = mySettings.GetTesslationSize();
			TransformMisaligned = !savedUp.AlmostEqual(Vector3.up.normalized);
			TrisToQuads(verts);
			if (myText == null && myTMP == null && !DoNotTesselate)
			{
				int count = verts.Count;
				for (int i = 0; i < count; i += 4)
				{
					ModifyQuad(verts, i, tesslationSize);
				}
				verts.RemoveRange(0, count);
			}
		}

		private void ModifyQuad(List<UIVertex> verts, int vertexIndex, Vector2 requiredSize)
		{
			UIVertex[] array = new UIVertex[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = verts[vertexIndex + i];
			}
			Vector3 vector = array[2].position - array[1].position;
			Vector3 vector2 = array[1].position - array[0].position;
			if (myImage != null && myImage.type == Image.Type.Filled)
			{
				vector = ((!(vector.x > (array[3].position - array[0].position).x)) ? (array[3].position - array[0].position) : vector);
				vector2 = ((!(vector2.y > (array[2].position - array[3].position).y)) ? (array[2].position - array[3].position) : vector2);
			}
			int num = 1;
			int num2 = 1;
			if (TransformMisaligned || mySettings.Shape == CurvedUISettings.CurvedUIShape.SPHERE || mySettings.Shape == CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL)
			{
				num2 = Mathf.CeilToInt(vector2.magnitude * (1f / Mathf.Max(1f, requiredSize.y)));
			}
			if (TransformMisaligned || mySettings.Shape != CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL)
			{
				num = Mathf.CeilToInt(vector.magnitude * (1f / Mathf.Max(1f, requiredSize.x)));
			}
			bool flag = false;
			bool flag2 = false;
			float y = 0f;
			for (int j = 0; j < num2 || !flag; j++)
			{
				flag = true;
				float num3 = ((float)j + 1f) / (float)num2;
				float x = 0f;
				for (int k = 0; k < num || !flag2; k++)
				{
					flag2 = true;
					float num4 = ((float)k + 1f) / (float)num;
					verts.Add(TesselateQuad(array, x, y));
					verts.Add(TesselateQuad(array, x, num3));
					verts.Add(TesselateQuad(array, num4, num3));
					verts.Add(TesselateQuad(array, num4, y));
					x = num4;
				}
				y = num3;
			}
		}

		private void TrisToQuads(List<UIVertex> verts)
		{
			int num = 0;
			int count = verts.Count;
			UIVertex[] array = new UIVertex[count / 6 * 4];
			for (int i = 0; i < count; i += 6)
			{
				array[num++] = verts[i];
				array[num++] = verts[i + 1];
				array[num++] = verts[i + 2];
				array[num++] = verts[i + 4];
			}
			verts.AddRange(array);
			verts.RemoveRange(0, count);
		}

		private UIVertex TesselateQuad(UIVertex[] quad, float x, float y)
		{
			UIVertex result = default(UIVertex);
			float[] array = new float[4]
			{
				(1f - x) * (1f - y),
				(1f - x) * y,
				x * y,
				x * (1f - y)
			};
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			Vector3 zero3 = Vector3.zero;
			for (int i = 0; i < 4; i++)
			{
				zero += quad[i].uv0 * array[i];
				zero2 += quad[i].uv1 * array[i];
				zero3 += quad[i].position * array[i];
			}
			result.position = zero3;
			result.color = quad[0].color;
			result.uv0 = zero;
			result.uv1 = zero2;
			result.normal = quad[0].normal;
			result.tangent = quad[0].tangent;
			return result;
		}

		public void SetDirty()
		{
			TesselationRequired = true;
		}
	}
}
