using System;
using WebSocketSharp.Net;

namespace WebSocketSharp.Server
{
	public class HttpRequestEventArgs : EventArgs
	{
		internal HttpRequestEventArgs(HttpListenerContext context)
		{
		}

	}
}
