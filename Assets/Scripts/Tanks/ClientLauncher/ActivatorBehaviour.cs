using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lobby.ClientUserProfile.Impl;
using Platform.Common.ClientECSCommon.src.main.csharp.Impl;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.Impl;
using Platform.Library.ClientProtocol.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Platform.Library.ClientUnityIntegration.Impl;
using Platform.System.Data.Exchange.ClientNetwork.Impl;
using Platform.System.Data.Statics.ClientConfigurator.Impl;
using Platform.System.Data.Statics.ClientYaml.Impl;
using Platform.Tool.ClientUnityLogger.Impl;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientNavigation.Impl;

namespace Tanks.ClientLauncher
{
	public class ActivatorBehaviour : ClientActivator
	{
		private readonly Type[] environmentActivators = new Type[11]
		{
			typeof(ClientLoggerActivator),
			typeof(ClientUnityLoggerActivator),
			typeof(CrashReporter),
			typeof(ClientProtocolActivator),
			typeof(YamlActivator),
			typeof(ConfigurationServiceActivator),
			typeof(EntitySystemActivator),
			typeof(ClientECSCommonActivator),
			typeof(ClientUserProfileActivator),
			typeof(ClientCoreTemplatesActivator),
			typeof(ClientUnityIntegrationActivator)
		};

		public void Awake()
		{
			UnityProfiler.Listen();
			SceneSwitcher.Clean();
			ActivateClient(MakeCoreActivators(), MakeNonCoreActivators());
		}

		private void OnApplicationQuit()
		{
			SceneSwitcher.DisposeUrlLoaders();
			WWWLoader.DisposeActiveLoaders();
			SceneSwitcher.Clean();
			Process.GetCurrentProcess().Kill();
		}

		private List<Platform.Kernel.OSGi.ClientCore.API.Activator> MakeCoreActivators()
		{
			return environmentActivators.Select((Type t) => (Platform.Kernel.OSGi.ClientCore.API.Activator)System.Activator.CreateInstance(t)).ToList();
		}

		private List<Platform.Kernel.OSGi.ClientCore.API.Activator> MakeNonCoreActivators()
		{
			Platform.Kernel.OSGi.ClientCore.API.Activator[] first = new Platform.Kernel.OSGi.ClientCore.API.Activator[1]
			{
				new ClientNetworkActivator()
			};
			return first.Concat(GetActivatorsAddedInUnityEditor()).ToList();
		}
	}
}
