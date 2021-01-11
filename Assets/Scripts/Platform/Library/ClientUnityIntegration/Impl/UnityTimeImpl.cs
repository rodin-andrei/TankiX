using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.Impl
{
	public class UnityTimeImpl : UnityTime
	{
		public float time
		{
			get
			{
				return Time.time;
			}
		}

		public float timeSinceLevelLoad
		{
			get
			{
				return Time.timeSinceLevelLoad;
			}
		}

		public float deltaTime
		{
			get
			{
				return Time.deltaTime;
			}
		}

		public float fixedTime
		{
			get
			{
				return Time.fixedTime;
			}
		}

		public float unscaledTime
		{
			get
			{
				return Time.unscaledTime;
			}
		}

		public float unscaledDeltaTime
		{
			get
			{
				return Time.unscaledDeltaTime;
			}
		}

		public float fixedDeltaTime
		{
			get
			{
				return Time.fixedDeltaTime;
			}
			set
			{
				Time.fixedDeltaTime = value;
			}
		}

		public float maximumDeltaTime
		{
			get
			{
				return Time.maximumDeltaTime;
			}
			set
			{
				Time.maximumDeltaTime = value;
			}
		}

		public float smoothDeltaTime
		{
			get
			{
				return Time.smoothDeltaTime;
			}
		}

		public float timeScale
		{
			get
			{
				return Time.timeScale;
			}
			set
			{
				Time.timeScale = value;
			}
		}

		public int frameCount
		{
			get
			{
				return Time.frameCount;
			}
		}

		public int renderedFrameCount
		{
			get
			{
				return Time.renderedFrameCount;
			}
		}

		public float realtimeSinceStartup
		{
			get
			{
				return Time.realtimeSinceStartup;
			}
		}

		public int captureFramerate
		{
			get
			{
				return Time.captureFramerate;
			}
			set
			{
				Time.captureFramerate = value;
			}
		}
	}
}
