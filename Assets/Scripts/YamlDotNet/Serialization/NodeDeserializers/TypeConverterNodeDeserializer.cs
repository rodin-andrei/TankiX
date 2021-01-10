using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.NodeDeserializers
{
	public class TypeConverterNodeDeserializer
	{
		public TypeConverterNodeDeserializer(IEnumerable<IYamlTypeConverter> converters)
		{
		}

	}
}
