using Platform.Library.ClientUnityIntegration.API;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TeamUIColorizeComponent : BehaviourComponent
	{
		[SerializeField]
		private List<Color> redColors;
		[SerializeField]
		private List<Color> blueColors;
		[SerializeField]
		private List<Graphic> elements;
	}
}
