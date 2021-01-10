namespace YamlDotNet.Core.Events
{
	public class Scalar : NodeEvent
	{
		public Scalar(string value) : base(default(string), default(string))
		{
		}

	}
}
