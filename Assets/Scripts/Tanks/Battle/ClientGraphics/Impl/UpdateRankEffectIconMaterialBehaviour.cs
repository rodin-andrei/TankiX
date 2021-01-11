using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectIconMaterialBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Image img;

		[SerializeField]
		private Image sourceImage;

		private Material mat;

		private bool materialUpdate;

		public float opacity;

		private void Awake()
		{
			CopyFromSkinnedImage();
			mat = Object.Instantiate(img.material);
			img.material = mat;
			materialUpdate = true;
			img.preserveAspect = true;
		}

		private void Update()
		{
			CopyFromSkinnedImage();
			if (materialUpdate)
			{
				if (opacity >= 1f)
				{
					mat.SetFloat("_Opacity", 1f);
					materialUpdate = false;
				}
				else
				{
					mat.SetFloat("_Opacity", opacity);
				}
			}
		}

		private void CopyFromSkinnedImage()
		{
			if (img.sprite != sourceImage.sprite)
			{
				img.sprite = sourceImage.sprite;
			}
			if (img.overrideSprite != sourceImage.overrideSprite)
			{
				img.overrideSprite = sourceImage.overrideSprite;
			}
			if (img.type != sourceImage.type)
			{
				img.type = sourceImage.type;
			}
		}
	}
}
