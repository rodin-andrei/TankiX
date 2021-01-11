using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class PaletteColor : MonoBehaviour
	{
		[SerializeField]
		private Palette palette;

		[SerializeField]
		private int uid;

		[SerializeField]
		private bool applyToChildren;

		private List<Graphic> graphicCache = new List<Graphic>();

		private void Start()
		{
			Apply(palette);
			if (Application.isPlaying)
			{
				Object.Destroy(this);
			}
		}

		private void Apply(Palette palette)
		{
			if (applyToChildren)
			{
				GetComponentsInChildren(graphicCache);
				foreach (Graphic item in graphicCache)
				{
					ApplyToGraphic(item, palette);
				}
			}
			else
			{
				Graphic component = GetComponent<Graphic>();
				ApplyToGraphic(component, palette);
			}
		}

		private void ApplyToGraphic(Graphic graphic, Palette palette)
		{
			graphic.color = palette.Apply(uid, graphic.color);
		}
	}
}
