using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class LightContainer : MonoBehaviour
	{
		[SerializeField]
		private Light[] lights;
		public float maxLightIntensity;
	}
}
