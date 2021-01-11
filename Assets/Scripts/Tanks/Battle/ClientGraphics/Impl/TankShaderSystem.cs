using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankShaderSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankComponent tank;

			public TankShaderComponent tankShader;

			public TankGroupComponent tankGroup;

			public BaseRendererComponent baseRenderer;

			public TankOpaqueShaderBlockersComponent tankOpaqueShaderBlockers;
		}

		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public BaseRendererComponent baseRenderer;

			public WeaponComponent weapon;
		}

		public class TankIncarnationNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankIncarnationComponent tankIncarnation;
		}

		[OnEventFire]
		public void AddOpaqueShaderBlockersComponent(NodeAddedEvent e, SingleNode<TankComponent> tank)
		{
			tank.Entity.AddComponent<TankOpaqueShaderBlockersComponent>();
		}

		[OnEventFire]
		public void ClearShaderBlockersComponent(NodeRemoveEvent e, TankIncarnationNode tankIncarnation, [JoinByTank] TankNode tank)
		{
			tank.tankOpaqueShaderBlockers.Blockers.Clear();
		}

		[OnEventFire]
		public void AddTankShaderEffect(AddTankShaderEffectEvent e, TankNode tank)
		{
			if (e.EnableException && tank.tankOpaqueShaderBlockers.Blockers.Contains(e.Key))
			{
				throw new TankShaderEffectAlreadyAddedException(e.Key);
			}
			tank.tankOpaqueShaderBlockers.Blockers.Add(e.Key);
		}

		[OnEventFire]
		public void StopTankShaderEffect(StopTankShaderEffectEvent e, TankNode tank, [JoinByTank] WeaponNode weapon)
		{
			if (e.EnableException && !tank.tankOpaqueShaderBlockers.Blockers.Contains(e.Key))
			{
				throw new TankShaderEffectNotFoundException(e.Key);
			}
			tank.tankOpaqueShaderBlockers.Blockers.Remove(e.Key);
			if (tank.tankOpaqueShaderBlockers.Blockers.Count <= 0)
			{
				ClientGraphicsUtil.ApplyShaderToRenderer(tank.baseRenderer.Renderer, tank.tankShader.OpaqueShader);
				ClientGraphicsUtil.ApplyShaderToRenderer(weapon.baseRenderer.Renderer, tank.tankShader.OpaqueShader);
			}
		}
	}
}
