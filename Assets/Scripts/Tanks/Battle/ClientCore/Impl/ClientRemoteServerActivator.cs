using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientResources.Impl;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Platform.Library.ClientUnityIntegration.Impl;
using Platform.System.Data.Exchange.ClientNetwork.API;
using Platform.System.Data.Exchange.ClientNetwork.Impl;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ClientRemoteServerActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Platform.Kernel.OSGi.ClientCore.API.Activator
	{
		private NetworkServiceImpl networkService;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		[Inject]
		public static Protocol Protocol
		{
			get;
			set;
		}

		[Inject]
		public static ConfigurationService ConfigurationService
		{
			get;
			set;
		}

		[Inject]
		public static ServerTimeService ServerTimeService
		{
			get;
			set;
		}

		public void RegisterSystemsAndTemplates()
		{
			EngineService.RegisterSystem(new TimeSyncSystem());
			EngineService.RegisterSystem(new TankMovementReceiverSystem());
			EngineService.RegisterSystem(new TankMovementSenderSystem());
			EngineService.RegisterSystem(new WallhackSystem());
			EngineService.RegisterSystem(new FlyingTankSystem());
			EngineService.RegisterSystem(new TankAutopilotControllerSystem());
			EngineService.RegisterSystem(new TankAutopilotWeaponControllerSystem());
			EngineService.RegisterSystem(new TankAutopilotNavigationSystem());
		}

		protected override void Activate()
		{
			TimeServiceImpl timeServiceImpl = new TimeServiceImpl();
			ServiceRegistry.Current.RegisterService((TimeService)timeServiceImpl);
			ServerTimeService.OnInitServerTime += timeServiceImpl.InitServerTime;
			Protocol.RegisterCodecForType<Movement>(new MovementCodec());
			Protocol.RegisterCodecForType<MoveCommand>(new MoveCommandCodec());
			Protocol.RegisterCodecForType<Date>(new DateCodec());
			string host = InitConfiguration.Config.Host;
			string[] source = new string[1]
			{
				InitConfiguration.Config.AcceptorPort
			};
			PrefetchSocketPolicy(host);
			ServerConnectionBehaviour serverConnectionBehaviour = base.gameObject.AddComponent<ServerConnectionBehaviour>();
			serverConnectionBehaviour.OpenConnection(host, ((IEnumerable<string>)source).Select((Func<string, int>)Convert.ToInt32).ToArray());
		}

		private void PrefetchSocketPolicy(string hostName)
		{
		}
	}
}
