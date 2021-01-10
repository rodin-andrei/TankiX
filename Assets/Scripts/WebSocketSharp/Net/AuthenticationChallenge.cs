using System.Collections.Specialized;

namespace WebSocketSharp.Net
{
	internal class AuthenticationChallenge : AuthenticationBase
	{
		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm) : base(default(AuthenticationSchemes), default(NameValueCollection))
		{
		}

	}
}
