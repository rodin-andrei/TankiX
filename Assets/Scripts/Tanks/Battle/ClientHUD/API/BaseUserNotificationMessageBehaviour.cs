using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public class BaseUserNotificationMessageBehaviour : MonoBehaviour
	{
		[SerializeField]
		protected Animator animator;
		[SerializeField]
		private float lifeTime;
	}
}
