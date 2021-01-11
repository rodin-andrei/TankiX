using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(-1853333282151870933L)]
	public class RotationComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 RotationEuler
		{
			get;
			set;
		}

		public RotationComponent()
		{
		}

		public RotationComponent(Vector3 rotationEuler)
		{
			RotationEuler = rotationEuler;
		}
	}
}
