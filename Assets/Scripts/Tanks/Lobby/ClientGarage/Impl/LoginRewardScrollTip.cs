using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardScrollTip : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect scrollRect;

		private Animator _animator;

		private void Start()
		{
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			_animator.SetBool("show", scrollRect.horizontalNormalizedPosition < 0.7f);
		}
	}
}
