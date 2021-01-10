using YamlDotNet.Serialization.TypeInspectors;

namespace YamlDotNet.Serialization
{
	public class YamlAttributeOverridesInspector : TypeInspectorSkeleton
	{
		public YamlAttributeOverridesInspector(ITypeInspector innerTypeDescriptor, YamlAttributeOverrides overrides)
		{
		}

	}
}
