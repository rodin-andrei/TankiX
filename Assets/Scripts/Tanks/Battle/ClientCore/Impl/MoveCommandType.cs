using System;

namespace Tanks.Battle.ClientCore.Impl
{
	[Flags]
	public enum MoveCommandType
	{
		NONE = 0x0,
		TANK = 0x1,
		WEAPON = 0x2,
		FULL = 0x3
	}
}
