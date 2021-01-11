using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Battle.ClientCore.API
{
	public class DamageHistoryItem
	{
		public Date TimeOfDamage;

		public float Damage;

		public Entity DamagerUser;
	}
}
