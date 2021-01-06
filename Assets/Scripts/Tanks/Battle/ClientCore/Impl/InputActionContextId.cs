using System;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[Serializable]
	public class InputActionContextId
	{
		public InputActionContextId(string contextTypeName)
		{
		}

		[SerializeField]
		public string contextTypeName;
		[SerializeField]
		public string contextName;
	}
}
