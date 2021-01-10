using UnityEngine;

namespace tanks.modules.lobby.ClientGarage.Scripts.Impl.UI
{
	public class TwoStateBoolAnimatorBehavior : MonoBehaviour
	{
		[SerializeField]
		private Animator _targetAnimator;
		[SerializeField]
		private string _boolTriggerName;
	}
}
