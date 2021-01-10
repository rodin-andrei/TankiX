using System;

namespace Steamworks
{
	public struct MicroTxnAuthorizationResponse_t
	{
		public uint m_unAppID;
		public ulong m_ulOrderID;
		public byte m_bAuthorized;
	}
}
