using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Animator))]
	public class CombatEventLogMessage : BaseCombatLogMessageElement
	{
		[SerializeField]
		private float messageTimeout;

		[SerializeField]
		private LayoutElement layoutElement;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		protected RectTransform placeholder;

		protected RectTransform rightElement;

		private bool deleteRequested;

		public LayoutElement LayoutElement
		{
			get
			{
				return layoutElement;
			}
		}

		private void SendScroll()
		{
			SendMessageUpwards("OnScrollLog", layoutElement.preferredHeight);
		}

		private void Delete()
		{
			SendMessageUpwards("OnDeleteMessage", this);
		}

		public void RequestDelete()
		{
			if (!deleteRequested && (bool)animator)
			{
				deleteRequested = true;
				animator.SetTrigger("Hide");
			}
		}

		public void ShowMessage()
		{
			animator.SetTrigger("Show");
		}

		public virtual void Attach(RectTransform child, bool toRight)
		{
			child.SetParent(placeholder, false);
			if (toRight)
			{
				if (rightElement != null)
				{
					rightElement.SetParent(child, false);
					LayoutElement layoutElement = rightElement.GetComponent<LayoutElement>() ?? rightElement.gameObject.AddComponent<LayoutElement>();
					layoutElement.ignoreLayout = true;
				}
				rightElement = child;
			}
		}
	}
}
