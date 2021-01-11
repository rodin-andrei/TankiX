using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class AdminUserSystem : ElevatedAccessUserBaseSystem
	{
		public class AdminUserNode : SelfUserNode
		{
			public UserAdminComponent userAdmin;
		}

		[OnEventFire]
		public void InitAdminConsole(NodeAddedEvent e, AdminUserNode admin)
		{
			InitConsole(admin);
			SmartConsole.RegisterCommand("exception", "Throws NullReferenceException", base.ThrowNullPointer);
			SmartConsole.RegisterCommand("dropSupply", "dropSupply ARMOR", "Drops Supply in Current", base.DropSupply);
			SmartConsole.RegisterCommand("dropGold", "dropGold CRY", "Drops Gold in Current", base.DropGold);
			SmartConsole.RegisterCommand("blockUser", "blockUser User1 CHEATING", "Blocks user. Possible reasons: RULES_ABUSE, SABOTAGE, CHEATING, FRAUD...", base.BlockUser);
			SmartConsole.RegisterCommand("runCommand", "Run server console command", base.RunCommand);
			SmartConsole.RegisterCommand("createUserItem", "createUserItem -1816745725 3", "Create user item", base.CreateUserItem);
			SmartConsole.RegisterCommand("wipeUserItems", "wipeUserItems", "Wipe user items", base.WipeUserItems);
			SmartConsole.RegisterCommand("addBots", "addBots RED 2", "Add bots to battle", base.AddBotsToBattle);
		}
	}
}
