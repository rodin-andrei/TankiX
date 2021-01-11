using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class BuildBattleResultTankEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public string HullGuid
		{
			get;
			set;
		}

		public string WeaponGuid
		{
			get;
			set;
		}

		public string PaintGuid
		{
			get;
			set;
		}

		public string CoverGuid
		{
			get;
			set;
		}

		public bool BestPlayerScreen
		{
			get;
			set;
		}

		public RenderTexture tankPreviewRenderTexture
		{
			get;
			set;
		}
	}
}
