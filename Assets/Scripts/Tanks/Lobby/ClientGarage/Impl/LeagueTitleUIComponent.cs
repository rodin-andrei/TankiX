using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LeagueTitleUIComponent : BehaviourComponent
	{
		private Entity leagueEntity;

		[SerializeField]
		private new TextMeshProUGUI name;

		[SerializeField]
		private ImageSkin icon;

		public Entity LeagueEntity
		{
			get
			{
				return leagueEntity;
			}
		}

		public string Name
		{
			set
			{
				name.text = value;
			}
		}

		public string Icon
		{
			set
			{
				icon.SpriteUid = value;
			}
		}

		public void Init(Entity entity)
		{
			if (entity.HasComponent<LeagueTitleUIComponent>())
			{
				entity.RemoveComponent<LeagueTitleUIComponent>();
			}
			entity.AddComponent(this);
			leagueEntity = entity;
		}

		private void OnDestroy()
		{
			if (ClientUnityIntegrationUtils.HasEngine())
			{
				RemoveFromEntity();
			}
		}

		private void RemoveFromEntity()
		{
			if (leagueEntity != null && leagueEntity.HasComponent<LeagueTitleUIComponent>())
			{
				leagueEntity.RemoveComponent<LeagueTitleUIComponent>();
			}
		}
	}
}
