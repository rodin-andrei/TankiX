using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientHUD.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class UpsideDownHUDSystem : ECSSystem
	{
		public class UpsideDownSelfTankNode : Node
		{
			public SelfTankComponent selfTank;

			public UpsideDownTankComponent upsideDownTank;
		}

		public class UpsideDownServiceMessageNode : Node
		{
			public UpsideDownServiceMessageComponent upsideDownServiceMessage;

			public ServiceMessageESMComponent serviceMessageESM;

			public UpsideDownMessageComponent upsideDownMessage;

			public ServiceMessageComponent serviceMessage;
		}

		public class UpsideDownServiceMessageVisibleNode : Node
		{
			public UpsideDownServiceMessageComponent upsideDownServiceMessage;

			public ServiceMessageESMComponent serviceMessageESM;

			public UpsideDownMessageComponent upsideDownMessage;

			public ServiceMessageComponent serviceMessage;

			public ServiceMessageVisibleStateComponent serviceMessageVisibleState;
		}

		public class UpsideDownServiceMessageHiddenNode : Node
		{
			public UpsideDownServiceMessageComponent upsideDownServiceMessage;

			public ServiceMessageESMComponent serviceMessageESM;

			public UpsideDownMessageComponent upsideDownMessage;

			public ServiceMessageComponent serviceMessage;

			public ServiceMessageHiddenStateComponent serviceMessageHiddenState;
		}

		public class UserNode : Node
		{
			public UserComponent user;

			public UserGroupComponent userGroup;

			public UserRankComponent userRank;
		}

		public class ShowMessageEvent : Event
		{
		}

		[OnEventFire]
		public void LocalizeUpsideDownServiceMessage(NodeAddedEvent e, UpsideDownServiceMessageNode serviceMessage)
		{
			serviceMessage.serviceMessage.MessageText.text = serviceMessage.upsideDownMessage.Message;
		}

		[OnEventFire]
		public void CheckPauseBeforeServiceMessageShown(NodeAddedEvent e, UpsideDownSelfTankNode tank, [JoinByUser] UserNode user, [JoinByUser] SingleNode<UpsideDownConfigComponent> config, [JoinAll] UpsideDownServiceMessageHiddenNode serviceMessage)
		{
			if (user.userRank.Rank <= config.component.MaxRankForMessage)
			{
				NewEvent<ShowMessageEvent>().Attach(tank).ScheduleDelayed(config.component.DetectionPauseSec);
			}
		}

		[OnEventFire]
		public void ShowMessage(ShowMessageEvent e, UpsideDownSelfTankNode tank, [JoinAll] UpsideDownServiceMessageHiddenNode serviceMessage, [JoinAll] ICollection<SingleNode<ServiceMessageVisibleStateComponent>> visibleMessages)
		{
			if (visibleMessages.Count <= 0)
			{
				serviceMessage.serviceMessageESM.Esm.ChangeState<ServiceMessageStates.ServiceMessageVisibleState>();
			}
		}

		[OnEventFire]
		public void HideUpsideDownMessage(NodeRemoveEvent e, UpsideDownSelfTankNode tank, [JoinAll] UpsideDownServiceMessageNode serviceMessage)
		{
			serviceMessage.serviceMessageESM.Esm.ChangeState<ServiceMessageStates.ServiceMessageHiddenState>();
		}
	}
}
