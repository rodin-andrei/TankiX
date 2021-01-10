using System.Security.Principal;
using System.Collections.Specialized;

namespace WebSocketSharp.Net
{
	public class HttpDigestIdentity : GenericIdentity
	{
		internal HttpDigestIdentity(NameValueCollection parameters) : base(default(string))
		{
		}

	}
}
