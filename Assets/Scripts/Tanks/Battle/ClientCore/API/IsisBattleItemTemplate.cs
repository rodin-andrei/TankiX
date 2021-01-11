using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(3413384256910001471L)]
	public interface IsisBattleItemTemplate : StreamWeaponTemplate, WeaponTemplate, Template
	{
		IsisComponent isis();

		[PersistentConfig("", false)]
		DistanceAndAngleTargetEvaluatorComponent distanceAndAngleTargetEvaluator();

		[AutoAdded]
		[PersistentConfig("reticle", false)]
		ReticleTemplateComponent reticleTemplate();
	}
}
