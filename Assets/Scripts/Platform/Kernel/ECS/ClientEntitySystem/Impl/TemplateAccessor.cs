using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Platform.System.Data.Statics.ClientYaml.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class TemplateAccessor
	{
		private readonly TemplateDescription templateDescription;

		public string configPath;

		private readonly YamlNode yamlNode;

		[Inject]
		public static ConfigurationService ConfiguratorService
		{
			get;
			set;
		}

		public virtual TemplateDescription TemplateDescription
		{
			get
			{
				return templateDescription;
			}
		}

		public YamlNode YamlNode
		{
			get
			{
				return (!HasConfigPath()) ? yamlNode : ConfiguratorService.GetConfig(ConfigPath);
			}
		}

		public string ConfigPath
		{
			get
			{
				if (!HasConfigPath())
				{
					throw new CannotAccessPathForTemplate(TemplateDescription.TemplateClass);
				}
				return configPath;
			}
			set
			{
				configPath = value;
			}
		}

		public TemplateAccessor(TemplateDescription templateDescription, string configPath)
			: this(templateDescription)
		{
			this.configPath = configPath;
		}

		public TemplateAccessor(TemplateDescription templateDescription, YamlNode yamlNode)
			: this(templateDescription)
		{
			this.yamlNode = yamlNode;
		}

		private TemplateAccessor(TemplateDescription templateDescription)
		{
			this.templateDescription = templateDescription;
		}

		public bool HasConfigPath()
		{
			return !string.IsNullOrEmpty(configPath);
		}
	}
}
