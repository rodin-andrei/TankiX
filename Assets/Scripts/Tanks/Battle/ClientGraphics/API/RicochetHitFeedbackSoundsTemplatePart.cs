using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	[TemplatePart]
	public interface RicochetHitFeedbackSoundsTemplatePart : RicochetBattleItemTemplate, DiscreteWeaponEnergyTemplate, DiscreteWeaponTemplate, WeaponTemplate, Template
	{
		[AutoAdded]
		[PersistentConfig("", false)]
		HitFeedbackSoundsPlayingSettingsComponent hitFeedbackSoundsPlayingSettings();
	}
}
