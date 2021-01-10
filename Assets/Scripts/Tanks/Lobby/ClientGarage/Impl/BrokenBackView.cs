using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BrokenBackView : MonoBehaviour
	{
		[SerializeField]
		private float animationTime;
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private RectTransform[] parts;
	}
}
