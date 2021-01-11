using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[ExecuteInEditMode]
	public class ColorButtonController : MonoBehaviour
	{
		[SerializeField]
		public List<ColorData> colors = new List<ColorData>();

		private ColorData currentColor = new ColorData();

		private ColorData lastColor;

		private List<IColorButtonElement> elements = new List<IColorButtonElement>();

		public void Awake()
		{
			currentColor = GetDefaultColor();
		}

		public void AddElement(IColorButtonElement element)
		{
			element.SetColor(currentColor);
			elements.Add(element);
		}

		public void RemoveElement(IColorButtonElement element)
		{
			elements.Remove(element);
		}

		private void SetColor(ColorData color)
		{
			for (int i = 0; i < elements.Count; i++)
			{
				elements[i].SetColor(color);
			}
		}

		public void SetDefault()
		{
			ColorData defaultColor = GetDefaultColor();
			for (int i = 0; i < elements.Count; i++)
			{
				elements[i].SetColor(defaultColor);
			}
			currentColor = defaultColor;
		}

		private ColorData GetDefaultColor()
		{
			ColorData result = new ColorData();
			for (int i = 0; i < colors.Count; i++)
			{
				ColorData colorData = colors[i];
				if (colorData.defaultColor)
				{
					result = colorData;
				}
			}
			return result;
		}

		public void SetColor(int i)
		{
			currentColor = colors[i];
			SetColor(currentColor);
		}
	}
}
