using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageSelectorUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject hullButton;
		[SerializeField]
		private GameObject turretButton;
		[SerializeField]
		private GameObject modulesButton;
		[SerializeField]
		private GameObject visualButton;
		[SerializeField]
		private Animator hullAnimator;
		[SerializeField]
		private Animator turretAnimator;
	}
}
