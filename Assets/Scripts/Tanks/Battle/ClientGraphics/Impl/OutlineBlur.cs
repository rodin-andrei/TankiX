using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Camera))]
	public class OutlineBlur : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 10f)]
		private float texelSizeCoeff;

		[SerializeField]
		private Shader tmpOutline;

		[SerializeField]
		private Shader outlineBlur;

		private Material blur;

		private static RenderTexture Outline;

		private static RenderTexture BlurredOutline;

		private float oldAspectRatio;

		private float newAspectRatio;

		private void OnEnable()
		{
			oldAspectRatio = Screen.width / Screen.height;
			Outline = new RenderTexture(Screen.width, Screen.height, 24);
			BlurredOutline = new RenderTexture(Screen.width >> 1, Screen.height >> 1, 0);
			Shader shader = tmpOutline;
			Camera component = GetComponent<Camera>();
			component.targetTexture = Outline;
			component.SetReplacementShader(shader, "Outline");
			Shader.SetGlobalTexture("_OutlineUnbluredTexture", Outline);
			Shader.SetGlobalTexture("_OutlineBluredTexture", BlurredOutline);
			blur = new Material(outlineBlur);
			blur.SetVector("_BlurSize", new Vector2(BlurredOutline.texelSize.x * texelSizeCoeff, BlurredOutline.texelSize.y * texelSizeCoeff));
		}

		private void OnDisable()
		{
			RenderTexture source = new RenderTexture(1, 1, 0);
			Graphics.Blit(source, BlurredOutline);
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dst)
		{
			newAspectRatio = (float)Screen.width / (float)Screen.height;
			if (oldAspectRatio != newAspectRatio)
			{
				OnDisable();
				OnEnable();
				oldAspectRatio = newAspectRatio;
			}
			blur.SetVector("_BlurSize", new Vector2(BlurredOutline.texelSize.x * texelSizeCoeff, BlurredOutline.texelSize.y * texelSizeCoeff));
			Graphics.Blit(src, dst);
			Graphics.Blit(src, BlurredOutline);
			for (int i = 0; i < 4; i++)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(BlurredOutline.width, BlurredOutline.height);
				Graphics.Blit(BlurredOutline, temporary, blur, 0);
				Graphics.Blit(temporary, BlurredOutline, blur, 1);
				RenderTexture.ReleaseTemporary(temporary);
			}
			oldAspectRatio = (float)Screen.width / (float)Screen.height;
		}
	}
}
