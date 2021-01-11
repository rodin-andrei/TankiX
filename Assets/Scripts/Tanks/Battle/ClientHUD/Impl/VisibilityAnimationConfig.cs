using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(Animator))]
	public class VisibilityAnimationConfig : MonoBehaviour
	{
		private const string VISIBLE_ANIMATION_PROP = "Visible";

		private const string INITIALLY_VISIBLE_ANIMATION_PROP = "InitiallyVisible";

		private const string NO_ANIMATION_PROP = "NoAnimation";

		[SerializeField]
		private bool initiallyVisible;

		[SerializeField]
		private bool noAnimation;

		public void OnEnable()
		{
			Animator component = GetComponent<Animator>();
			component.SetBool("NoAnimation", noAnimation);
			component.SetBool("InitiallyVisible", initiallyVisible);
			component.SetBool("Visible", initiallyVisible);
		}
	}
}
