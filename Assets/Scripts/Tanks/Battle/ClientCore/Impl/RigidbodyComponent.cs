using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(635824352590065226L)]
	public class RigidbodyComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Rigidbody Rigidbody
		{
			get;
			set;
		}

		public Transform RigidbodyTransform
		{
			get
			{
				return Rigidbody.transform;
			}
		}

		public RigidbodyComponent()
		{
		}

		public RigidbodyComponent(Rigidbody rigidbody)
		{
			Rigidbody = rigidbody;
		}
	}
}
