using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(1485165044938L)]
	public interface ModuleItemTemplate : GarageItemTemplate, Template
	{
		[AutoAdded]
		ModuleItemComponent moduleItem();

		[AutoAdded]
		[PersistentConfig("", false)]
		ItemIconComponent itemIcon();

		[AutoAdded]
		[PersistentConfig("", false)]
		ItemBigIconComponent itemBigIcon();

		[AutoAdded]
		[PersistentConfig("", false)]
		OrderItemComponent orderItem();

		[AutoAdded]
		[PersistentConfig("", true)]
		ModuleEffectsComponent moduleEffects();
	}
}
