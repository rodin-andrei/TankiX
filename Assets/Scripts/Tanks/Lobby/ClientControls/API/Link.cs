using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class Link : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Button button;

		public void Awake()
		{
			button.onClick.AddListener(OnClick);
		}

		public void OnClick()
		{
			button.onClick.RemoveListener(OnClick);
			animator.SetBool("Activated", true);
		}
	}
}
