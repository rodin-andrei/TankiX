using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.EventEmitters
{
	public class TypeAssigningEventEmitter : ChainedEventEmitter
	{
		public TypeAssigningEventEmitter(IEventEmitter nextEmitter, bool assignTypeWhenDifferent) : base(default(IEventEmitter))
		{
		}

	}
}
