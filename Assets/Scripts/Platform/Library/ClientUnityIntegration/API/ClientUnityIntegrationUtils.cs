using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public static class ClientUnityIntegrationUtils
	{
		[Inject]
		public static EngineServiceInternal EngineServiceInternal
		{
			get;
			set;
		}

		public static bool HasEngine()
		{
			return EngineServiceInternal != null;
		}

		public static bool HasWorkingEngine()
		{
			return EngineServiceInternal != null && EngineServiceInternal.IsRunning;
		}

		public static void CollectComponents(this GameObject gameObject, Entity entity)
		{
			UnityEngine.Component[] components = gameObject.GetComponents(typeof(Platform.Kernel.ECS.ClientEntitySystem.API.Component));
			UnityEngine.Component[] array = components;
			foreach (UnityEngine.Component component in array)
			{
				((EntityInternal)entity).AddComponent((Platform.Kernel.ECS.ClientEntitySystem.API.Component)component);
			}
		}

		public static void CollectComponentsInChildren(this GameObject gameObject, Entity entity)
		{
			UnityEngine.Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Platform.Kernel.ECS.ClientEntitySystem.API.Component));
			UnityEngine.Component[] array = componentsInChildren;
			foreach (UnityEngine.Component component in array)
			{
				((EntityInternal)entity).AddComponent((Platform.Kernel.ECS.ClientEntitySystem.API.Component)component);
			}
		}

		public static void ExecuteInFlow(Consumer<Engine> action)
		{
			if (!HasEngine())
			{
				Debug.LogError("Engine does not exist");
			}
			else
			{
				Flow.Current.ScheduleWith(action);
			}
		}
	}
}
