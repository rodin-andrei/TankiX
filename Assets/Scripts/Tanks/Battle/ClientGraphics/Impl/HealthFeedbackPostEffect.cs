using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HealthFeedbackPostEffect : MonoBehaviour
	{
		private const float MAX_DAMAGE_LEVEL = 100f;

		[SerializeField]
		private Material mat;

		private int damageID;

		private float damageIntensity;

		public float DamageIntensity
		{
			get
			{
				return damageIntensity;
			}
			set
			{
				damageIntensity = value;
				mat.SetFloat(damageID, Mathf.Lerp(0f, 100f, damageIntensity));
			}
		}

		public void Init(Material sourceMaterial)
		{
			mat = Object.Instantiate(sourceMaterial);
			damageID = Shader.PropertyToID("_damage_lvl");
			DamageIntensity = 0f;
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			Graphics.Blit(src, dest, mat);
		}
	}
}
