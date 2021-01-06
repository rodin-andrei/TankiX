using System;
using UnityEngine;
using System.Collections.Generic;
using Platform.Library.ClientResources.API;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class BaseElement
	{
		[SerializeField]
		private int canvasHeight;
		[SerializeField]
		private int size;
		[SerializeField]
		private List<AssetReference> skins;
	}
}
