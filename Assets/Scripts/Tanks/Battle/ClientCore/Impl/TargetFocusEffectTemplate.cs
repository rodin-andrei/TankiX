using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(1487238139175L)]
	public interface TargetFocusEffectTemplate : EffectBaseTemplate, Template
	{
		[AutoAdded]
		TargetFocusEffectComponent targetFocusEffect();

		[AutoAdded]
		[PersistentConfig("", false)]
		TargetFocusVerticalTargetingComponent targetFocusVerticalTargeting();

		[AutoAdded]
		[PersistentConfig("", false)]
		TargetFocusVerticalSectorTargetingComponent targetFocusVerticalSectorTargeting();

		[AutoAdded]
		[PersistentConfig("", false)]
		TargetFocusConicTargetingComponent targetFocusConicTargeting();

		[AutoAdded]
		[PersistentConfig("", false)]
		TargetFocusPelletConeComponent targetFocusPelletCone();
	}
}
