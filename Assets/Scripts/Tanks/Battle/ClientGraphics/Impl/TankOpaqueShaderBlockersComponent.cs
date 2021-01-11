using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankOpaqueShaderBlockersComponent : Component
	{
		public HashSet<string> Blockers
		{
			get;
			set;
		}

		public TankOpaqueShaderBlockersComponent()
		{
			Blockers = new HashSet<string>();
		}
	}
}
