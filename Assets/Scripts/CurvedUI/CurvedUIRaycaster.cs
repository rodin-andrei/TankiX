using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CurvedUIRaycaster : GraphicRaycaster
	{
		[SerializeField]
		private bool showDebug;

		private bool overrideEventData = true;

		private Canvas myCanvas;

		private CurvedUISettings mySettings;

		private Vector3 cyllinderMidPoint;

		private List<GameObject> objectsUnderPointer = new List<GameObject>();

		private Vector2 lastCanvasPos = Vector2.zero;

		private GameObject colliderContainer;

		private List<GameObject> selectablesUnderGaze = new List<GameObject>();

		private List<GameObject> selectablesUnderGazeLastFrame = new List<GameObject>();

		private float objectsUnderGazeLastChangeTime;

		private bool gazeClickExecuted;

		private bool pointingAtCanvas;

		protected override void Awake()
		{
			base.Awake();
			myCanvas = GetComponent<Canvas>();
			mySettings = GetComponent<CurvedUISettings>();
			cyllinderMidPoint = new Vector3(0f, 0f, 0f - mySettings.GetCyllinderRadiusInCanvasSpace());
			if (myCanvas.worldCamera == null && Camera.main != null)
			{
				myCanvas.worldCamera = Camera.main;
			}
		}

		protected override void Start()
		{
			CreateCollider();
		}

		protected virtual void Update()
		{
			if (pointingAtCanvas && CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE && CurvedUIInputModule.Instance.GazeUseTimedClick)
			{
				ProcessGazeTimedClick();
				selectablesUnderGazeLastFrame.Clear();
				selectablesUnderGazeLastFrame.AddRange(selectablesUnderGaze);
				selectablesUnderGaze.Clear();
				selectablesUnderGaze.AddRange(objectsUnderPointer);
				selectablesUnderGaze.RemoveAll((GameObject obj) => obj.GetComponent<Selectable>() == null);
				if (CurvedUIInputModule.Instance.GazeTimedClickProgressImage != null)
				{
					if (CurvedUIInputModule.Instance.GazeTimedClickProgressImage.type != Image.Type.Filled)
					{
						CurvedUIInputModule.Instance.GazeTimedClickProgressImage.type = Image.Type.Filled;
					}
					CurvedUIInputModule.Instance.GazeTimedClickProgressImage.fillAmount = (Time.time - objectsUnderGazeLastChangeTime).RemapAndClamp(CurvedUIInputModule.Instance.GazeClickTimerDelay, CurvedUIInputModule.Instance.GazeClickTimer + CurvedUIInputModule.Instance.GazeClickTimerDelay, 0f, 1f);
				}
			}
			pointingAtCanvas = false;
		}

		private void ProcessGazeTimedClick()
		{
			if (selectablesUnderGazeLastFrame.Count == 0 || selectablesUnderGazeLastFrame.Count != selectablesUnderGaze.Count)
			{
				ResetGazeTimedClick();
				return;
			}
			for (int i = 0; i < selectablesUnderGazeLastFrame.Count && i < selectablesUnderGaze.Count; i++)
			{
				if (selectablesUnderGazeLastFrame[i].GetInstanceID() != selectablesUnderGaze[i].GetInstanceID())
				{
					ResetGazeTimedClick();
					return;
				}
			}
			if (!gazeClickExecuted && Time.time > objectsUnderGazeLastChangeTime + CurvedUIInputModule.Instance.GazeClickTimer + CurvedUIInputModule.Instance.GazeClickTimerDelay)
			{
				Click();
				gazeClickExecuted = true;
			}
		}

		private void ResetGazeTimedClick()
		{
			objectsUnderGazeLastChangeTime = Time.time;
			gazeClickExecuted = false;
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (!mySettings.Interactable)
			{
				return;
			}
			if (myCanvas.worldCamera == null)
			{
				Debug.LogWarning("CurvedUIRaycaster requires Canvas to have a world camera reference to process events!", myCanvas.gameObject);
			}
			Camera worldCamera = myCanvas.worldCamera;
			Ray ray3D;
			switch (CurvedUIInputModule.ControlMethod)
			{
			case CurvedUIInputModule.CUIControlMethod.MOUSE:
				ray3D = worldCamera.ScreenPointToRay(eventData.position);
				break;
			case CurvedUIInputModule.CUIControlMethod.GAZE:
				ray3D = new Ray(worldCamera.transform.position, worldCamera.transform.forward);
				UpdateSelectedObjects(eventData);
				break;
			case CurvedUIInputModule.CUIControlMethod.WORLD_MOUSE:
				ray3D = new Ray(worldCamera.transform.position, mySettings.CanvasToCurvedCanvas(CurvedUIInputModule.Instance.WorldSpaceMouseInCanvasSpace) - myCanvas.worldCamera.transform.position);
				break;
			case CurvedUIInputModule.CUIControlMethod.CUSTOM_RAY:
			case CurvedUIInputModule.CUIControlMethod.VIVE:
			case CurvedUIInputModule.CUIControlMethod.OCULUS_TOUCH:
				ray3D = CurvedUIInputModule.CustomControllerRay;
				UpdateSelectedObjects(eventData);
				break;
			case CurvedUIInputModule.CUIControlMethod.GOOGLEVR:
				Debug.LogError("CURVEDUI: Missing GoogleVR support code. Enable GoogleVR control method on CurvedUISettings component.");
				goto case CurvedUIInputModule.CUIControlMethod.GAZE;
			default:
				ray3D = default(Ray);
				break;
			}
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			if (!overrideEventData)
			{
				pointerEventData.pointerEnter = eventData.pointerEnter;
				pointerEventData.rawPointerPress = eventData.rawPointerPress;
				pointerEventData.pointerDrag = eventData.pointerDrag;
				pointerEventData.pointerCurrentRaycast = eventData.pointerCurrentRaycast;
				pointerEventData.pointerPressRaycast = eventData.pointerPressRaycast;
				pointerEventData.hovered = new List<GameObject>();
				pointerEventData.hovered.AddRange(eventData.hovered);
				pointerEventData.eligibleForClick = eventData.eligibleForClick;
				pointerEventData.pointerId = eventData.pointerId;
				pointerEventData.position = eventData.position;
				pointerEventData.delta = eventData.delta;
				pointerEventData.pressPosition = eventData.pressPosition;
				pointerEventData.clickTime = eventData.clickTime;
				pointerEventData.clickCount = eventData.clickCount;
				pointerEventData.scrollDelta = eventData.scrollDelta;
				pointerEventData.useDragThreshold = eventData.useDragThreshold;
				pointerEventData.dragging = eventData.dragging;
				pointerEventData.button = eventData.button;
			}
			if (mySettings.Angle != 0 && mySettings.enabled)
			{
				Vector2 o_canvasPos = eventData.position;
				switch (mySettings.Shape)
				{
				case CurvedUISettings.CurvedUIShape.CYLINDER:
					if (!RaycastToCyllinderCanvas(ray3D, out o_canvasPos))
					{
						return;
					}
					break;
				case CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL:
					if (!RaycastToCyllinderVerticalCanvas(ray3D, out o_canvasPos))
					{
						return;
					}
					break;
				case CurvedUISettings.CurvedUIShape.RING:
					if (!RaycastToRingCanvas(ray3D, out o_canvasPos))
					{
						return;
					}
					break;
				case CurvedUISettings.CurvedUIShape.SPHERE:
					if (!RaycastToSphereCanvas(ray3D, out o_canvasPos))
					{
						return;
					}
					break;
				}
				pointingAtCanvas = true;
				PointerEventData pointerEventData2 = ((!overrideEventData) ? pointerEventData : eventData);
				if (pointerEventData2.pressPosition == pointerEventData2.position)
				{
					pointerEventData2.pressPosition = o_canvasPos;
				}
				pointerEventData2.position = o_canvasPos;
				if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.VIVE)
				{
					pointerEventData2.delta = o_canvasPos - lastCanvasPos;
					lastCanvasPos = o_canvasPos;
				}
			}
			objectsUnderPointer = eventData.hovered;
			base.Raycast((!overrideEventData) ? pointerEventData : eventData, resultAppendList);
		}

		private LayerMask GetLayerMaskForMyLayer()
		{
			int num = -1;
			if (mySettings.RaycastMyLayerOnly)
			{
				num = 1 << base.gameObject.layer;
			}
			return num;
		}

		public virtual bool RaycastToCyllinderCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			if (showDebug)
			{
				Debug.DrawLine(ray3D.origin, ray3D.GetPoint(1000f), Color.red);
			}
			LayerMask layerMaskForMyLayer = GetLayerMaskForMyLayer();
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, layerMaskForMyLayer))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector3 vector = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 normalized = (vector - cyllinderMidPoint).normalized;
				float value = 0f - AngleSigned(normalized.ModifyY(0f), (mySettings.Angle >= 0) ? Vector3.forward : Vector3.back, Vector3.up);
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				Vector2 vector2 = new Vector3(0f, 0f, 0f);
				vector2.x = value.Remap((float)(-mySettings.Angle) / 2f, (float)mySettings.Angle / 2f, (0f - size.x) / 2f, size.x / 2f);
				vector2.y = vector.y;
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector2;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2));
				}
				if (showDebug)
				{
					Debug.DrawLine(hitInfo.point, hitInfo.point.ModifyY(hitInfo.point.y + 10f), Color.green);
					Debug.DrawLine(hitInfo.point, myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(cyllinderMidPoint), Color.yellow);
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		public virtual bool RaycastToCyllinderVerticalCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			if (showDebug)
			{
				Debug.DrawLine(ray3D.origin, ray3D.GetPoint(1000f), Color.red);
			}
			LayerMask layerMaskForMyLayer = GetLayerMaskForMyLayer();
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, layerMaskForMyLayer))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector3 vector = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 normalized = (vector - cyllinderMidPoint).normalized;
				float value = 0f - AngleSigned(normalized.ModifyX(0f), (mySettings.Angle >= 0) ? Vector3.forward : Vector3.back, Vector3.left);
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				Vector2 vector2 = new Vector3(0f, 0f, 0f);
				vector2.y = value.Remap((float)(-mySettings.Angle) / 2f, (float)mySettings.Angle / 2f, (0f - size.y) / 2f, size.y / 2f);
				vector2.x = vector.x;
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector2;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2));
				}
				if (showDebug)
				{
					Debug.DrawLine(hitInfo.point, hitInfo.point.ModifyY(hitInfo.point.y + 10f), Color.green);
					Debug.DrawLine(hitInfo.point, myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(cyllinderMidPoint), Color.yellow);
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		public virtual bool RaycastToRingCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			LayerMask layerMaskForMyLayer = GetLayerMaskForMyLayer();
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, layerMaskForMyLayer))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector3 trans = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 normalized = trans.ModifyZ(0f).normalized;
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				float num = 0f - AngleSigned(normalized.ModifyZ(0f), Vector3.up, Vector3.back);
				Vector2 vector = new Vector2(0f, 0f);
				if (showDebug)
				{
					Debug.Log("angle: " + num);
				}
				if (num < 0f)
				{
					vector.x = num.Remap(0f, -mySettings.Angle, (0f - size.x) / 2f, size.x / 2f);
				}
				else
				{
					vector.x = num.Remap(360f, 360 - mySettings.Angle, (0f - size.x) / 2f, size.x / 2f);
				}
				vector.y = trans.magnitude.Remap((float)mySettings.RingExternalDiameter * 0.5f * (1f - mySettings.RingFill), (float)mySettings.RingExternalDiameter * 0.5f, (0f - size.y) * 0.5f * (float)((!mySettings.RingFlipVertical) ? 1 : (-1)), size.y * 0.5f * (float)((!mySettings.RingFlipVertical) ? 1 : (-1)));
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector));
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		public virtual bool RaycastToSphereCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			LayerMask layerMaskForMyLayer = GetLayerMaskForMyLayer();
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, layerMaskForMyLayer))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				float num = ((!mySettings.PreserveAspect) ? (size.x / 2f) : mySettings.GetCyllinderRadiusInCanvasSpace());
				Vector3 vector = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 vector2 = new Vector3(0f, 0f, (!mySettings.PreserveAspect) ? 0f : (0f - num));
				Vector3 normalized = (vector - vector2).normalized;
				Vector3 vector3 = Vector3.Cross(normalized, normalized.ModifyY(0f)).normalized * ((normalized.y < 0f) ? 1 : (-1));
				float num2 = 0f - AngleSigned(normalized.ModifyY(0f), (mySettings.Angle <= 0) ? Vector3.back : Vector3.forward, (mySettings.Angle <= 0) ? Vector3.down : Vector3.up);
				float num3 = 0f - AngleSigned(normalized, normalized.ModifyY(0f), vector3);
				float num4 = (float)Mathf.Abs(mySettings.Angle) * 0.5f;
				float num5 = Mathf.Abs((!mySettings.PreserveAspect) ? ((float)mySettings.VerticalAngle * 0.5f) : (num4 * size.y / size.x));
				Vector2 vector4 = new Vector2(num2.Remap(0f - num4, num4, (0f - size.x) * 0.5f, size.x * 0.5f), num3.Remap(0f - num5, num5, (0f - size.y) * 0.5f, size.y * 0.5f));
				if (showDebug)
				{
					Debug.Log("h: " + num2 + " / v: " + num3 + " poc: " + vector4);
					Debug.DrawRay(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2), myCanvas.transform.localToWorldMatrix.MultiplyVector(normalized) * Mathf.Abs(num), Color.red);
					Debug.DrawRay(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2), myCanvas.transform.localToWorldMatrix.MultiplyVector(vector3) * 300f, Color.magenta);
				}
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector4;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector4));
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		protected void CreateCollider()
		{
			List<Collider> list = new List<Collider>();
			list.AddRange(GetComponents<Collider>());
			for (int i = 0; i < list.Count; i++)
			{
				UnityEngine.Object.Destroy(list[i]);
			}
			if (!mySettings.BlocksRaycasts || (mySettings.Shape == CurvedUISettings.CurvedUIShape.SPHERE && !mySettings.PreserveAspect && mySettings.VerticalAngle == 0))
			{
				return;
			}
			switch (mySettings.Shape)
			{
			case CurvedUISettings.CurvedUIShape.CYLINDER:
				if (mySettings.ForceUseBoxCollider || GetComponent<Rigidbody>() != null || GetComponentInParent<Rigidbody>() != null)
				{
					if (colliderContainer != null)
					{
						UnityEngine.Object.Destroy(colliderContainer);
					}
					colliderContainer = CreateConvexCyllinderCollider();
				}
				else
				{
					SetupMeshColliderUsingMesh(CreateCyllinderColliderMesh());
				}
				break;
			case CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL:
				if (mySettings.ForceUseBoxCollider || GetComponent<Rigidbody>() != null || GetComponentInParent<Rigidbody>() != null)
				{
					if (colliderContainer != null)
					{
						UnityEngine.Object.Destroy(colliderContainer);
					}
					colliderContainer = CreateConvexCyllinderCollider(true);
				}
				else
				{
					SetupMeshColliderUsingMesh(CreateCyllinderColliderMesh(true));
				}
				break;
			case CurvedUISettings.CurvedUIShape.RING:
			{
				BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
				boxCollider.size = new Vector3(mySettings.RingExternalDiameter, mySettings.RingExternalDiameter, 1f);
				break;
			}
			case CurvedUISettings.CurvedUIShape.SPHERE:
				if (GetComponent<Rigidbody>() != null || GetComponentInParent<Rigidbody>() != null)
				{
					Debug.LogWarning("CurvedUI: Sphere shape canvases as children of rigidbodies do not support user input. Switch to Cyllinder shape or remove the rigidbody from parent.", base.gameObject);
				}
				SetupMeshColliderUsingMesh(CreateSphereColliderMesh());
				break;
			}
		}

		private void SetupMeshColliderUsingMesh(Mesh meshie)
		{
			MeshFilter meshFilter = this.AddComponentIfMissing<MeshFilter>();
			MeshCollider meshCollider = base.gameObject.AddComponent<MeshCollider>();
			meshFilter.mesh = meshie;
			meshCollider.sharedMesh = meshie;
		}

		private GameObject CreateConvexCyllinderCollider(bool vertical = false)
		{
			GameObject gameObject = new GameObject("_CurvedUIColliders");
			gameObject.layer = base.gameObject.layer;
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.ResetTransform();
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[4];
			(myCanvas.transform as RectTransform).GetWorldCorners(array);
			mesh.vertices = array;
			if (vertical)
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			else
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			mesh.vertices = array;
			List<Vector3> list = new List<Vector3>();
			int num = Mathf.Max(8, Mathf.RoundToInt((float)(mySettings.BaseCircleSegments * Mathf.Abs(mySettings.Angle)) / 360f));
			for (int i = 0; i < num; i++)
			{
				list.Add(Vector3.Lerp(mesh.vertices[0], mesh.vertices[2], (float)i * 1f / (float)(num - 1)));
			}
			if (mySettings.Angle != 0)
			{
				Rect rect = myCanvas.GetComponent<RectTransform>().rect;
				float cyllinderRadiusInCanvasSpace = mySettings.GetCyllinderRadiusInCanvasSpace();
				for (int j = 0; j < list.Count; j++)
				{
					Vector3 value = list[j];
					if (vertical)
					{
						float f = list[j].y / rect.size.y * (float)mySettings.Angle * ((float)Math.PI / 180f);
						value.y = Mathf.Sin(f) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
					else
					{
						float f2 = list[j].x / rect.size.x * (float)mySettings.Angle * ((float)Math.PI / 180f);
						value.x = Mathf.Sin(f2) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f2) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
				}
			}
			for (int k = 0; k < list.Count - 1; k++)
			{
				GameObject gameObject2 = new GameObject("Box collider");
				gameObject2.layer = base.gameObject.layer;
				gameObject2.transform.SetParent(gameObject.transform);
				gameObject2.transform.ResetTransform();
				gameObject2.AddComponent<BoxCollider>();
				if (vertical)
				{
					gameObject2.transform.localPosition = new Vector3(0f, (list[k + 1].y + list[k].y) * 0.5f, (list[k + 1].z + list[k].z) * 0.5f);
					gameObject2.transform.localScale = new Vector3(0.1f, Vector3.Distance(array[0], array[1]), Vector3.Distance(list[k + 1], list[k]));
					gameObject2.transform.localRotation = Quaternion.LookRotation(list[k + 1] - list[k], array[0] - array[1]);
				}
				else
				{
					gameObject2.transform.localPosition = new Vector3((list[k + 1].x + list[k].x) * 0.5f, 0f, (list[k + 1].z + list[k].z) * 0.5f);
					gameObject2.transform.localScale = new Vector3(0.1f, Vector3.Distance(array[0], array[1]), Vector3.Distance(list[k + 1], list[k]));
					gameObject2.transform.localRotation = Quaternion.LookRotation(list[k + 1] - list[k], array[0] - array[1]);
				}
			}
			return gameObject;
		}

		private Mesh CreateCyllinderColliderMesh(bool vertical = false)
		{
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[4];
			(myCanvas.transform as RectTransform).GetWorldCorners(array);
			mesh.vertices = array;
			if (vertical)
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			else
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			mesh.vertices = array;
			List<Vector3> list = new List<Vector3>();
			int num = Mathf.Max(8, Mathf.RoundToInt((float)(mySettings.BaseCircleSegments * Mathf.Abs(mySettings.Angle)) / 360f));
			for (int i = 0; i < num; i++)
			{
				list.Add(Vector3.Lerp(mesh.vertices[0], mesh.vertices[2], (float)i * 1f / (float)(num - 1)));
				list.Add(Vector3.Lerp(mesh.vertices[1], mesh.vertices[3], (float)i * 1f / (float)(num - 1)));
			}
			if (mySettings.Angle != 0)
			{
				Rect rect = myCanvas.GetComponent<RectTransform>().rect;
				float cyllinderRadiusInCanvasSpace = GetComponent<CurvedUISettings>().GetCyllinderRadiusInCanvasSpace();
				for (int j = 0; j < list.Count; j++)
				{
					Vector3 value = list[j];
					if (vertical)
					{
						float f = list[j].y / rect.size.y * (float)mySettings.Angle * ((float)Math.PI / 180f);
						value.y = Mathf.Sin(f) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
					else
					{
						float f2 = list[j].x / rect.size.x * (float)mySettings.Angle * ((float)Math.PI / 180f);
						value.x = Mathf.Sin(f2) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f2) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
				}
			}
			mesh.vertices = list.ToArray();
			List<int> list2 = new List<int>();
			for (int k = 0; k < list.Count / 2 - 1; k++)
			{
				if (vertical)
				{
					list2.Add(k * 2);
					list2.Add(k * 2 + 1);
					list2.Add(k * 2 + 2);
					list2.Add(k * 2 + 1);
					list2.Add(k * 2 + 3);
					list2.Add(k * 2 + 2);
				}
				else
				{
					list2.Add(k * 2 + 2);
					list2.Add(k * 2 + 1);
					list2.Add(k * 2);
					list2.Add(k * 2 + 2);
					list2.Add(k * 2 + 3);
					list2.Add(k * 2 + 1);
				}
			}
			mesh.triangles = list2.ToArray();
			return mesh;
		}

		private Mesh CreateSphereColliderMesh()
		{
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[4];
			(myCanvas.transform as RectTransform).GetWorldCorners(array);
			List<Vector3> list = new List<Vector3>(array);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(list[i]);
			}
			if (mySettings.Angle != 0)
			{
				int count = list.Count;
				for (int j = 0; j < count; j += 4)
				{
					ModifyQuad(list, j, mySettings.GetTesslationSize(true));
				}
				list.RemoveRange(0, count);
				float num = mySettings.VerticalAngle;
				float num2 = mySettings.Angle;
				Vector2 size = (myCanvas.transform as RectTransform).rect.size;
				float num3 = mySettings.GetCyllinderRadiusInCanvasSpace();
				if (mySettings.PreserveAspect)
				{
					num = (float)mySettings.Angle * (size.y / size.x);
				}
				else
				{
					num3 = size.x / 2f;
				}
				for (int k = 0; k < list.Count; k++)
				{
					float num4 = (list[k].x / size.x).Remap(-0.5f, 0.5f, (180f - num2) / 2f - 90f, 180f - (180f - num2) / 2f - 90f);
					num4 *= (float)Math.PI / 180f;
					float num5 = (list[k].y / size.y).Remap(-0.5f, 0.5f, (180f - num) / 2f, 180f - (180f - num) / 2f);
					num5 *= (float)Math.PI / 180f;
					list[k] = new Vector3(Mathf.Sin(num5) * Mathf.Sin(num4) * num3, (0f - num3) * Mathf.Cos(num5), Mathf.Sin(num5) * Mathf.Cos(num4) * num3 + ((!mySettings.PreserveAspect) ? 0f : (0f - num3)));
				}
			}
			mesh.vertices = list.ToArray();
			List<int> list2 = new List<int>();
			for (int l = 0; l < list.Count; l += 4)
			{
				list2.Add(l);
				list2.Add(l + 1);
				list2.Add(l + 2);
				list2.Add(l + 3);
				list2.Add(l);
				list2.Add(l + 2);
			}
			mesh.triangles = list2.ToArray();
			return mesh;
		}

		private float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
		{
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
		}

		private bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
		{
			if (!useDragThreshold)
			{
				return true;
			}
			return (pressPos - currentPos).sqrMagnitude >= threshold * threshold;
		}

		protected virtual void ProcessMove(PointerEventData pointerEvent)
		{
			GameObject gameObject = pointerEvent.pointerCurrentRaycast.gameObject;
			HandlePointerExitAndEnter(pointerEvent, gameObject);
		}

		protected void UpdateSelectedObjects(PointerEventData eventData)
		{
			bool flag = false;
			foreach (GameObject item in eventData.hovered)
			{
				if (item == eventData.selectedObject)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				eventData.selectedObject = null;
			}
			foreach (GameObject item2 in eventData.hovered)
			{
				if (item2 == null)
				{
					continue;
				}
				Graphic component = item2.GetComponent<Graphic>();
				if (!(item2.GetComponent<Selectable>() != null) || !(component != null) || component.depth == -1 || !component.raycastTarget)
				{
					continue;
				}
				if (eventData.selectedObject != item2)
				{
					eventData.selectedObject = item2;
				}
				break;
			}
			if (mySettings.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE && eventData.IsPointerMoving() && eventData.pointerDrag != null && !eventData.dragging && ShouldStartDrag(eventData.pressPosition, eventData.position, EventSystem.current.pixelDragThreshold, eventData.useDragThreshold))
			{
				ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.beginDragHandler);
				eventData.dragging = true;
			}
		}

		protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget)
		{
			if (newEnterTarget == null || currentPointerData.pointerEnter == null)
			{
				for (int i = 0; i < currentPointerData.hovered.Count; i++)
				{
					ExecuteEvents.Execute(currentPointerData.hovered[i], currentPointerData, ExecuteEvents.pointerExitHandler);
				}
				currentPointerData.hovered.Clear();
				if (newEnterTarget == null)
				{
					currentPointerData.pointerEnter = newEnterTarget;
					return;
				}
			}
			if (currentPointerData.pointerEnter == newEnterTarget && (bool)newEnterTarget)
			{
				return;
			}
			GameObject gameObject = FindCommonRoot(currentPointerData.pointerEnter, newEnterTarget);
			if (currentPointerData.pointerEnter != null)
			{
				Transform transform = currentPointerData.pointerEnter.transform;
				while (transform != null && (!(gameObject != null) || !(gameObject.transform == transform)))
				{
					ExecuteEvents.Execute(transform.gameObject, currentPointerData, ExecuteEvents.pointerExitHandler);
					currentPointerData.hovered.Remove(transform.gameObject);
					transform = transform.parent;
				}
			}
			currentPointerData.pointerEnter = newEnterTarget;
			if (newEnterTarget != null)
			{
				Transform transform2 = newEnterTarget.transform;
				while (transform2 != null && transform2.gameObject != gameObject)
				{
					ExecuteEvents.Execute(transform2.gameObject, currentPointerData, ExecuteEvents.pointerEnterHandler);
					currentPointerData.hovered.Add(transform2.gameObject);
					transform2 = transform2.parent;
				}
			}
		}

		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2)
		{
			if (g1 == null || g2 == null)
			{
				return null;
			}
			Transform transform = g1.transform;
			while (transform != null)
			{
				Transform transform2 = g2.transform;
				while (transform2 != null)
				{
					if (transform == transform2)
					{
						return transform.gameObject;
					}
					transform2 = transform2.parent;
				}
				transform = transform.parent;
			}
			return null;
		}

		private bool GetScreenSpacePointByRay(Ray ray, out Vector2 o_positionOnCanvas)
		{
			switch (mySettings.Shape)
			{
			case CurvedUISettings.CurvedUIShape.CYLINDER:
				return RaycastToCyllinderCanvas(ray, out o_positionOnCanvas);
			case CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL:
				return RaycastToCyllinderVerticalCanvas(ray, out o_positionOnCanvas);
			case CurvedUISettings.CurvedUIShape.RING:
				return RaycastToRingCanvas(ray, out o_positionOnCanvas);
			case CurvedUISettings.CurvedUIShape.SPHERE:
				return RaycastToSphereCanvas(ray, out o_positionOnCanvas);
			default:
				o_positionOnCanvas = Vector2.zero;
				return false;
			}
		}

		public void RebuildCollider()
		{
			cyllinderMidPoint = new Vector3(0f, 0f, 0f - mySettings.GetCyllinderRadiusInCanvasSpace());
			CreateCollider();
		}

		public List<GameObject> GetObjectsUnderPointer()
		{
			if (objectsUnderPointer == null)
			{
				objectsUnderPointer = new List<GameObject>();
			}
			return objectsUnderPointer;
		}

		public List<GameObject> GetObjectsUnderScreenPos(Vector2 screenPos, Camera eventCamera = null)
		{
			if (eventCamera == null)
			{
				eventCamera = myCanvas.worldCamera;
			}
			return GetObjectsHitByRay(eventCamera.ScreenPointToRay(screenPos));
		}

		public List<GameObject> GetObjectsHitByRay(Ray ray)
		{
			List<GameObject> list = new List<GameObject>();
			Vector2 o_positionOnCanvas;
			if (!GetScreenSpacePointByRay(ray, out o_positionOnCanvas))
			{
				return list;
			}
			List<Graphic> list2 = new List<Graphic>();
			IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(myCanvas);
			for (int i = 0; i < graphicsForCanvas.Count; i++)
			{
				Graphic graphic = graphicsForCanvas[i];
				if (graphic.depth != -1 && graphic.raycastTarget && RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, o_positionOnCanvas, eventCamera) && graphic.Raycast(o_positionOnCanvas, eventCamera))
				{
					list2.Add(graphic);
				}
			}
			list2.Sort((Graphic g1, Graphic g2) => g2.depth.CompareTo(g1.depth));
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j].gameObject);
			}
			list2.Clear();
			return list;
		}

		public void Click()
		{
			for (int i = 0; i < GetObjectsUnderPointer().Count; i++)
			{
				ExecuteEvents.Execute(GetObjectsUnderPointer()[i], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
			}
		}

		private void ModifyQuad(List<Vector3> verts, int vertexIndex, Vector2 requiredSize)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < 4; i++)
			{
				list.Add(verts[vertexIndex + i]);
			}
			Vector3 vector = list[2] - list[1];
			Vector3 vector2 = list[1] - list[0];
			int num = Mathf.CeilToInt(vector.magnitude * (1f / Mathf.Max(1f, requiredSize.x)));
			int num2 = Mathf.CeilToInt(vector2.magnitude * (1f / Mathf.Max(1f, requiredSize.y)));
			float y = 0f;
			for (int j = 0; j < num2; j++)
			{
				float num3 = ((float)j + 1f) / (float)num2;
				float x = 0f;
				for (int k = 0; k < num; k++)
				{
					float num4 = ((float)k + 1f) / (float)num;
					verts.Add(TesselateQuad(list, x, y));
					verts.Add(TesselateQuad(list, x, num3));
					verts.Add(TesselateQuad(list, num4, num3));
					verts.Add(TesselateQuad(list, num4, y));
					x = num4;
				}
				y = num3;
			}
		}

		private Vector3 TesselateQuad(List<Vector3> quad, float x, float y)
		{
			Vector3 zero = Vector3.zero;
			List<float> list = new List<float>();
			list.Add((1f - x) * (1f - y));
			list.Add((1f - x) * y);
			list.Add(x * y);
			list.Add(x * (1f - y));
			List<float> list2 = list;
			for (int i = 0; i < 4; i++)
			{
				zero += quad[i] * list2[i];
			}
			return zero;
		}
	}
}
