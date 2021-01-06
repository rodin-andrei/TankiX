using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ExpBarEndGlowImage : MonoBehaviour
	{
		[SerializeField]
		private float minX;
		[SerializeField]
		private float maxX;
		[SerializeField]
		private UIRectClipper clipper;
		[SerializeField]
		private GameObject icon;
	}
}
