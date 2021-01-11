using System;
using System.IO;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class WebSocketImpl : PlatformSocket
	{
		private WebSocket socket;

		private Action completeCallback;

		public bool IsConnected
		{
			get
			{
				return socket != null && socket.IsConnected;
			}
		}

		public int AvailableLength
		{
			get
			{
				return (socket != null) ? socket.AvailableLength : 0;
			}
		}

		public bool CanRead
		{
			get
			{
				return AvailableLength > 0;
			}
		}

		public bool CanWrite
		{
			get
			{
				return IsConnected;
			}
		}

		public void ConnectAsync(string host, int port, Action completeCallback)
		{
			if (socket != null && socket.IsConnected)
			{
				throw new Exception("Connection in progress");
			}
			this.completeCallback = completeCallback;
			socket = new WebSocket();
			socket.ConnectAsync(string.Format("ws://{0}:{1}/websocket", host, port), OnComplete);
		}

		private void OnComplete()
		{
			if (!socket.IsConnected)
			{
				socket = null;
			}
			completeCallback();
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			int result = socket.Receive(buffer);
			if (socket.GetError() != null)
			{
				throw new IOException(socket.GetError());
			}
			return result;
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			byte[] array = new byte[count];
			Buffer.BlockCopy(buffer, 0, array, 0, count);
			socket.Send(array);
			if (socket.GetError() != null)
			{
				throw new IOException(socket.GetError());
			}
		}

		public void Disconnect()
		{
			socket.Close();
			socket = null;
		}
	}
}
