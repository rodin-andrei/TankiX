using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewsImageContainerComponent : UIBehaviour
	{
		[SerializeField]
		private RectTransform imageContainer;
		[SerializeField]
		private AspectRatioFitter imageAspectRatioFitter;
		[SerializeField]
		private float imageAppearTime;
	}
}
