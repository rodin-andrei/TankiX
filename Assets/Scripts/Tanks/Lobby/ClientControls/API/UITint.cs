using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Graphic))]
	public class UITint : MonoBehaviour
	{
		private UITintController controller;

		private Graphic graphic;

		private void Awake()
		{
			graphic = GetComponent<Graphic>();
		}

		private void OnEnable()
		{
			ClearController();
			InitController();
		}

		private void InitController()
		{
			UITintController componentInParent = GetComponentInParent<UITintController>();
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

		public virtual void SetTint(Color tint)
		{
			graphic.color = tint;
		}
	}
}
