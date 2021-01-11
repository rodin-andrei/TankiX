using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientHUD.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HealthBarSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankComponent tank;

			public TankGroupComponent tankGroup;

			public HealthComponent health;

			public HealthConfigComponent healthConfig;
		}

		public class RemoteTankNode : TankNode
		{
			public RemoteTankComponent remoteTank;
		}

		public class AttachedHealthBarNode : Node
		{
			public HealthBarComponent healthBar;

			public TankGroupComponent tankGroup;
		}

		public class TankIncarnationNode : Node
		{
			public TankIncarnationComponent tankIncarnation;

			public TankGroupComponent tankGroup;
		}

		[OnEventFire]
		public void InitHealthBarProgressOnRemoteTanks(NodeAddedEvent e, RemoteTankNode tank, [Context][JoinByTank] AttachedHealthBarNode healthBar)
		{
			UpdateHealth(tank.health, tank.healthConfig, healthBar.healthBar);
		}

		[OnEventFire]
		public void ChangeProgressValueOnAnyHealthBar(HealthChangedEvent e, TankNode tank, [JoinByTank] AttachedHealthBarNode healthBar)
		{
			UpdateHealth(tank.health, tank.healthConfig, healthBar.healthBar);
		}

		private void UpdateHealth(HealthComponent health, HealthConfigComponent healthConfig, HealthBarComponent healthBar)
		{
			float num2 = (healthBar.ProgressValue = health.CurrentHealth / healthConfig.BaseHealth);
		}
	}
}
