using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	[AddComponentMenu("CurvedUI/CurvedUISettings")]
	[RequireComponent(typeof(Canvas))]
	public class CurvedUISettings : MonoBehaviour
	{
		public enum CurvedUIShape
		{
			CYLINDER,
			RING,
			SPHERE,
			CYLINDER_VERTICAL
		}

		[SerializeField]
		private CurvedUIShape shape;

		[SerializeField]
		private float quality = 1f;

		[SerializeField]
		private bool interactable = true;

		[SerializeField]
		private bool blocksRaycasts = true;

		[SerializeField]
		private bool raycastMyLayerOnly = true;

		[SerializeField]
		private bool forceUseBoxCollider = true;

		[SerializeField]
		private int angle = 90;

		[SerializeField]
		private bool preserveAspect = true;

		[SerializeField]
		private int vertAngle = 90;

		[SerializeField]
		private float ringFill = 0.5f;

		[SerializeField]
		private int ringExternalDiamater = 1000;

		[SerializeField]
		private bool ringFlipVertical;

		private int baseCircleSegments = 24;

		private Vector2 savedRectSize;

		private float savedRadius;

		private Canvas myCanvas;

		private RectTransform m_rectTransform;

		private RectTransform RectTransform
		{
			get
			{
				if (m_rectTransform == null)
				{
					m_rectTransform = base.transform as RectTransform;
				}
				return m_rectTransform;
			}
		}

		public int BaseCircleSegments
		{
			get
			{
				return baseCircleSegments;
			}
		}

		public int Angle
		{
			get
			{
				return angle;
			}
			set
			{
				if (angle != value)
				{
					SetUIAngle(value);
				}
			}
		}

		public float Quality
		{
			get
			{
				return quality;
			}
			set
			{
				if (quality != value)
				{
					quality = value;
					SetUIAngle(angle);
				}
			}
		}

		public CurvedUIShape Shape
		{
			get
			{
				return shape;
			}
			set
			{
				if (shape != value)
				{
					shape = value;
					SetUIAngle(angle);
				}
			}
		}

		public int VerticalAngle
		{
			get
			{
				return vertAngle;
			}
			set
			{
				if (vertAngle != value)
				{
					vertAngle = value;
					SetUIAngle(angle);
				}
			}
		}

		public float RingFill
		{
			get
			{
				return ringFill;
			}
			set
			{
				if (ringFill != value)
				{
					ringFill = value;
					SetUIAngle(angle);
				}
			}
		}

		public float SavedRadius
		{
			get
			{
				if (savedRadius == 0f)
				{
					savedRadius = GetCyllinderRadiusInCanvasSpace();
				}
				return savedRadius;
			}
		}

		public int RingExternalDiameter
		{
			get
			{
				return ringExternalDiamater;
			}
			set
			{
				if (ringExternalDiamater != value)
				{
					ringExternalDiamater = value;
					SetUIAngle(angle);
				}
			}
		}

		public bool RingFlipVertical
		{
			get
			{
				return ringFlipVertical;
			}
			set
			{
				if (ringFlipVertical != value)
				{
					ringFlipVertical = value;
					SetUIAngle(angle);
				}
			}
		}

		public bool PreserveAspect
		{
			get
			{
				return preserveAspect;
			}
			set
			{
				if (preserveAspect != value)
				{
					preserveAspect = value;
					SetUIAngle(angle);
				}
			}
		}

		public bool Interactable
		{
			get
			{
				return interactable;
			}
			set
			{
				interactable = value;
			}
		}

		public bool ForceUseBoxCollider
		{
			get
			{
				return forceUseBoxCollider;
			}
			set
			{
				forceUseBoxCollider = value;
			}
		}

		public bool BlocksRaycasts
		{
			get
			{
				return blocksRaycasts;
			}
			set
			{
				if (blocksRaycasts != value)
				{
					blocksRaycasts = value;
					if (Application.isPlaying && GetComponent<CurvedUIRaycaster>() != null)
					{
						GetComponent<CurvedUIRaycaster>().RebuildCollider();
					}
				}
			}
		}

		public bool RaycastMyLayerOnly
		{
			get
			{
				return raycastMyLayerOnly;
			}
			set
			{
				raycastMyLayerOnly = value;
			}
		}

		public CurvedUIInputModule.CUIControlMethod ControlMethod
		{
			get
			{
				return CurvedUIInputModule.ControlMethod;
			}
			set
			{
				CurvedUIInputModule.ControlMethod = value;
			}
		}

		public bool GazeUseTimedClick
		{
			get
			{
				return CurvedUIInputModule.Instance.GazeUseTimedClick;
			}
			set
			{
				CurvedUIInputModule.Instance.GazeUseTimedClick = value;
			}
		}

		public float GazeClickTimer
		{
			get
			{
				return CurvedUIInputModule.Instance.GazeClickTimer;
			}
			set
			{
				CurvedUIInputModule.Instance.GazeClickTimer = value;
			}
		}

		public float GazeClickTimerDelay
		{
			get
			{
				return CurvedUIInputModule.Instance.GazeClickTimerDelay;
			}
			set
			{
				CurvedUIInputModule.Instance.GazeClickTimerDelay = value;
			}
		}

		public float GazeTimerProgress
		{
			get
			{
				return CurvedUIInputModule.Instance.GazeTimerProgress;
			}
		}

		private void Awake()
		{
			if (RaycastMyLayerOnly && base.gameObject.layer == 0)
			{
				base.gameObject.layer = 5;
			}
			savedRectSize = RectTransform.rect.size;
		}

		private void Start()
		{
			if (myCanvas == null)
			{
				myCanvas = GetComponent<Canvas>();
			}
			savedRadius = GetCyllinderRadiusInCanvasSpace();
		}

		private void OnEnable()
		{
			SetAllDirty();
		}

		private void OnDisable()
		{
			SetAllDirty();
		}

		public void SetAllDirty()
		{
			Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>();
			foreach (Graphic graphic in componentsInChildren)
			{
				graphic.SetAllDirty();
			}
		}

		private void Update()
		{
			if (RectTransform.rect.size != savedRectSize)
			{
				savedRectSize = RectTransform.rect.size;
				SetUIAngle(angle);
			}
			if (savedRectSize.x == 0f || savedRectSize.y == 0f)
			{
				Debug.LogError("CurvedUI: Your Canvas size must be bigger than 0!");
			}
		}

		private void SetUIAngle(int newAngle)
		{
			if (myCanvas == null)
			{
				myCanvas = GetComponent<Canvas>();
			}
			if (newAngle == 0)
			{
				newAngle = 1;
			}
			angle = newAngle;
			savedRadius = GetCyllinderRadiusInCanvasSpace();
			CurvedUIVertexEffect[] componentsInChildren = GetComponentsInChildren<CurvedUIVertexEffect>();
			foreach (CurvedUIVertexEffect curvedUIVertexEffect in componentsInChildren)
			{
				curvedUIVertexEffect.TesselationRequired = true;
			}
			Graphic[] componentsInChildren2 = GetComponentsInChildren<Graphic>();
			foreach (Graphic graphic in componentsInChildren2)
			{
				graphic.SetVerticesDirty();
			}
			if (Application.isPlaying && GetComponent<CurvedUIRaycaster>() != null)
			{
				GetComponent<CurvedUIRaycaster>().RebuildCollider();
			}
		}

		private Vector3 CanvasToCyllinder(Vector3 pos)
		{
			float f = pos.x / savedRectSize.x * (float)Angle * ((float)Math.PI / 180f);
			pos.x = Mathf.Sin(f) * (SavedRadius + pos.z);
			pos.z += Mathf.Cos(f) * (SavedRadius + pos.z) - (SavedRadius + pos.z);
			return pos;
		}

		private Vector3 CanvasToCyllinderVertical(Vector3 pos)
		{
			float f = pos.y / savedRectSize.y * (float)Angle * ((float)Math.PI / 180f);
			pos.y = Mathf.Sin(f) * (SavedRadius + pos.z);
			pos.z += Mathf.Cos(f) * (SavedRadius + pos.z) - (SavedRadius + pos.z);
			return pos;
		}

		private Vector3 CanvasToRing(Vector3 pos)
		{
			float num = pos.y.Remap(savedRectSize.y * 0.5f * (float)(RingFlipVertical ? 1 : (-1)), (0f - savedRectSize.y) * 0.5f * (float)(RingFlipVertical ? 1 : (-1)), (float)RingExternalDiameter * (1f - RingFill) * 0.5f, (float)RingExternalDiameter * 0.5f);
			float f = (pos.x / savedRectSize.x).Remap(-0.5f, 0.5f, (float)Math.PI / 2f, (float)angle * ((float)Math.PI / 180f) + (float)Math.PI / 2f);
			pos.x = num * Mathf.Cos(f);
			pos.y = num * Mathf.Sin(f);
			return pos;
		}

		private Vector3 CanvasToSphere(Vector3 pos)
		{
			float num = SavedRadius;
			float num2 = VerticalAngle;
			if (PreserveAspect)
			{
				num2 = (float)angle * (savedRectSize.y / savedRectSize.x);
				num += ((Angle <= 0) ? pos.z : (0f - pos.z));
			}
			else
			{
				num = savedRectSize.x / 2f + pos.z;
				if (num2 == 0f)
				{
					return Vector3.zero;
				}
			}
			float num3 = (pos.x / savedRectSize.x).Remap(-0.5f, 0.5f, (float)(180 - angle) / 2f - 90f, 180f - (float)(180 - angle) / 2f - 90f);
			num3 *= (float)Math.PI / 180f;
			float num4 = (pos.y / savedRectSize.y).Remap(-0.5f, 0.5f, (180f - num2) / 2f, 180f - (180f - num2) / 2f);
			num4 *= (float)Math.PI / 180f;
			pos.z = Mathf.Sin(num4) * Mathf.Cos(num3) * num;
			pos.y = (0f - num) * Mathf.Cos(num4);
			pos.x = Mathf.Sin(num4) * Mathf.Sin(num3) * num;
			if (PreserveAspect)
			{
				pos.z -= num;
			}
			return pos;
		}

		public void AddEffectToChildren()
		{
			Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>(true);
			foreach (Graphic graphic in componentsInChildren)
			{
				if (graphic.GetComponent<CurvedUIVertexEffect>() == null)
				{
					graphic.gameObject.AddComponent<CurvedUIVertexEffect>();
					graphic.SetAllDirty();
				}
			}
			InputField[] componentsInChildren2 = GetComponentsInChildren<InputField>(true);
			foreach (InputField inputField in componentsInChildren2)
			{
				if (inputField.GetComponent<CurvedUIInputFieldCaret>() == null)
				{
					inputField.gameObject.AddComponent<CurvedUIInputFieldCaret>();
				}
			}
			TextMeshProUGUI[] componentsInChildren3 = GetComponentsInChildren<TextMeshProUGUI>(true);
			foreach (TextMeshProUGUI textMeshProUGUI in componentsInChildren3)
			{
				if (textMeshProUGUI.GetComponent<CurvedUITMP>() == null)
				{
					textMeshProUGUI.gameObject.AddComponent<CurvedUITMP>();
					textMeshProUGUI.SetAllDirty();
				}
			}
		}

		public Vector3 VertexPositionToCurvedCanvas(Vector3 pos)
		{
			switch (Shape)
			{
			case CurvedUIShape.CYLINDER:
				return CanvasToCyllinder(pos);
			case CurvedUIShape.CYLINDER_VERTICAL:
				return CanvasToCyllinderVertical(pos);
			case CurvedUIShape.RING:
				return CanvasToRing(pos);
			case CurvedUIShape.SPHERE:
				return CanvasToSphere(pos);
			default:
				return Vector3.zero;
			}
		}

		public Vector3 CanvasToCurvedCanvas(Vector3 pos)
		{
			pos = VertexPositionToCurvedCanvas(pos);
			if (float.IsNaN(pos.x) || float.IsInfinity(pos.x))
			{
				return Vector3.zero;
			}
			return base.transform.localToWorldMatrix.MultiplyPoint3x4(pos);
		}

		public Vector3 CanvasToCurvedCanvasNormal(Vector3 pos)
		{
			pos = VertexPositionToCurvedCanvas(pos);
			switch (Shape)
			{
			case CurvedUIShape.CYLINDER:
				return base.transform.localToWorldMatrix.MultiplyVector((pos - new Vector3(0f, 0f, 0f - GetCyllinderRadiusInCanvasSpace())).ModifyY(0f)).normalized;
			case CurvedUIShape.CYLINDER_VERTICAL:
				return base.transform.localToWorldMatrix.MultiplyVector((pos - new Vector3(0f, 0f, 0f - GetCyllinderRadiusInCanvasSpace())).ModifyX(0f)).normalized;
			case CurvedUIShape.RING:
				return -base.transform.forward;
			case CurvedUIShape.SPHERE:
			{
				Vector3 vector = ((!PreserveAspect) ? Vector3.zero : new Vector3(0f, 0f, 0f - GetCyllinderRadiusInCanvasSpace()));
				return base.transform.localToWorldMatrix.MultiplyVector(pos - vector).normalized;
			}
			default:
				return Vector3.zero;
			}
		}

		public bool RaycastToCanvasSpace(Ray ray, out Vector2 o_positionOnCanvas)
		{
			CurvedUIRaycaster component = GetComponent<CurvedUIRaycaster>();
			o_positionOnCanvas = Vector2.zero;
			switch (Shape)
			{
			case CurvedUIShape.CYLINDER:
				return component.RaycastToCyllinderCanvas(ray, out o_positionOnCanvas, true);
			case CurvedUIShape.CYLINDER_VERTICAL:
				return component.RaycastToCyllinderVerticalCanvas(ray, out o_positionOnCanvas, true);
			case CurvedUIShape.RING:
				return component.RaycastToRingCanvas(ray, out o_positionOnCanvas, true);
			case CurvedUIShape.SPHERE:
				return component.RaycastToSphereCanvas(ray, out o_positionOnCanvas, true);
			default:
				return false;
			}
		}

		public float GetCyllinderRadiusInCanvasSpace()
		{
			float num = ((!PreserveAspect) ? (RectTransform.rect.size.x * 0.5f / Mathf.Sin(Mathf.Clamp(angle, -180f, 180f) * 0.5f * ((float)Math.PI / 180f))) : ((shape != CurvedUIShape.CYLINDER_VERTICAL) ? (RectTransform.rect.size.x / ((float)Math.PI * 2f * ((float)angle / 360f))) : (RectTransform.rect.size.y / ((float)Math.PI * 2f * ((float)angle / 360f)))));
			return (angle != 0) ? num : 0f;
		}

		public Vector2 GetTesslationSize(bool UnmodifiedByQuality = false)
		{
			Vector2 size = RectTransform.rect.size;
			float num = size.x;
			float y = size.y;
			if (Angle != 0 || (!PreserveAspect && vertAngle != 0))
			{
				switch (shape)
				{
				case CurvedUIShape.CYLINDER:
				case CurvedUIShape.RING:
				case CurvedUIShape.CYLINDER_VERTICAL:
					num = Mathf.Min(size.x / 4f, size.x / (Mathf.Abs(angle).Remap(0f, 360f, 0f, 1f) * (float)baseCircleSegments));
					y = Mathf.Min(size.y / 4f, size.y / (Mathf.Abs(angle).Remap(0f, 360f, 0f, 1f) * (float)baseCircleSegments));
					break;
				case CurvedUIShape.SPHERE:
					num = Mathf.Min(size.x / 4f, size.x / (Mathf.Abs(angle).Remap(0f, 360f, 0f, 1f) * (float)baseCircleSegments * 0.5f));
					y = ((!PreserveAspect) ? ((VerticalAngle != 0) ? (size.y / (Mathf.Abs(VerticalAngle).Remap(0f, 180f, 0f, 1f) * (float)baseCircleSegments * 0.5f)) : 10000f) : (num * size.y / size.x));
					break;
				}
			}
			return new Vector2(num, y) / ((!UnmodifiedByQuality) ? Mathf.Clamp(Quality, 0.01f, 10f) : 1f);
		}

		public void SetAllChildrenDirty(bool recalculateCurveOnly = false)
		{
			CurvedUIVertexEffect[] componentsInChildren = GetComponentsInChildren<CurvedUIVertexEffect>();
			foreach (CurvedUIVertexEffect curvedUIVertexEffect in componentsInChildren)
			{
				if (recalculateCurveOnly)
				{
					curvedUIVertexEffect.SetDirty();
				}
				else
				{
					curvedUIVertexEffect.CurvingRequired = true;
				}
			}
		}

		public void Click()
		{
			if (GetComponent<CurvedUIRaycaster>() != null)
			{
				GetComponent<CurvedUIRaycaster>().Click();
			}
		}

		public List<GameObject> GetObjectsUnderPointer()
		{
			if (GetComponent<CurvedUIRaycaster>() != null)
			{
				return GetComponent<CurvedUIRaycaster>().GetObjectsUnderPointer();
			}
			return new List<GameObject>();
		}

		public List<GameObject> GetObjectsUnderScreenPos(Vector2 pos, Camera eventCamera = null)
		{
			if (eventCamera == null)
			{
				eventCamera = myCanvas.worldCamera;
			}
			if (GetComponent<CurvedUIRaycaster>() != null)
			{
				return GetComponent<CurvedUIRaycaster>().GetObjectsUnderScreenPos(pos, eventCamera);
			}
			return new List<GameObject>();
		}

		public List<GameObject> GetObjectsHitByRay(Ray ray)
		{
			if (GetComponent<CurvedUIRaycaster>() != null)
			{
				return GetComponent<CurvedUIRaycaster>().GetObjectsHitByRay(ray);
			}
			return new List<GameObject>();
		}
	}
}
