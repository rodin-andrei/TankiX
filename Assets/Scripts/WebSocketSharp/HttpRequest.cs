using System;
using System.Collections.Specialized;

namespace WebSocketSharp
{
	internal class HttpRequest : HttpBase
	{
		internal HttpRequest(string method, string uri) : base(default(Version), default(NameValueCollection))
		{
		}

	}
}
