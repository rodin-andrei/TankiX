using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.TypeInspectors
{
	public class NamingConventionTypeInspector : TypeInspectorSkeleton
	{
		public NamingConventionTypeInspector(ITypeInspector innerTypeDescriptor, INamingConvention namingConvention)
		{
		}

	}
}
