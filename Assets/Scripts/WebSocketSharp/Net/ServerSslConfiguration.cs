using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

namespace WebSocketSharp.Net
{
	public class ServerSslConfiguration : SslConfiguration
	{
		public ServerSslConfiguration(X509Certificate2 serverCertificate) : base(default(SslProtocols), default(bool))
		{
		}

	}
}
