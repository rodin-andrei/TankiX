using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class MandatoryAssetsFirstLoadingComponent : Component
	{
		[Flags]
		public enum MandatoryRequestsState
		{
			HANGAR = 0x0,
			WEAPON_SKIN = 0x1,
			HULL_SKIN = 0x2,
			TANK_COLORING = 0x3,
			WEAPON_COLORING = 0x4,
			CONTAINER = 0x5
		}

		private MandatoryRequestsState currentRequestsState;

		private MandatoryRequestsState finishRequestsState = MandatoryRequestsState.TANK_COLORING | MandatoryRequestsState.WEAPON_COLORING;

		private List<AssetRequestComponent> assetsRequests = new List<AssetRequestComponent>();

		public bool LoadingScreenShown
		{
			get;
			set;
		}

		public void MarkAsRequested(AssetRequestComponent assetRequest, MandatoryRequestsState mandatoryRequestsState)
		{
			currentRequestsState |= mandatoryRequestsState;
			assetsRequests.Add(assetRequest);
		}

		public bool AllMandatoryAssetsAreRequested()
		{
			return currentRequestsState == finishRequestsState;
		}

		public bool IsAssetRequestMandatory(AssetRequestComponent assetRequest)
		{
			return assetsRequests.Contains(assetRequest);
		}

		public bool IsContainerRequested()
		{
			return (currentRequestsState & MandatoryRequestsState.CONTAINER) == MandatoryRequestsState.CONTAINER;
		}
	}
}
