using System.Text.RegularExpressions;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Platform.System.Data.Statics.ClientYaml.API;
using Platform.System.Data.Statics.ClientYaml.Impl;
using UnityEngine;
using YamlDotNet.Serialization;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class FromConfigBehaviour : ECSBehaviour
	{
		[HideInInspector]
		[SerializeField]
		private string configPath;

		[HideInInspector]
		[SerializeField]
		private string yamlKey;

		private static Regex namespaceToConfigPath = new Regex("(\\.Impl.*)|(\\.API.*)|(Client)", RegexOptions.IgnoreCase);

		private static Regex specialNames = new Regex("(Component)|(Text)|(Texts)|(Localization)|(LocalizedStrings)", RegexOptions.IgnoreCase);

		private static readonly INamingConvention naming = new PascalToCamelCaseNamingConvertion();

		[Inject]
		public static ConfigurationService ConfigurationService
		{
			get;
			set;
		}

		public virtual string ConfigPath
		{
			get
			{
				return (!IsStaticConfigPath) ? configPath : NamespaceToConfigPath();
			}
		}

		public virtual string YamlKey
		{
			get
			{
				return (!IsStaticYamlKey) ? yamlKey : naming.Apply(specialNames.Replace(GetType().Name, string.Empty));
			}
		}

		public virtual bool IsStaticYamlKey
		{
			get
			{
				return true;
			}
		}

		public virtual bool IsStaticConfigPath
		{
			get
			{
				return true;
			}
		}

		protected virtual string GetRelativeConfigPath()
		{
			return string.Empty;
		}

		private string NamespaceToConfigPath()
		{
			return namespaceToConfigPath.Replace(GetType().Namespace, string.Empty).Replace(".", "/").ToLower() + GetRelativeConfigPath();
		}

		protected virtual void Awake()
		{
			GetValuesFromConfig();
		}

		private void GetValuesFromConfig()
		{
			YamlNode childNode = ConfigurationService.GetConfig(ConfigPath).GetChildNode(YamlKey);
			UnityUtil.SetPropertiesFromYamlNode(this, childNode, new PascalToCamelCaseNamingConvertion());
		}
	}
}
