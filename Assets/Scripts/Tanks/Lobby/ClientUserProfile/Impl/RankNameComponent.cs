using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class RankNameComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text rankNameText;

		public string RankName
		{
			get
			{
				return rankNameText.text;
			}
			set
			{
				rankNameText.text = value;
			}
		}
	}
}
