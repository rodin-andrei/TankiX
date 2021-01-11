using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(635824352682945226L)]
	public class MuzzlePointComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public int CurrentIndex
		{
			get;
			set;
		}

		public Transform[] Points
		{
			get;
			set;
		}

		public Transform Current
		{
			get
			{
				return Points[CurrentIndex];
			}
		}
	}
}
