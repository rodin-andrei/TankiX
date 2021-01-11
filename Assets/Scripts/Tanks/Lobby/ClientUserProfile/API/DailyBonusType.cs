using System;

namespace Tanks.Lobby.ClientUserProfile.API
{
	[Flags]
	public enum DailyBonusType
	{
		NONE = 0x0,
		CRY = 0x1,
		XCRY = 0x2,
		ENERGY = 0x4,
		CONTAINER = 0x8,
		DETAIL = 0x10
	}
}
