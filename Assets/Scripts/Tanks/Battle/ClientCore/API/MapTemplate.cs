using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientResources.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(-5630755063511713066L)]
	public interface MapTemplate : Template
	{
		MapComponent map();

		[AutoAdded]
		[PersistentConfig("", false)]
		DescriptionItemComponent descriptionItem();

		[AutoAdded]
		[PersistentConfig("", false)]
		AssetReferenceComponent assetReference();

		[AutoAdded]
		[PersistentConfig("", false)]
		MapPreviewComponent mapPreview();

		[AutoAdded]
		[PersistentConfig("", false)]
		MapLoadPreviewComponent mapLoadPreview();

		[AutoAdded]
		[PersistentConfig("", false)]
		FlavorListComponent flavorList();

		AssetRequestComponent assetRequest();

		MapInstanceComponent mapInstance();

		[AutoAdded]
		[PersistentConfig("", false)]
		MapModeRestrictionComponent mapModeRestriction();
	}
}
