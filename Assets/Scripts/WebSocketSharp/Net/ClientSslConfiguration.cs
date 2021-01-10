using System.Security.Authentication;

namespace WebSocketSharp.Net
{
	public class ClientSslConfiguration : SslConfiguration
	{
		public ClientSslConfiguration(string targetHost) : base(default(SslProtocols), default(bool))
		{
		}

	}
}
