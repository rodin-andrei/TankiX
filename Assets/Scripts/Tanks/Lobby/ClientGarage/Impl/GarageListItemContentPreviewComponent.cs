using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageListItemContentPreviewComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin skin;
		[SerializeField]
		private Image image;
		[SerializeField]
		private Text count;
	}
}
