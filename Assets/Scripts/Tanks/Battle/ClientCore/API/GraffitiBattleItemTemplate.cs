using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientResources.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(636100801926133320L)]
	public interface GraffitiBattleItemTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("unityAsset", false)]
		AssetReferenceComponent assetReference();

		[AutoAdded]
		[PersistentConfig("", false)]
		ImageItemComponent imageItem();

		[AutoAdded]
		[PersistentConfig("", false)]
		ItemRarityComponent itemRarity();

		[AutoAdded]
		AssetRequestComponent assetRequest();
	}
}
