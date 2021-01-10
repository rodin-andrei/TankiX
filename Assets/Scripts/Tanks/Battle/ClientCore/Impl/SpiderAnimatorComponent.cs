using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SpiderAnimatorComponent : MonoBehaviour
	{
		[SerializeField]
		private bool runiningOnStart;
		[SerializeField]
		private string activationClipName;
		[SerializeField]
		private string runClipName;
		[SerializeField]
		private float mass;
		[SerializeField]
		private float runAnimationSpeed;
		[SerializeField]
		private float runForce;
		[SerializeField]
		private float rotationSpeed;
		[SerializeField]
		private float maximalRuningSpeed;
		[SerializeField]
		private float runingDrag;
		[SerializeField]
		private string jumpClipName;
		[SerializeField]
		private float jumpForce;
		[SerializeField]
		private float maxDepenetrationVelocity;
		[SerializeField]
		private string idleClipName;
	}
}
