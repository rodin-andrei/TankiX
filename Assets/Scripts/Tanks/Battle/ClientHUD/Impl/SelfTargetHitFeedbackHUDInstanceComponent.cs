using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class SelfTargetHitFeedbackHUDInstanceComponent : BehaviourComponent
	{
		[SerializeField]
		private EntityBehaviour entityBehaviour;
		[SerializeField]
		private Vector2 minSize;
		[SerializeField]
		private Vector2 maxSize;
		[SerializeField]
		private Vector2 relativeSizeCoeff;
		[SerializeField]
		private float lengthPercent;
		[SerializeField]
		private float lengthInterpolator;
		[SerializeField]
		private RectTransform rootRectTransform;
		[SerializeField]
		private RectTransform imageRectTransform;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private Image image;
		[SerializeField]
		private int fps;
		[SerializeField]
		private int frameCount;
		[SerializeField]
		private float alpha;
	}
}
