using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	public class ColorButton : MonoBehaviour, IColorButtonElement
	{
		public bool noApplyMaterial;

		public bool hardlight;

		private ColorButtonController controller;

		private Image image;

		private void Awake()
		{
			InitElement();
		}

		private void InitElement()
		{
			image = GetComponent<Image>();
		}

		private void OnEnable()
		{
			InitElement();
			ClearController();
			InitController();
		}

		private void InitController()
		{
			ColorButtonController componentInParent = GetComponentInParent<ColorButtonController>();
			if (componentInParent != null)
			{
				componentInParent.AddElement(this);
			}
			controller = componentInParent;
		}

		private void OnTransformParentChanged()
		{
			ClearController();
			InitController();
		}

		private void OnDisable()
		{
			ClearController();
		}

		private void ClearController()
		{
			if (controller != null)
			{
				controller.RemoveElement(this);
			}
			controller = null;
		}

		public void SetColor(ColorData colorData)
		{
			if (hardlight)
			{
				image.color = colorData.hardlightColor;
			}
			else
			{
				image.color = colorData.color;
			}
			if (!noApplyMaterial)
			{
				image.material = colorData.material;
			}
		}
	}
}
