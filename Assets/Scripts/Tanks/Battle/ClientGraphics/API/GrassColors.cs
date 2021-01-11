using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class GrassColors : MonoBehaviour
	{
		public List<Color> colors = new List<Color>();

		public Color GetRandomColor()
		{
			return colors[Random.Range(0, colors.Count)];
		}
	}
}
