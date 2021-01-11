using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TeamUIColorizeComponent : BehaviourComponent
	{
		[SerializeField]
		private List<Color> redColors;

		[SerializeField]
		private List<Color> blueColors;

		[SerializeField]
		private List<Graphic> elements;

		public void ColorizeBlue()
		{
			Colorize(blueColors);
		}

		public void ColorizeRed()
		{
			Colorize(redColors);
		}

		private void Colorize(List<Color> colors)
		{
			for (int i = 0; i < elements.Count; i++)
			{
				elements[i].color = colors[i];
			}
		}
	}
}
