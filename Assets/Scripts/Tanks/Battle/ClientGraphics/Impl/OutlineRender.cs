using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Camera))]
	public class OutlineRender : MonoBehaviour
	{
		[SerializeField]
		private Shader outlineFinal;

		[Range(0f, 20f)]
		public float Intensity = 2f;

		private Material _compositeMat;

		[SerializeField]
		private Camera helperCamera;

		private void Awake()
		{
			helperCamera.gameObject.SetActive(false);
			_compositeMat = new Material(outlineFinal);
		}

		public void OnEnable()
		{
			int qualityLevel = QualitySettings.GetQualityLevel();
			helperCamera.gameObject.SetActive(qualityLevel >= 2);
		}

		private void OnDisable()
		{
			helperCamera.gameObject.SetActive(false);
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dst)
		{
			if (!helperCamera.gameObject.activeSelf)
			{
				_compositeMat.SetFloat("_Intensity", 0f);
				Graphics.Blit(src, dst, _compositeMat, 0);
			}
			else
			{
				_compositeMat.SetFloat("_Intensity", Intensity);
				Graphics.Blit(src, dst, _compositeMat, 0);
			}
		}

		private void ClearScreen(RenderTexture dst)
		{
			RenderTexture source = new RenderTexture(1, 1, 0);
			Graphics.Blit(source, dst);
		}
	}
}
