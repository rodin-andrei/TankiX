using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class Mask
	{
		private readonly Texture2D texture;

		private List<Vector2> markedPixels;

		public int Width
		{
			get
			{
				return texture.width;
			}
		}

		public int Height
		{
			get
			{
				return texture.height;
			}
		}

		public List<Vector2> MarkedPixels
		{
			get
			{
				return markedPixels;
			}
		}

		public Mask(Texture2D texture, float blackThreshold, bool whiteAsEmpty)
		{
			this.texture = texture;
			markedPixels = new List<Vector2>();
			for (int i = 0; i < texture.width; i++)
			{
				for (int j = 0; j < texture.height; j++)
				{
					if (IsMaskPixel(i, j, blackThreshold, whiteAsEmpty))
					{
						markedPixels.Add(new Vector2(i, j));
					}
				}
			}
		}

		private bool IsMaskPixel(int i, int j, float blackThreshold, bool whiteAsEmpty)
		{
			Color pixel = texture.GetPixel(i, j);
			return (!whiteAsEmpty) ? (pixel.r > blackThreshold) : (pixel.r <= blackThreshold);
		}
	}
}
