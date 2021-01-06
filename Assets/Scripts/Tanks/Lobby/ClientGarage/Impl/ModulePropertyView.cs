using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulePropertyView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI propertyName;
		[SerializeField]
		private TextMeshProUGUI currentParam;
		[SerializeField]
		private TextMeshProUGUI nextParam;
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private GameObject Progress;
		[SerializeField]
		private Image currentProgress;
		[SerializeField]
		private Image nextProgress;
		public GameObject FillNext;
		public GameObject NextString;
	}
}
