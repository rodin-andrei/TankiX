using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientProtocol.Impl;
using Platform.System.Data.Exchange.ClientNetwork.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class NetworkServiceImpl : NetworkService
	{
		private const int BUFFER_SIZE = 51200;

		private byte[] readBuffer = new byte[51200];

		private readonly PlatformSocket socket;

		private readonly Queue<CommandPacket> packetQueue = new Queue<CommandPacket>();

		private readonly ProtocolAdapter protocolAdapter;

		private readonly ILog log;

		private bool infoEnabled;

		private CommandPacket delayedCommands;

		private long delayUntilTime;

		private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		[Inject]
		public static ClientNetworkInstancesCache ClientNetworkInstancesCache
		{
			get;
			set;
		}

		[Inject]
		public static ClientProtocolInstancesCache ClientProtocolInstancesCache
		{
			get;
			set;
		}

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public bool IsConnected
		{
			get
			{
				return socket.IsConnected;
			}
		}

		public bool IsDecodeState
		{
			get;
			private set;
		}

		public bool SkipThrowOnCommandExecuteException
		{
			get;
			set;
		}

		public bool SplitShareCommand
		{
			set
			{
				protocolAdapter.SplitShareCommand = value;
			}
		}

		public event Action<Command, Exception> OnCommandExecuteException;

		public NetworkServiceImpl(ProtocolAdapter protocolAdapter, PlatformSocket socket)
		{
			log = LoggerProvider.GetLogger(this);
			this.protocolAdapter = protocolAdapter;
			this.socket = socket;
		}

		public void ConnectAsync(string host, int port, Action completeCallback)
		{
			socket.ConnectAsync(host, port, completeCallback);
		}

		public void ReadAndExecuteCommands(long maxTimeMillis, long networkMaxDelayTime)
		{
			infoEnabled = log.IsInfoEnabled;
			long num = CurrentTimeMillis();
			long timeToStop = ((maxTimeMillis <= 0) ? long.MaxValue : (num + maxTimeMillis));
			if (!ExecuteDelayedCommands(num, timeToStop) || !IsConnected || !socket.CanRead)
			{
				return;
			}
			if (socket.AvailableLength == 0)
			{
				Disconnect(ProblemStatus.ClosedByServer);
				return;
			}
			int num2;
			try
			{
				int availableLength = socket.AvailableLength;
				readBuffer = BufferUtils.GetBufferWithValidSize(readBuffer, availableLength);
				num2 = socket.Read(readBuffer, 0, availableLength);
				if (infoEnabled)
				{
					log.InfoFormat("Received {0} byte(s).", num2);
				}
			}
			catch (IOException e)
			{
				OnSocketProblem(ProblemStatus.ReceiveError, e);
				return;
			}
			if (infoEnabled)
			{
				log.Info("Processing new commands");
			}
			try
			{
				protocolAdapter.AddChunk(readBuffer, num2);
				CommandPacket commandPacket;
				while (TryDecode(out commandPacket))
				{
					CommandPacket newPacket;
					bool flag = ExecuteCommands(commandPacket, timeToStop, out newPacket);
					protocolAdapter.FinalizeDecodedCommandPacket(commandPacket);
					if (!flag)
					{
						if (delayedCommands == null)
						{
							delayedCommands = newPacket;
							delayUntilTime = num + networkMaxDelayTime;
						}
						else
						{
							delayedCommands.Append(newPacket);
							protocolAdapter.FinalizeDecodedCommandPacket(newPacket);
						}
					}
				}
			}
			catch (Exception e2)
			{
				OnSocketProblem(ProblemStatus.DecodePacketError, e2);
			}
		}

		private bool ExecuteCommands(CommandPacket packet, long timeToStop, out CommandPacket newPacket)
		{
			int i = 0;
			for (int count = packet.Commands.Count; i < count; i++)
			{
				if (CurrentTimeMillis() >= timeToStop)
				{
					if (infoEnabled)
					{
						log.InfoFormat("Delay execute {0} commands", count - i);
					}
					List<Command> commandCollection = ClientNetworkInstancesCache.GetCommandCollection();
					newPacket = ClientNetworkInstancesCache.GetCommandPacketInstance(commandCollection);
					for (int j = i; j < count; j++)
					{
						commandCollection.Add(packet.Commands[j]);
					}
					return false;
				}
				Command command = packet.Commands[i];
				try
				{
					if (infoEnabled)
					{
						log.InfoFormat("Execute {0}", command);
					}
					command.Execute(EngineService.Engine);
				}
				catch (Exception ex)
				{
					if (this.OnCommandExecuteException != null)
					{
						this.OnCommandExecuteException(command, ex);
					}
					if (!SkipThrowOnCommandExecuteException)
					{
						OnSocketProblem(ProblemStatus.ExecuteCommandError, ex);
					}
				}
				finally
				{
				}
			}
			newPacket = null;
			return true;
		}

		private bool ExecuteDelayedCommands(long now, long timeToStop)
		{
			if (delayedCommands != null)
			{
				if (now > delayUntilTime)
				{
					if (infoEnabled)
					{
						log.Info("Processing ALL delayed commands");
					}
					timeToStop = long.MaxValue;
				}
				else if (infoEnabled)
				{
					log.Info("Processing delayed commands");
				}
				try
				{
					CommandPacket newPacket;
					if (!ExecuteCommands(delayedCommands, timeToStop, out newPacket))
					{
						protocolAdapter.FinalizeDecodedCommandPacket(delayedCommands);
						delayedCommands = newPacket;
						return false;
					}
					protocolAdapter.FinalizeDecodedCommandPacket(delayedCommands);
					delayedCommands = null;
				}
				catch (Exception e)
				{
					OnSocketProblem(ProblemStatus.DecodePacketError, e);
				}
			}
			return true;
		}

		private bool TryDecode(out CommandPacket commandPacket)
		{
			try
			{
				IsDecodeState = true;
				return protocolAdapter.TryDecode(out commandPacket);
			}
			finally
			{
				IsDecodeState = false;
			}
		}

		public void WriteCommands()
		{
			if (!IsConnected || !socket.CanWrite)
			{
				return;
			}
			while (packetQueue.Count != 0)
			{
				CommandPacket commandPacket = packetQueue.Dequeue();
				MemoryStreamData memoryStreamData;
				try
				{
					memoryStreamData = protocolAdapter.Encode(commandPacket);
				}
				catch (Exception ex)
				{
					log.DebugFormat("OnSocketProblem {0}", ex.Message);
					OnSocketProblem(ProblemStatus.EncodeError, ex);
					return;
				}
				finally
				{
					ClientNetworkInstancesCache.ReleaseCommandPacketWithCommandsCollection(commandPacket);
				}
				try
				{
					if (infoEnabled)
					{
						log.DebugFormat("WriteCommands {0}", memoryStreamData.Length);
					}
					socket.Write(memoryStreamData.GetBuffer(), 0, (int)memoryStreamData.Length);
				}
				catch (IOException e)
				{
					OnSocketProblem(ProblemStatus.SendError, e);
				}
				finally
				{
					ClientProtocolInstancesCache.ReleaseMemoryStreamData(memoryStreamData);
				}
			}
		}

		private void OnSocketProblem(ProblemStatus status, Exception e)
		{
			DisconnectOnProblemIfNeeded(status);
			throw new NetworkException("OnSocketProblem " + status, e);
		}

		private static string GetMessage(Exception e)
		{
			if (e is TargetInvocationException && e.InnerException != null)
			{
				return e.InnerException.GetType().Name + ": " + e.InnerException.Message;
			}
			return e.Message;
		}

		private void DisconnectOnProblemIfNeeded(ProblemStatus status)
		{
			if (status == ProblemStatus.SocketMethodInvokeError || status == ProblemStatus.SendError || status == ProblemStatus.ReceiveError)
			{
				Disconnect(status);
			}
		}

		public void SendCommandPacket(CommandPacket packet)
		{
			packetQueue.Enqueue(packet);
		}

		public void Disconnect()
		{
			Disconnect(ProblemStatus.ClosedByClient);
		}

		protected void Disconnect(ProblemStatus status)
		{
			log.InfoFormat("Disconnect by {0}.", status);
			if (!IsConnected)
			{
				log.Warn("Closing not connected socket.");
				return;
			}
			try
			{
				socket.Disconnect();
				log.Debug("DISCONNECTED");
			}
			catch (ObjectDisposedException exception)
			{
				log.Fatal("Disconnect error.", exception);
			}
		}

		private static long CurrentTimeMillis()
		{
			return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
		}
	}
}
