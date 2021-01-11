using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	[JoinBy(typeof(BonusRegionGroupComponent))]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class JoinByBonusRegion : Attribute
	{
	}
}
