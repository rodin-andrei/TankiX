using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class NewHolyshieldEffectComponent : BehaviourComponent
	{
		private const float UP_OFFSET = 0.5f;

		private const float SIZE_TO_EFFECT_SCALE_RELATION = 5f / 9f;

		[SerializeField]
		private Animator hollyShieldEffect;

		private Animator animator;

		private Transform cameraTransform;

		private Transform root;

		private SphereCollider collider;

		private int showHash = Animator.StringToHash("show");

		private int hideHash = Animator.StringToHash("hide");

		private int invisHash = Animator.StringToHash("invisbility");

		private int alphaHash;

		private Material mat;

		private Vector3 previousCamPos;

		public Animator HollyShieldEffect
		{
			get
			{
				return hollyShieldEffect;
			}
		}

		public SphereCollider Collider
		{
			get
			{
				return collider;
			}
			set
			{
				collider = value;
			}
		}

		public GameObject InitEffect(Transform root, SkinnedMeshRenderer renderer, int colliderLayer)
		{
			this.root = root;
			alphaHash = Shader.PropertyToID("_Visibility");
			Vector3 size = renderer.localBounds.size;
			float num = Mathf.Max(size.x, size.y, size.z);
			animator = Object.Instantiate(hollyShieldEffect, root.position, root.rotation, root);
			animator.transform.localPosition = new Vector3(0f, 0.5f, 0f);
			Vector3 one = Vector3.one;
			one.z = (one.y = (one.x = 5f / 9f * num));
			animator.transform.localScale = one;
			animator.gameObject.SetActive(false);
			base.enabled = false;
			collider = animator.GetComponentInChildren<SphereCollider>();
			collider.gameObject.layer = colliderLayer;
			mat = animator.GetComponent<Renderer>().material;
			return animator.gameObject;
		}

		private void Update()
		{
			if (animator.IsInTransition(0) && animator.GetNextAnimatorStateInfo(0).shortNameHash == invisHash)
			{
				animator.gameObject.SetActive(false);
				base.enabled = false;
			}
		}

		public void Play()
		{
			base.enabled = true;
			animator.gameObject.SetActive(true);
			animator.Play(showHash, 0);
		}

		public void Stop()
		{
			animator.Play(hideHash, 0);
		}

		public void UpdateAlpha(float alpha)
		{
			mat.SetFloat(alphaHash, alpha);
		}
	}
}
