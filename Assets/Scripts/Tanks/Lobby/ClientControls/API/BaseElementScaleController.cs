using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.API
{
	public class BaseElementScaleController : ScriptableObject
	{
		[SerializeField]
		private List<BaseElement> elements;
	}
}
