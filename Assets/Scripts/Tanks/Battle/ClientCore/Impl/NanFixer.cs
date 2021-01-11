using Platform.Library.ClientLogger.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class NanFixer : MonoBehaviour
	{
		private Rigidbody body;

		private Transform tr;

		private long userId;

		private Vector3 prevBodyPosition;

		private Quaternion prevBodyRotation;

		private Vector3 prevBodyVelocity;

		private Vector3 prevBodyAngularVelocity;

		private Vector3 prevPosition;

		private Quaternion prevRotation;

		private int logNumber;

		private const int logThreshold = 100;

		public bool testInjectNan;

		public void Init(Rigidbody body, Transform tr, long userId)
		{
			this.body = body;
			this.tr = tr;
			this.userId = userId;
		}

		public bool FixAndSave()
		{
			bool flag = TryFix();
			if (flag && logNumber < 100)
			{
				LoggerProvider.GetLogger(typeof(PhysicsUtil)).ErrorFormat("NanFixer fix {0} at frame {1}, user: {2}, logNumber: {3}", GetPath(tr), Time.frameCount, userId, logNumber);
				logNumber++;
			}
			SaveState();
			return flag;
		}

		public static string GetPath(Transform current)
		{
			if (current.parent == null)
			{
				return "/" + current.name;
			}
			return GetPath(current.parent) + "/" + current.name;
		}

		public bool TryFix()
		{
			int num = 0;
			if (body != null)
			{
				if (!PhysicsUtil.ValidateVector3(body.position))
				{
					body.position = prevBodyPosition;
					num++;
				}
				if (!PhysicsUtil.ValidateQuaternion(body.rotation))
				{
					body.rotation = prevBodyRotation;
					num++;
				}
				if (!PhysicsUtil.ValidateVector3(body.velocity))
				{
					body.velocity = prevBodyVelocity;
					num++;
				}
				if (!PhysicsUtil.ValidateVector3(body.angularVelocity))
				{
					body.angularVelocity = prevBodyAngularVelocity;
					num++;
				}
			}
			if (tr != null)
			{
				if (!PhysicsUtil.ValidateVector3(tr.position))
				{
					tr.position = prevPosition;
					num++;
				}
				if (!PhysicsUtil.ValidateQuaternion(tr.rotation))
				{
					tr.rotation = prevRotation;
					num++;
				}
			}
			return num > 0;
		}

		public void SaveState()
		{
			if (body != null)
			{
				prevBodyPosition = body.position;
				prevBodyRotation = body.rotation;
				prevBodyVelocity = body.velocity;
				prevBodyAngularVelocity = body.angularVelocity;
			}
			if (tr != null)
			{
				prevPosition = tr.position;
				prevRotation = tr.rotation;
			}
		}
	}
}
