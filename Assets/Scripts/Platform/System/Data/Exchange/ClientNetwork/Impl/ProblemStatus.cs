namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public enum ProblemStatus
	{
		ClosedByClient,
		ClosedByServer,
		SocketMethodInvokeError,
		ReceiveError,
		DecodePacketError,
		DecodeCommandError,
		EncodeError,
		SendError,
		ExecuteCommandError
	}
}
