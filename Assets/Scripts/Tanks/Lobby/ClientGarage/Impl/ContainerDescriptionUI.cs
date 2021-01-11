using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainerDescriptionUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI description;

		public TextMeshProUGUI Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

		public TextMeshProUGUI Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}
	}
}
