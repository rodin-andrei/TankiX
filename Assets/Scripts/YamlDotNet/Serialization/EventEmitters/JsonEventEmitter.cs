using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.EventEmitters
{
	public class JsonEventEmitter : ChainedEventEmitter
	{
		public JsonEventEmitter(IEventEmitter nextEmitter) : base(default(IEventEmitter))
		{
		}

	}
}
