using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class SpectatorBattleScreenComponent : BehaviourComponent, AttachToEntityListener, DetachFromEntityListener
	{
		public GameObject scoreTable;

		public GameObject scoreTableShadow;

		public GameObject spectatorChat;

		private Entity entity;

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		private void OnGUI()
		{
			if (entity != null && UnityEngine.Event.current.type == EventType.KeyDown && InputManager.GetActionKeyDown(SpectatorCameraActions.GoBack))
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent<SpectatorGoBackRequestEvent>(entity);
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		public void DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}

		private void OnDisable()
		{
			spectatorChat.SetActive(false);
		}
	}
}
