using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class AnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Animator animator;

		public Animator Animator
		{
			get
			{
				return animator;
			}
			set
			{
				animator = value;
			}
		}
	}
}
