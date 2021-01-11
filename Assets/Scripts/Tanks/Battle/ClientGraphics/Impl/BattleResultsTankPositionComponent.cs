using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(636451471987331092L)]
	public class BattleResultsTankPositionComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public string hullGuid;

		public string weaponGuid;

		public string paintGuid;

		public string coverGuid;
	}
}
