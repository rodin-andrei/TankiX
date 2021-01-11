using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CameraComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Camera UnityCamera
		{
			get;
			set;
		}

		public bool Enabled
		{
			get
			{
				return UnityCamera.enabled;
			}
			set
			{
				UnityCamera.enabled = value;
			}
		}

		public float FOV
		{
			get
			{
				return UnityCamera.fieldOfView;
			}
			set
			{
				UnityCamera.fieldOfView = value;
			}
		}

		public DepthTextureMode DepthTextureMode
		{
			get
			{
				return UnityCamera.depthTextureMode;
			}
			set
			{
				UnityCamera.depthTextureMode = value;
			}
		}

		public Matrix4x4 ProjectionMatrix
		{
			get
			{
				return UnityCamera.projectionMatrix;
			}
		}

		public Matrix4x4 WorldToCameraMatrix
		{
			get
			{
				return UnityCamera.worldToCameraMatrix;
			}
		}

		public PostEffectsSet[] PostEffectsSets
		{
			get;
			private set;
		}

		public SetPostProcessing SetPostProcessing
		{
			get;
			set;
		}

		public PostProcessingBehaviour PostProcessingBehaviour
		{
			get;
			set;
		}

		public CameraComponent(Camera unityCamera)
		{
			UnityCamera = unityCamera;
			PostProcessingBehaviour = unityCamera.GetComponent<PostProcessingBehaviour>();
			PostEffectsSets = unityCamera.GetComponents<PostEffectsSet>();
		}
	}
}
