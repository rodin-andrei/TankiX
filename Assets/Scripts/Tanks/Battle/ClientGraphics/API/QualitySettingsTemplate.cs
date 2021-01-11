using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientProfile.API;

namespace Tanks.Battle.ClientGraphics.API
{
	[SerialVersionUID(-1455609729657L)]
	public interface QualitySettingsTemplate : Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		MaterialsSettingsComponent materialsSettings();

		[AutoAdded]
		[PersistentConfig("", false)]
		DecalSettingsComponent decalSettings();

		[AutoAdded]
		[PersistentConfig("", false)]
		WaterSettingsComponent waterSettings();

		[AutoAdded]
		[PersistentConfig("", false)]
		StreamWeaponSettingsComponent streamWeaponSettings();

		[AutoAdded]
		[PersistentConfig("", false)]
		SupplyEffectSettingsComponent supplyEffectSettings();

		[AutoAdded]
		[PersistentConfig("", false)]
		FeedbackGraphicsRestrictionsComponent feedbackGraphicsRestrictions();
	}
}
