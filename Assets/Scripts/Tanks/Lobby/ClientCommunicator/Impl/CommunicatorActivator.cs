using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientCommunicator.API;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class CommunicatorActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Activator
	{
		[Inject]
		public static TemplateRegistry TemplateRegistry
		{
			get;
			set;
		}

		public void RegisterSystemsAndTemplates()
		{
			ECSBehaviour.EngineService.RegisterSystem(new ChatSystem());
			ECSBehaviour.EngineService.RegisterSystem(new ChatScreenSystem());
			ECSBehaviour.EngineService.RegisterSystem(new SendMessageSystem());
			ECSBehaviour.EngineService.RegisterSystem(new ReceiveMessageSystem());
			ECSBehaviour.EngineService.RegisterSystem(new LobbyChatUISystem());
			ECSBehaviour.EngineService.RegisterSystem(new CreateChatSystem());
			TemplateRegistry.Register<ChatTemplate>();
			TemplateRegistry.Register<GeneralChatTemplate>();
			TemplateRegistry.Register<PersonalChatTemplate>();
			TemplateRegistry.Register<CustomChatTemplate>();
			TemplateRegistry.Register<SquadChatTemplate>();
		}
	}
}
