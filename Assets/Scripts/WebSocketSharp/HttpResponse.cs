using WebSocketSharp.Net;
using System;
using System.Collections.Specialized;

namespace WebSocketSharp
{
	internal class HttpResponse : HttpBase
	{
		internal HttpResponse(HttpStatusCode code) : base(default(Version), default(NameValueCollection))
		{
		}

	}
}
