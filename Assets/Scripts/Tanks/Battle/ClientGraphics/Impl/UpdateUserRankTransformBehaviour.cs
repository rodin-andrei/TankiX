using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateUserRankTransformBehaviour : MonoBehaviour
	{
		public void Init()
		{
			base.transform.up = Vector3.up;
		}

		private void Update()
		{
			base.transform.up = Vector3.up;
		}
	}
}
