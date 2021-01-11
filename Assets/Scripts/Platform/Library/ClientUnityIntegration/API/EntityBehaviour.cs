using System;
using System.Collections;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	[DisallowMultipleComponent]
	public class EntityBehaviour : MonoBehaviour
	{
		private const string INVALID_TEMPLATE_TYPE_FORMAT = "Invalid Type {0} on object {1}";

		private readonly List<UnityEngine.Component> components = new List<UnityEngine.Component>();

		[SerializeField]
		[Obsolete]
		public string template;

		[SerializeField]
		private int templateIdLow;

		[SerializeField]
		private int templateIdHigh;

		public string configPath;

		public bool handleAutomaticaly;

		[Inject]
		public static GroupRegistry GroupRegistry
		{
			get;
			set;
		}

		[Inject]
		public static TemplateRegistry TemplateRegistry
		{
			get;
			set;
		}

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public long TemplateId
		{
			get
			{
				if (templateIdHigh == 0 && templateIdLow == 0 && !string.IsNullOrEmpty(template))
				{
					Type type = Type.GetType(template);
					if (type == null)
					{
						Debug.LogError(string.Format("Invalid Type {0} on object {1}", type, base.name), this);
					}
					else
					{
						TemplateId = TemplateRegistry.GetTemplateInfo(type).TemplateId;
					}
				}
				return ((long)templateIdHigh << 32) | (uint)templateIdLow;
			}
			set
			{
				templateIdLow = (int)(value & 0xFFFFFFFFu);
				templateIdHigh = (int)(value >> 32);
			}
		}

		public Entity Entity
		{
			get;
			private set;
		}

		private void Awake()
		{
			if (GetComponents<EntityBehaviour>().Length > 1)
			{
				throw new GameObjectAlreadyContainsEntityBehaviour(base.gameObject);
			}
		}

		private void OnEnable()
		{
			if (handleAutomaticaly)
			{
				CreateEntity();
			}
		}

		public void CreateEntity()
		{
			if (!ClientUnityIntegrationUtils.HasWorkingEngine())
			{
				DelayedEntityBehaviourActivator delayedEntityBehaviourActivator = UnityEngine.Object.FindObjectOfType<DelayedEntityBehaviourActivator>();
				if ((bool)delayedEntityBehaviourActivator)
				{
					delayedEntityBehaviourActivator.DelayedEntityBehaviours.Add(this);
					return;
				}
				Debug.LogWarningFormat("EntityBehaviour {0} can't be delayed, 'cause {1} is not exists", base.name, typeof(DelayedEntityBehaviourActivator).Name);
			}
			else
			{
				DoCreateEntity(EngineService.Engine);
			}
		}

		private void DoCreateEntity(Engine engine)
		{
			long templateId = TemplateId;
			Entity entity = ((templateId == 0) ? engine.CreateEntity(base.name) : engine.CreateEntity(templateId, configPath));
			BuildEntity(entity);
		}

		private void OnDisable()
		{
			if (handleAutomaticaly && Entity != null && ((EntityInternal)Entity).Alive && ClientUnityIntegrationUtils.HasWorkingEngine())
			{
				DestroyEntity();
			}
		}

		public void DestroyEntity()
		{
			EngineService.Engine.DeleteEntity(Entity);
			Entity = null;
		}

		private void OnDestroy()
		{
			if (!handleAutomaticaly && Entity != null && ((EntityInternal)Entity).Alive && ClientUnityIntegrationUtils.HasWorkingEngine())
			{
				RemoveUnityComponentsFromEntity();
			}
		}

		private void RemoveComponent(Platform.Kernel.ECS.ClientEntitySystem.API.Component component)
		{
			Type type = component.GetType();
			if (Entity.HasComponent(type))
			{
				Entity.RemoveComponent(type);
			}
		}

		private void OnApplicationQuit()
		{
			Entity = null;
		}

		public void BuildEntity(Entity entity)
		{
			if (Entity != null)
			{
				throw new EntityAlreadyExistsException(Entity.Name);
			}
			Entity = entity;
			CollectComponents(base.gameObject, AddComponent);
		}

		public void DetachFromEntity()
		{
			if (handleAutomaticaly)
			{
				throw new Exception("Couldn't detach entity from entityBehaviour in automatically mode");
			}
			if (Entity != null)
			{
				if (((EntityInternal)Entity).Alive && ClientUnityIntegrationUtils.HasWorkingEngine())
				{
					RemoveUnityComponentsFromEntity();
				}
				Entity = null;
			}
		}

		private void AddComponent(Platform.Kernel.ECS.ClientEntitySystem.API.Component component)
		{
			ComponentInstanceDataUpdater.Update((EntityInternal)Entity, component);
			Entity.AddComponent(component);
		}

		public void Join<T>(Entity key) where T : GroupComponent, new()
		{
			AddJoinComponent<T>(key);
			JoinChildren<T>(base.gameObject.transform, key);
		}

		private void JoinChildren<T>(Transform transform, Entity key) where T : GroupComponent, new()
		{
			IEnumerator enumerator = transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform2 = (Transform)enumerator.Current;
					EntityBehaviour component = transform2.GetComponent<EntityBehaviour>();
					if (component != null)
					{
						component.Join<T>(key);
					}
					else
					{
						JoinChildren<T>(transform2, key);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		private void AddJoinComponent<T>(Entity key) where T : GroupComponent
		{
			GroupComponent component = GroupRegistry.FindOrCreateGroup<T>(key.Id);
			Entity.AddComponent(component);
		}

		private void CollectComponents(GameObject gameObject, Action<Platform.Kernel.ECS.ClientEntitySystem.API.Component> handler)
		{
			gameObject.GetComponents(typeof(Platform.Kernel.ECS.ClientEntitySystem.API.Component), components);
			foreach (UnityEngine.Component component in components)
			{
				handler((Platform.Kernel.ECS.ClientEntitySystem.API.Component)component);
				if (Entity == null)
				{
					return;
				}
			}
			IEnumerator enumerator2 = gameObject.transform.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					Transform transform = (Transform)enumerator2.Current;
					if (!(transform.GetComponent<EntityBehaviour>() != null))
					{
						CollectComponents(transform.gameObject, handler);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator2 as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void RemoveUnityComponentsFromEntity()
		{
			if (Entity != null)
			{
				CollectComponents(base.gameObject, RemoveComponent);
			}
		}

		public static void CleanUp(GameObject gameObject)
		{
			EntityBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<EntityBehaviour>();
			foreach (EntityBehaviour entityBehaviour in componentsInChildren)
			{
				entityBehaviour.RemoveUnityComponentsFromEntity();
			}
		}
	}
}
