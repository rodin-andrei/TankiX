using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(1949198098578360952L)]
	public class HealthComponent : Component
	{
		private float currentHealth;

		private float maxHealth;

		public float CurrentHealth
		{
			get
			{
				return currentHealth;
			}
			set
			{
				currentHealth = value;
			}
		}

		public float MaxHealth
		{
			get
			{
				return maxHealth;
			}
			set
			{
				maxHealth = value;
			}
		}
	}
}
