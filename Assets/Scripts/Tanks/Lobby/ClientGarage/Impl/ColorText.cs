using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Text))]
	public class ColorText : MonoBehaviour, IColorButtonElement
	{
		public bool noApplyMaterial;

		private ColorButtonController controller;

		public Text text;

		private void Awake()
		{
			text = GetComponent<Text>();
		}

		private void OnEnable()
		{
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

		public virtual void SetColor(ColorData color)
		{
			text.color = color.color;
			if (!noApplyMaterial)
			{
				text.material = color.material;
			}
		}
	}
}
