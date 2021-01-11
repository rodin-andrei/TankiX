using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class NameplateTeamColorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Color redTeamColor;

		public Color blueTeamColor;

		public Color dmColor;
	}
}
