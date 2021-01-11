using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class Tab : MonoBehaviour
	{
		[SerializeField]
		protected RadioButton button;

		private bool _show;

		public bool show
		{
			get
			{
				return _show;
			}
			set
			{
				_show = value;
			}
		}

		public virtual void Show()
		{
			show = true;
			button.Activate();
			if (base.gameObject.activeInHierarchy)
			{
				OnEnable();
			}
			else
			{
				base.gameObject.SetActive(true);
			}
		}

		public virtual void Hide()
		{
			show = false;
			if (base.gameObject.activeInHierarchy)
			{
				GetComponent<Animator>().SetBool("show", false);
			}
			else
			{
				base.gameObject.SetActive(false);
			}
			SendMessage("OnHide", SendMessageOptions.DontRequireReceiver);
		}

		protected virtual void OnEnable()
		{
			GetComponent<CanvasGroup>().alpha = 0f;
			GetComponent<Animator>().SetBool("show", true);
		}

		public virtual void OnHid()
		{
			if (show)
			{
				OnEnable();
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
