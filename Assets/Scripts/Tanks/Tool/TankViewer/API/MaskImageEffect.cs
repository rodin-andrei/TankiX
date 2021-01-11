using UnityEngine;

namespace Tanks.Tool.TankViewer.API
{
	public class MaskImageEffect : MonoBehaviour
	{
		public Shader shader;

		private Material material;

		private void Awake()
		{
			material = new Material(shader);
		}

		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, material);
		}
	}
}
