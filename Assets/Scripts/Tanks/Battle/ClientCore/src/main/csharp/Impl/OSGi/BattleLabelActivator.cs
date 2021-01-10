using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.src.main.csharp.Impl.OSGi
{
	public class BattleLabelActivator : UnityAwareActivator<AutoCompleting>
	{
		[SerializeField]
		public GameObject BattleLabel;
	}
}
