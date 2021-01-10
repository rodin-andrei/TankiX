using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.TypeInspectors
{
	public class CachedTypeInspector : TypeInspectorSkeleton
	{
		public CachedTypeInspector(ITypeInspector innerTypeDescriptor)
		{
		}

	}
}
