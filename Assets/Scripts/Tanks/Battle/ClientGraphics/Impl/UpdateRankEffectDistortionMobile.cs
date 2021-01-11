using System.Collections;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectDistortionMobile : MonoBehaviour
	{
		public float TextureScale = 1f;

		public RenderTextureFormat RenderTextureFormat;

		public FilterMode FilterMode;

		public LayerMask CullingMask = -17;

		public RenderingPath RenderingPath;

		public int FPSWhenMoveCamera = 40;

		public int FPSWhenStaticCamera = 20;

		private RenderTexture renderTexture;

		private Camera cameraInstance;

		private GameObject goCamera;

		private Vector3 oldPosition;

		private Quaternion oldRotation;

		private Transform instanceCameraTransform;

		private bool canUpdateCamera;

		private bool isStaticUpdate;

		private WaitForSeconds fpsMove;

		private WaitForSeconds fpsStatic;

		private const int dropedFrames = 50;

		private int frameCountWhenCameraIsStatic;

		private bool isInitialized;

		private void OnEnable()
		{
			fpsMove = new WaitForSeconds(1f / (float)FPSWhenMoveCamera);
			fpsStatic = new WaitForSeconds(1f / (float)FPSWhenStaticCamera);
		}

		private void Update()
		{
			if (!isInitialized)
			{
				Initialize();
				StartCoroutine(RepeatCameraMove());
				StartCoroutine(RepeatCameraStatic());
			}
			if (Vector3.SqrMagnitude(instanceCameraTransform.position - oldPosition) <= 1E-05f && instanceCameraTransform.rotation == oldRotation)
			{
				frameCountWhenCameraIsStatic++;
				if (frameCountWhenCameraIsStatic >= 50)
				{
					isStaticUpdate = true;
				}
			}
			else
			{
				frameCountWhenCameraIsStatic = 0;
				isStaticUpdate = false;
			}
			oldPosition = instanceCameraTransform.position;
			oldRotation = instanceCameraTransform.rotation;
			if (cameraInstance == null)
			{
				canUpdateCamera = false;
			}
			else if (canUpdateCamera)
			{
				cameraInstance.enabled = true;
				canUpdateCamera = false;
			}
			else if (cameraInstance.enabled)
			{
				cameraInstance.enabled = false;
			}
		}

		private IEnumerator RepeatCameraMove()
		{
			while (true)
			{
				if (!isStaticUpdate)
				{
					canUpdateCamera = true;
				}
				yield return fpsMove;
			}
		}

		private IEnumerator RepeatCameraStatic()
		{
			while (true)
			{
				if (isStaticUpdate)
				{
					canUpdateCamera = true;
				}
				yield return fpsStatic;
			}
		}

		private void OnBecameVisible()
		{
			if (goCamera != null)
			{
				goCamera.SetActive(true);
			}
		}

		private void OnBecameInvisible()
		{
			if (goCamera != null)
			{
				goCamera.SetActive(false);
			}
		}

		private void Initialize()
		{
			goCamera = new GameObject("RenderTextureCamera");
			cameraInstance = goCamera.AddComponent<Camera>();
			Camera main = Camera.main;
			cameraInstance.CopyFrom(main);
			cameraInstance.depth += 1f;
			cameraInstance.cullingMask = CullingMask;
			cameraInstance.renderingPath = RenderingPath;
			goCamera.transform.parent = main.transform;
			renderTexture = new RenderTexture(Mathf.RoundToInt((float)Screen.width * TextureScale), Mathf.RoundToInt((float)Screen.height * TextureScale), 16, RenderTextureFormat);
			renderTexture.DiscardContents();
			renderTexture.filterMode = FilterMode;
			cameraInstance.targetTexture = renderTexture;
			instanceCameraTransform = cameraInstance.transform;
			oldPosition = instanceCameraTransform.position;
			Shader.SetGlobalTexture("_GrabTextureMobile", renderTexture);
			isInitialized = true;
		}

		private void OnDisable()
		{
			if ((bool)goCamera)
			{
				Object.DestroyImmediate(goCamera);
				goCamera = null;
			}
			if ((bool)renderTexture)
			{
				Object.DestroyImmediate(renderTexture);
				renderTexture = null;
			}
			isInitialized = false;
		}
	}
}
