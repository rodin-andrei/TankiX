using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(6707178642658066560L)]
	public class DamageWeakeningByTargetComponent : Component
	{
		public float DamagePercent
		{
			get;
			set;
		}

		public DamageWeakeningByTargetComponent()
		{
		}

		public DamageWeakeningByTargetComponent(float damagePercent)
		{
			DamagePercent = damagePercent;
		}
	}
}
