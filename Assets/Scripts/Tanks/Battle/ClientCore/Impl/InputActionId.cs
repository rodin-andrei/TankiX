using System;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[Serializable]
	public class InputActionId
	{
		public InputActionId(string actionTypeName, string actionName)
		{
		}

		[SerializeField]
		public string actionTypeName;
		[SerializeField]
		public string actionName;
	}
}
