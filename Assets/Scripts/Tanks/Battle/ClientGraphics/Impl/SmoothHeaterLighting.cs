using UnityEngine;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SmoothHeaterLighting : SmoothHeater
	{
		public SmoothHeaterLighting(int burningTimeInMs, Material temperatureMaterial, MonoBehaviour updater, LightContainer lightContainer) : base(default(int), default(Material), default(MonoBehaviour))
		{
		}

	}
}
