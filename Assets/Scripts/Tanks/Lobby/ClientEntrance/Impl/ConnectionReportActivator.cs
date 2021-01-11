using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientNavigation.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class ConnectionReportActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Activator
	{
		public float connectionWaitTime = 15f;

		private ConnectionReportSystem system;

		public void RegisterSystemsAndTemplates()
		{
			system = new ConnectionReportSystem();
			ECSBehaviour.EngineService.RegisterSystem(system);
		}

		protected override void Activate()
		{
			GameObject gameObject = new GameObject("ConnectionReport");
			Object.DontDestroyOnLoad(gameObject);
			gameObject.AddComponent<SkipRemoveOnSceneSwitch>();
			ConnectionReportBehaviour connectionReportBehaviour = gameObject.AddComponent<ConnectionReportBehaviour>();
			connectionReportBehaviour.system = system;
			connectionReportBehaviour.connectionWaitTime = connectionWaitTime;
		}
	}
}
