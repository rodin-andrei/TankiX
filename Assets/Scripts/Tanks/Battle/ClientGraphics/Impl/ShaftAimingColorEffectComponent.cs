using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingColorEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Color redColor = new Color(255f, 0f, 0f);

		[SerializeField]
		private Color blueColor = new Color(0f, 187f, 255f);

		public Color RedColor
		{
			get
			{
				return redColor;
			}
			set
			{
				redColor = value;
			}
		}

		public Color BlueColor
		{
			get
			{
				return blueColor;
			}
			set
			{
				blueColor = value;
			}
		}

		public Color ChoosenColor
		{
			get;
			set;
		}
	}
}
