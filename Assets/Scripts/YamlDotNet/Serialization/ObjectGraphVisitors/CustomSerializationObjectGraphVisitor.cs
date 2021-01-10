using YamlDotNet.Core;
using YamlDotNet.Serialization;
using System.Collections.Generic;

namespace YamlDotNet.Serialization.ObjectGraphVisitors
{
	public class CustomSerializationObjectGraphVisitor : ChainedObjectGraphVisitor
	{
		public CustomSerializationObjectGraphVisitor(IEmitter emitter, IObjectGraphVisitor nextVisitor, IEnumerable<IYamlTypeConverter> typeConverters) : base(default(IObjectGraphVisitor))
		{
		}

	}
}
