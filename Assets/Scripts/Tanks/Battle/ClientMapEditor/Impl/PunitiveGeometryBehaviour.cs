using System.Diagnostics;
using UnityEngine;

namespace Tanks.Battle.ClientMapEditor.Impl
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(BoxCollider))]
	public class PunitiveGeometryBehaviour : EditorBehavior
	{
		public bool showGeometry;

		public AnticheatAction anticheatAction;

		public void Initialize(AnticheatAction anticheatAction)
		{
			this.anticheatAction = anticheatAction;
		}

		[Conditional("UNITY_EDITOR")]
		private void Update()
		{
			BoxCollider component = GetComponent<BoxCollider>();
			if (component.transform.rotation != Quaternion.identity)
			{
				UnityEngine.Debug.LogWarning("Punitive boxes can not be rotated");
				component.transform.rotation = Quaternion.identity;
			}
			if (component.transform.localScale != Vector3.one)
			{
				UnityEngine.Debug.LogWarning("Punitive boxes can not be scaled");
				component.transform.localScale = Vector3.one;
			}
		}

		private void OnDrawGizmos()
		{
			if (showGeometry)
			{
				Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
				Gizmos.DrawCube(base.transform.position + new Vector3(GetComponent<BoxCollider>().center.x, GetComponent<BoxCollider>().center.y, GetComponent<BoxCollider>().center.z), new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z));
			}
		}
	}
}
