using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.System.Data.Exchange.ClientNetwork.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class InviteInputValidationSystem : ECSSystem
	{
		public class InviteInputFieldAcceptableNode : Node
		{
			public InviteInputFieldComponent inviteInputField;

			public InputFieldComponent inputField;

			public InteractivityPrerequisiteESMComponent interactivityPrerequisiteESM;

			public AcceptableStateComponent acceptableState;
		}

		public class InviteInputFieldNotAcceptableNode : Node
		{
			public InviteInputFieldComponent inviteInputField;

			public InputFieldComponent inputField;

			public InteractivityPrerequisiteESMComponent interactivityPrerequisiteESM;

			public NotAcceptableStateComponent notAcceptableState;
		}

		public class InputFieldInvalidStateNode : Node
		{
			public InviteInputFieldComponent inviteInputField;

			public InputFieldInvalidStateComponent inputFieldInvalidState;

			public ESMComponent esm;
		}

		public class InviteInputFieldNode : Node
		{
			public InviteInputFieldComponent inviteInputField;

			public InputFieldComponent inputField;

			public ESMComponent esm;
		}

		public class InviteScreenNode : Node
		{
			public InviteScreenComponent inviteScreen;

			public InviteScreenTextComponent inviteScreenText;
		}

		public class InvalidStateNode : Node
		{
			public InviteInputFieldComponent inviteInputField;

			public InputFieldInvalidStateComponent inputFieldInvalidState;

			public InteractivityPrerequisiteESMComponent interactivityPrerequisiteESM;
		}

		[OnEventFire]
		public void ShowInviteDoesNotExistHint(InviteDoesNotExistEvent e, SingleNode<ClientSessionComponent> clientSession, [JoinAll] InviteInputFieldNode inviteNode, [JoinAll] InviteScreenNode inviteScreenNode)
		{
			inviteNode.esm.Esm.ChangeState<InputFieldStates.InvalidState>();
			inviteNode.inputField.ErrorMessage = inviteScreenNode.inviteScreenText.Error;
		}

		[OnEventFire]
		public void SwitchToNotAcceptableState(InputFieldValueChangedEvent e, InviteInputFieldAcceptableNode inputField)
		{
			if (inputField.inputField.Input.Length == 0)
			{
				inputField.interactivityPrerequisiteESM.Esm.ChangeState<InteractivityPrerequisiteStates.NotAcceptableState>();
			}
		}

		[OnEventFire]
		public void SwitchToNotAcceptableState(NodeAddedEvent e, InvalidStateNode inputField)
		{
			inputField.interactivityPrerequisiteESM.Esm.ChangeState<InteractivityPrerequisiteStates.NotAcceptableState>();
		}

		[OnEventFire]
		public void SwitchToAcceptableState(InputFieldValueChangedEvent e, InviteInputFieldNotAcceptableNode inputField)
		{
			if (inputField.inputField.Input.Length > 0)
			{
				inputField.interactivityPrerequisiteESM.Esm.ChangeState<InteractivityPrerequisiteStates.AcceptableState>();
			}
		}

		[OnEventFire]
		public void SwitchInputToNormalState(InputFieldValueChangedEvent e, InputFieldInvalidStateNode inputField)
		{
			inputField.esm.Esm.ChangeState<InputFieldStates.NormalState>();
		}
	}
}
