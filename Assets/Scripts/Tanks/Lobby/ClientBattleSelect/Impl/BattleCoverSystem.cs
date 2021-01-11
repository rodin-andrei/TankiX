using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleCoverSystem : ECSSystem
	{
		public class CoverNode : Node
		{
			public BattleScreenCoverComponent battleScreenCover;
		}

		public class ShowCoverEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
		{
		}

		private int updateBgAtFrame = -1;

		[OnEventFire]
		public void DelayShowBackgroundAndLoadHangar(NodeAddedEvent e, SingleNode<RoundRestartingStateComponent> round, [JoinAll] CoverNode cover)
		{
			NewEvent<ShowCoverEvent>().Attach(cover).ScheduleDelayed(3f);
		}

		[OnEventFire]
		public void ShowBackground(NodeAddedEvent e, SingleNode<BattleResultsScreenPartComponent> part)
		{
			UpgradeBackgroundWithDelay();
		}

		[OnEventFire]
		public void HideBackground(NodeRemoveEvent e, SingleNode<BattleResultsScreenPartComponent> part)
		{
			UpgradeBackgroundWithDelay();
		}

		private void UpgradeBackgroundWithDelay()
		{
			updateBgAtFrame = Time.frameCount + 1;
		}

		private void UpgradeBackground(BattleScreenCoverComponent cover)
		{
			bool show = SelectAll<SingleNode<BattleResultsScreenPartComponent>>().Any();
			ShowCover(cover, show);
		}

		[OnEventFire]
		public void Show(ShowCoverEvent e, CoverNode cover)
		{
			ShowCover(cover.battleScreenCover, true);
		}

		[OnEventFire]
		public void HideBackground(UpdateEvent e, CoverNode cover)
		{
			if (Time.frameCount == updateBgAtFrame)
			{
				UpgradeBackground(cover.battleScreenCover);
			}
		}

		private void ShowCover(BattleScreenCoverComponent cover, bool show)
		{
			cover.battleCoverAnimator.SetBool("show", show);
		}
	}
}
