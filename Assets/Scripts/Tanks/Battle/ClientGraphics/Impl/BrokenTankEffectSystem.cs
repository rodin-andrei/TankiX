using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using Tanks.Lobby.ClientSettings.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BrokenTankEffectSystem : ECSSystem
	{
		public class DeadTankNode : Node
		{
			public TankComponent tank;

			public TankDeadStateComponent tankDeadState;

			public TankShaderComponent tankShader;

			public AssembledTankComponent assembledTank;

			public RigidbodyComponent rigidbody;

			public TemperatureVisualControllerComponent temperatureVisualController;

			public CameraVisibleTriggerComponent cameraVisibleTrigger;
		}

		public class BrokenNode : Node
		{
			public BaseRendererComponent baseRenderer;

			public BrokenEffectComponent brokenEffect;
		}

		[OnEventFire]
		public void DisableOrEnable(NodeAddedEvent e, BrokenNode brokenPart)
		{
			if (GraphicsSettings.INSTANCE.CurrentQualityLevel < 2)
			{
				brokenPart.Entity.RemoveComponent<BrokenEffectComponent>();
			}
			else
			{
				brokenPart.brokenEffect.Init();
			}
		}

		[OnEventComplete]
		public void StartEffect(NodeAddedEvent e, DeadTankNode deadTankNode, [JoinByTank][Combine] BrokenNode brokenPart)
		{
			Shader transparentShader = deadTankNode.tankShader.TransparentShader;
			float maxDepenetrationVelocity = ((!(deadTankNode.temperatureVisualController.Temperature >= 0f)) ? 1 : 20);
			brokenPart.brokenEffect.StartEffect(deadTankNode.assembledTank.AssemblyRoot, deadTankNode.rigidbody.Rigidbody, brokenPart.baseRenderer.Renderer, transparentShader, maxDepenetrationVelocity);
			brokenPart.baseRenderer.Renderer.enabled = false;
		}
	}
}
