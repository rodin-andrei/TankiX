using Tanks.Lobby.ClientControls.API;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class TMPInputFormatter : BaseTMPInputFormatter
	{
		[SerializeField]
		private List<int> spacePositions;
		[SerializeField]
		private string spaceChar;
	}
}
