using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientYaml.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public abstract class ECSBehaviour : MonoBehaviour, Engine
	{
		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public Entity CreateEntity(string name)
		{
			return EngineService.Engine.CreateEntity(name);
		}

		public Entity CreateEntity<T>() where T : Template
		{
			return EngineService.Engine.CreateEntity<T>();
		}

		public Entity CreateEntity<T>(YamlNode yamlNode) where T : Template
		{
			return EngineService.Engine.CreateEntity<T>(yamlNode);
		}

		public Entity CreateEntity<T>(string configPath) where T : Template
		{
			return EngineService.Engine.CreateEntity<T>(configPath);
		}

		public Entity CreateEntity(Type templateType, string configPath)
		{
			return EngineService.Engine.CreateEntity(templateType, configPath);
		}

		public Entity CreateEntity<T>(string configPath, long id) where T : Template
		{
			return EngineService.Engine.CreateEntity<T>(configPath, id);
		}

		public Entity CreateEntity(long templateId, string configPath, long id)
		{
			return EngineService.Engine.CreateEntity(templateId, configPath, id);
		}

		public Entity CreateEntity(long templateId, string configPath)
		{
			return EngineService.Engine.CreateEntity(templateId, configPath);
		}

		public Entity CloneEntity(string name, Entity entity)
		{
			return EngineService.Engine.CloneEntity(name, entity);
		}

		public ICollection<Entity> CreateEntities<T>(string configPathWithWildcard) where T : Template
		{
			return EngineService.Engine.CreateEntities<T>(configPathWithWildcard);
		}

		public void DeleteEntity(Entity entity)
		{
			EngineService.Engine.DeleteEntity(entity);
		}

		public EventBuilder NewEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event eventInstance)
		{
			return EngineService.Engine.NewEvent(eventInstance);
		}

		public EventBuilder NewEvent<T>() where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			return EngineService.Engine.NewEvent<T>();
		}

		public void ScheduleEvent<T>() where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			EngineService.Engine.ScheduleEvent<T>();
		}

		public void ScheduleEvent<T>(Entity entity) where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			EngineService.Engine.ScheduleEvent<T>(entity);
		}

		public void ScheduleEvent<T>(Node node) where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			EngineService.Engine.ScheduleEvent<T>(node);
		}

		public void ScheduleEvent<T>(GroupComponent group) where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			EngineService.Engine.ScheduleEvent<T>(group);
		}

		public void ScheduleEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event eventInstance)
		{
			EngineService.Engine.ScheduleEvent(eventInstance);
		}

		public void ScheduleEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event eventInstance, Entity entity)
		{
			EngineService.Engine.ScheduleEvent(eventInstance, entity);
		}

		public void ScheduleEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event eventInstance, Node node)
		{
			EngineService.Engine.ScheduleEvent(eventInstance, node);
		}

		public void ScheduleEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event eventInstance, GroupComponent group)
		{
			EngineService.Engine.ScheduleEvent(eventInstance, group);
		}

		public IList<T> Select<T>(Entity entity, Type groupComponentType) where T : Node
		{
			return EngineService.Engine.Select<T>(entity, groupComponentType);
		}

		public ICollection<T> SelectAll<T>() where T : Node
		{
			return EngineService.Engine.SelectAll<T>();
		}

		public ICollection<Entity> SelectAllEntities<T>() where T : Node
		{
			return EngineService.Engine.SelectAllEntities<T>();
		}
	}
}
