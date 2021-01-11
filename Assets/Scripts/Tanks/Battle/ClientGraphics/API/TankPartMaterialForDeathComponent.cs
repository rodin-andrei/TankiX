using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TankPartMaterialForDeathComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Material[] deathMaterials;

		public Material[] DeathMaterials
		{
			get
			{
				return deathMaterials;
			}
		}
	}
}
