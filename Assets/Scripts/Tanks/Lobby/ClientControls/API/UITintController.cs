using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class UITintController : MonoBehaviour
	{
		public Color tint = Color.white;

		private Color lastTint;

		private List<UITint> elements = new List<UITint>();

		public void AddElement(UITint element)
		{
			elements.Add(element);
		}

		public void RemoveElement(UITint element)
		{
			elements.Remove(element);
		}

		private void Update()
		{
			if (tint != lastTint)
			{
				for (int i = 0; i < elements.Count; i++)
				{
					SetTint(elements[i], tint);
				}
				lastTint = tint;
			}
		}

		protected virtual void SetTint(UITint uiTint, Color tint)
		{
			uiTint.SetTint(tint);
		}
	}
}
