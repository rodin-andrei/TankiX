using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[SerialVersionUID(635901816912888930L)]
	public class ShowScreenForegroundComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float alpha = 1f;

		public float Alpha
		{
			get
			{
				return alpha;
			}
		}
	}
}
