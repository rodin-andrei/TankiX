using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	public class ImageSkin : MonoBehaviour, SpriteRequest
	{
		[SerializeField]
		private string structureUid;

		private bool requestRegistered;

		[SerializeField]
		private string spriteUid;

		private Image image;

		public Image.Type type;

		private BaseElementScaleController requestHolder;

		private Image Image
		{
			get
			{
				if (image == null && this != null && base.gameObject != null)
				{
					image = GetComponent<Image>();
				}
				return image;
			}
		}

		public string SpriteUid
		{
			get
			{
				return spriteUid;
			}
			set
			{
				if (spriteUid != value)
				{
					CancelRequest();
					spriteUid = value;
					RegisterRequest();
				}
			}
		}

		public string Uid
		{
			get
			{
				return SpriteUid;
			}
		}

		protected virtual void OnEnable()
		{
			RegisterRequest();
		}

		protected void OnBeforeTransformParentChanged()
		{
			CancelRequest();
		}

		protected void OnTransformParentChanged()
		{
			RegisterRequest();
		}

		private void RegisterRequest()
		{
			if (!string.IsNullOrEmpty(spriteUid))
			{
				if (Application.isPlaying && Image.overrideSprite == null)
				{
					Image.enabled = false;
				}
				BaseElementScaleControllerProvider componentInParent = GetComponentInParent<BaseElementScaleControllerProvider>();
				if (componentInParent != null && componentInParent.BaseElementScaleController != null)
				{
					requestHolder = componentInParent.BaseElementScaleController;
					componentInParent.BaseElementScaleController.RegisterSpriteRequest(this);
					requestRegistered = true;
				}
			}
			else if (Application.isPlaying)
			{
				Image.sprite = null;
				Image.enabled = false;
			}
		}

		private void CancelRequest()
		{
			if (requestRegistered && requestHolder != null)
			{
				requestHolder.UnregisterSpriteRequest(this);
				requestRegistered = false;
			}
		}

		public void Resolve(Sprite sprite)
		{
			if (Image == null)
			{
				CancelRequest();
			}
			else if (Application.isPlaying)
			{
				Image.sprite = sprite;
				Image.enabled = true;
			}
			else
			{
				Image.overrideSprite = sprite;
			}
		}

		public void Cancel()
		{
			if (Image != null)
			{
				Image.sprite = null;
				Image.overrideSprite = null;
			}
		}

		public void ResetSkin()
		{
			Image.sprite = null;
		}

		protected void Reset()
		{
			ResetSkin();
		}

		protected void OnDestroy()
		{
			CancelRequest();
			Cancel();
		}
	}
}
