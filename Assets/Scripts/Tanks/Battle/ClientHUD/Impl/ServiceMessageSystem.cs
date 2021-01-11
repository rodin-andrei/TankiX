using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientHUD.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class ServiceMessageSystem : ECSSystem
	{
		public class ServiceMessageVisibleNode : Node
		{
			public ServiceMessageVisibleStateComponent serviceMessageVisibleState;

			public ServiceMessageComponent serviceMessage;
		}

		public class ServiceMessageHiddenNode : Node
		{
			public ServiceMessageHiddenStateComponent serviceMessageHiddenState;

			public ServiceMessageComponent serviceMessage;
		}

		public class VisibleServiceMessageWithESMNode : Node
		{
			public ServiceMessageVisibleStateComponent serviceMessageVisibleState;

			public ServiceMessageComponent serviceMessage;

			public ServiceMessageESMComponent serviceMessageESM;
		}

		private const string VISIBLE_PROPERTY = "Visible";

		[OnEventFire]
		public void AddESMComponent(NodeAddedEvent e, SingleNode<ServiceMessageComponent> node)
		{
			ServiceMessageESMComponent serviceMessageESMComponent = new ServiceMessageESMComponent();
			EntityStateMachine esm = serviceMessageESMComponent.Esm;
			esm.AddState<ServiceMessageStates.ServiceMessageHiddenState>();
			esm.AddState<ServiceMessageStates.ServiceMessageVisibleState>();
			node.Entity.AddComponent(serviceMessageESMComponent);
			esm.ChangeState<ServiceMessageStates.ServiceMessageHiddenState>();
		}

		[OnEventFire]
		public void ShowServiceMessage(NodeAddedEvent e, ServiceMessageVisibleNode node)
		{
			node.serviceMessage.animator.SetBool("Visible", true);
		}

		[OnEventFire]
		public void HideServiceMessage(NodeAddedEvent e, ServiceMessageHiddenNode node)
		{
			node.serviceMessage.animator.SetBool("Visible", false);
		}

		[OnEventComplete]
		public void HideServiceMessageViaEvent(HideServiceMessageEvent e, VisibleServiceMessageWithESMNode serviceMessageNode)
		{
			serviceMessageNode.serviceMessageESM.Esm.ChangeState<ServiceMessageStates.ServiceMessageHiddenState>();
		}
	}
}
