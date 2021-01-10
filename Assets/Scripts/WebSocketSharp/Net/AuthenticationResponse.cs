using System.Collections.Specialized;

namespace WebSocketSharp.Net
{
	internal class AuthenticationResponse : AuthenticationBase
	{
		internal AuthenticationResponse(NetworkCredential credentials) : base(default(AuthenticationSchemes), default(NameValueCollection))
		{
		}

	}
}
