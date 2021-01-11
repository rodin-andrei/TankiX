using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsImageContainerComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private RectTransform imageContainer;

		[SerializeField]
		private AspectRatioFitter imageAspectRatioFitter;

		[SerializeField]
		private float imageAppearTime = 0.3f;

		private Graphic graphic;

		private float setImageTime;

		private float alphaBeforeAppear = float.NaN;

		public bool FitInParent
		{
			set
			{
				imageAspectRatioFitter.aspectMode = ((!value) ? AspectRatioFitter.AspectMode.EnvelopeParent : AspectRatioFitter.AspectMode.FitInParent);
			}
		}

		public Color Color
		{
			get
			{
				if (graphic != null)
				{
					return graphic.color;
				}
				return Color.black;
			}
			set
			{
				if (graphic != null)
				{
					graphic.color = value;
				}
			}
		}

		public void SetRawImage(Texture texture)
		{
			setImageTime = Time.time;
			((RawImage)(graphic = imageContainer.gameObject.AddComponent<RawImage>())).texture = texture;
			ApplyAspectRatio(texture);
		}

		public void SetImage(Sprite sprite)
		{
			setImageTime = Time.time;
			((Image)(graphic = imageContainer.gameObject.AddComponent<Image>())).sprite = sprite;
			ApplyAspectRatio(sprite.texture);
		}

		public void SetImageSkin(string spriteUid, float aspectRatio)
		{
			setImageTime = Time.time;
			Image image = (Image)(graphic = imageContainer.gameObject.AddComponent<Image>());
			ImageSkin imageSkin = imageContainer.gameObject.AddComponent<ImageSkin>();
			imageSkin.SpriteUid = spriteUid;
			ApplyAspectRatio(aspectRatio);
		}

		private void Update()
		{
			if (setImageTime > 0f)
			{
				if (float.IsNaN(alphaBeforeAppear))
				{
					alphaBeforeAppear = Color.a;
				}
				float time = Time.time;
				float num = Mathf.Clamp01((time - setImageTime) / imageAppearTime);
				Color color = Color;
				color.a = alphaBeforeAppear * num;
				Color = color;
				if (num == 1f)
				{
					setImageTime = 0f;
				}
			}
		}

		private void ApplyAspectRatio(Texture texture)
		{
			if (texture.height > 0)
			{
				ApplyAspectRatio((float)texture.width / (float)texture.height);
			}
		}

		private void ApplyAspectRatio(float aspectRatio)
		{
			imageAspectRatioFitter.aspectRatio = aspectRatio;
		}
	}
}
