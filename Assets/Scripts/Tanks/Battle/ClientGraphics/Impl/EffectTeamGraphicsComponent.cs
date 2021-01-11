using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EffectTeamGraphicsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Material redTeamMaterial;

		[SerializeField]
		private Material blueTeamMaterial;

		[SerializeField]
		private Material selfMaterial;

		public Material RedTeamMaterial
		{
			get
			{
				return redTeamMaterial;
			}
			set
			{
				redTeamMaterial = value;
			}
		}

		public Material BlueTeamMaterial
		{
			get
			{
				return blueTeamMaterial;
			}
			set
			{
				blueTeamMaterial = value;
			}
		}

		public Material SelfMaterial
		{
			get
			{
				return selfMaterial;
			}
		}
	}
}
