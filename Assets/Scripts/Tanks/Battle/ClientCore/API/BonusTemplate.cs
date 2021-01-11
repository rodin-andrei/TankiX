using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(7553964914512142106L)]
	public interface BonusTemplate : Template
	{
		[PersistentConfig("", false)]
		[AutoAdded]
		BonusConfigComponent bonusConfig();

		[PersistentConfig("", false)]
		[AutoAdded]
		BonusBoxPrefabComponent bonusBoxPrefab();

		BonusRegionGroupComponent bonusRegionGroup();
	}
}
