using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tanks.Battle.ClientGraphics.API
{
	public class CharacterShadowCommonSettingsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Shader blurShader;

		public Shader casterShader;

		public Shader receiverShader;

		public LayerMask ignoreLayers = 0;

		public int maxShadowMapAtlasSize = 2048;

		public int textureSize = 128;

		public int blurSize = 5;

		public Transform virtualLight;

		public RenderTexture shadowMap;

		private Camera camera;

		private Material horizontalBlurMaterial;

		private Material verticalBlurMaterial;

		private CommandBuffer commandBuffer;

		private int rawShadowMapNameId;

		private RenderTargetIdentifier rawShadowMapId;

		private int blurredShadowMapNameId;

		private RenderTargetIdentifier blurredShadowMapId;

		public RenderTextureFormat ShadowMapTextureFormat
		{
			get
			{
				if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.R8))
				{
					return RenderTextureFormat.R8;
				}
				return RenderTextureFormat.ARGB32;
			}
		}

		public Camera Camera
		{
			get
			{
				return camera;
			}
		}

		public Material HorizontalBlurMaterial
		{
			get
			{
				return horizontalBlurMaterial;
			}
		}

		public Material VerticalBlurMaterial
		{
			get
			{
				return verticalBlurMaterial;
			}
		}

		public CommandBuffer CommandBuffer
		{
			get
			{
				return commandBuffer;
			}
		}

		public int RawShadowMapNameId
		{
			get
			{
				return rawShadowMapNameId;
			}
		}

		public RenderTargetIdentifier RawShadowMapId
		{
			get
			{
				return rawShadowMapId;
			}
		}

		public int BlurredShadowMapNameId
		{
			get
			{
				return blurredShadowMapNameId;
			}
		}

		public RenderTargetIdentifier BlurredShadowMapId
		{
			get
			{
				return blurredShadowMapId;
			}
		}

		public int MaxCharactersCountInAtlas
		{
			get
			{
				int num = maxShadowMapAtlasSize / textureSize;
				return num * num;
			}
		}

		public void Awake()
		{
			if (!ShadowsSupported())
			{
				Object.Destroy(base.gameObject);
				return;
			}
			commandBuffer = new CommandBuffer();
			rawShadowMapNameId = Shader.PropertyToID("rawShadowMapNameId");
			rawShadowMapId = new RenderTargetIdentifier(rawShadowMapNameId);
			blurredShadowMapNameId = Shader.PropertyToID("blurredShadowMapNameId");
			blurredShadowMapId = new RenderTargetIdentifier(blurredShadowMapNameId);
			horizontalBlurMaterial = new Material(blurShader);
			verticalBlurMaterial = new Material(blurShader);
			horizontalBlurMaterial.SetVector("Direction", new Vector2(1f, 0f));
			verticalBlurMaterial.SetVector("Direction", new Vector2(0f, 1f));
			camera = CreateCamera();
			camera.AddCommandBuffer(CameraEvent.AfterForwardOpaque, commandBuffer);
		}

		public bool ShadowsSupported()
		{
			if (SystemInfo.supportsRenderTextures)
			{
				if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.R8))
				{
					return true;
				}
				if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGB32))
				{
					return true;
				}
			}
			return false;
		}

		private Camera CreateCamera()
		{
			GameObject gameObject = new GameObject("CharacterShadowCamera");
			gameObject.transform.parent = base.transform;
			Camera camera = gameObject.AddComponent<Camera>();
			camera.depth = -10f;
			camera.renderingPath = RenderingPath.VertexLit;
			camera.clearFlags = CameraClearFlags.Nothing;
			camera.backgroundColor = new Color(1f, 1f, 1f, 1f);
			camera.cullingMask = 0;
			camera.orthographic = true;
			camera.enabled = false;
			return camera;
		}
	}
}
