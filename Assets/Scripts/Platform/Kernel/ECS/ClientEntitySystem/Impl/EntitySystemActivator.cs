using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientYaml.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EntitySystemActivator : DefaultActivator<AutoCompleting>
	{
		[Inject]
		public static YamlService YamlService
		{
			get;
			set;
		}

		protected override void Activate()
		{
			TemplateRegistryImpl templateRegistryImpl = new TemplateRegistryImpl();
			ServiceRegistry.Current.RegisterService((TemplateRegistry)templateRegistryImpl);
			ServiceRegistry.Current.RegisterService((ConfigEntityLoader)new ConfigEntityLoaderImpl());
			ComponentBitIdRegistryImpl componentBitIdRegistryImpl = new ComponentBitIdRegistryImpl();
			ServiceRegistry.Current.RegisterService((ComponentBitIdRegistry)componentBitIdRegistryImpl);
			HandlerCollector handlerCollector = new HandlerCollector();
			EventMaker eventMaker = new EventMaker(handlerCollector);
			ServiceRegistry.Current.RegisterService((NodeDescriptionRegistry)new NodeDescriptionRegistryImpl());
			EngineServiceImpl engineServiceImpl = new EngineServiceImpl(templateRegistryImpl, handlerCollector, eventMaker, componentBitIdRegistryImpl);
			ServiceRegistry.Current.RegisterService((EngineService)engineServiceImpl);
			ServiceRegistry.Current.RegisterService((EngineServiceInternal)engineServiceImpl);
			ServiceRegistry.Current.RegisterService((TemplateRegistry)templateRegistryImpl);
			ServiceRegistry.Current.RegisterService((GroupRegistry)new GroupRegistryImpl());
			engineServiceImpl.HandlerCollector.AddHandlerListener(componentBitIdRegistryImpl);
			YamlService.RegisterConverter(new EntityYamlConverter(engineServiceImpl));
			YamlService.RegisterConverter(new TemplateDescriptionYamlConverter(templateRegistryImpl));
			ServiceRegistry.Current.RegisterService(new FlowInstancesCache());
		}
	}
}
