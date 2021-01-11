using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class RadioButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject inactiveHighlight;

		public Selectable Selectable
		{
			get
			{
				return GetComponent<Selectable>();
			}
		}

		public virtual void Activate()
		{
			Selectable.interactable = false;
			inactiveHighlight.SetActive(true);
			IEnumerator enumerator = base.transform.parent.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					if (!(transform == base.transform))
					{
						RadioButton component = transform.GetComponent<RadioButton>();
						if (component != null)
						{
							component.Deactivate();
						}
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		public virtual void Deactivate()
		{
			Selectable.interactable = true;
			inactiveHighlight.SetActive(false);
			Selectable.OnPointerExit(null);
		}
	}
}
