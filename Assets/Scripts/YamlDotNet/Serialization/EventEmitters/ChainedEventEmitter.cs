using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.EventEmitters
{
	public class ChainedEventEmitter
	{
		protected ChainedEventEmitter(IEventEmitter nextEmitter)
		{
		}

	}
}
