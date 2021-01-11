using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using log4net;
using Platform.Library.ClientLogger.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class TcpSocketImpl : PlatformSocket
	{
		private const AddressFamily ADDRESS_FAMILY = AddressFamily.InterNetwork;

		private Socket socket;

		public bool IsConnected
		{
			get
			{
				return socket != null && socket.Connected;
			}
		}

		public int AvailableLength
		{
			get
			{
				return (socket != null) ? socket.Available : 0;
			}
		}

		public bool CanRead
		{
			get
			{
				return socket.Poll(0, SelectMode.SelectRead);
			}
		}

		public bool CanWrite
		{
			get
			{
				return socket.Poll(0, SelectMode.SelectWrite);
			}
		}

		public void ConnectAsync(string host, int port, Action completeCallback)
		{
			if (socket != null && socket.Connected)
			{
				throw new Exception("Connection in progress");
			}
			IPAddress[] hostAddresses = Dns.GetHostAddresses(host);
			IPAddress iPAddress = hostAddresses.FirstOrDefault((IPAddress addr) => addr.AddressFamily == AddressFamily.InterNetwork);
			if (iPAddress == null)
			{
				LogUnresolvableAddress(host, hostAddresses);
				throw new Exception("Unresolvable address");
			}
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
			socketAsyncEventArgs.RemoteEndPoint = new IPEndPoint(iPAddress, port);
			socketAsyncEventArgs.Completed += delegate(object sender, SocketAsyncEventArgs e)
			{
				if (e.SocketError != 0)
				{
					socket = null;
				}
				completeCallback();
			};
			socket.ConnectAsync(socketAsyncEventArgs);
		}

		private void LogUnresolvableAddress(string host, IPAddress[] addressList)
		{
			ILog logger = LoggerProvider.GetLogger(this);
			logger.ErrorFormat("Couldn't resolve host address {0} as {1} family", host, AddressFamily.InterNetwork);
			logger.ErrorFormat("Available options (Count = {0}):", addressList.Length);
			foreach (IPAddress iPAddress in addressList)
			{
				logger.ErrorFormat("{0}, address familiy - {1}", iPAddress, iPAddress.AddressFamily);
			}
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return socket.Receive(buffer, offset, count, SocketFlags.None);
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			socket.Send(buffer, offset, count, SocketFlags.None);
		}

		public void Disconnect()
		{
			socket.Close();
			socket = null;
		}
	}
}
