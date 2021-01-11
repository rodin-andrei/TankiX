using System;
using System.Collections.Generic;
using log4net;
using Platform.Library.ClientLogger.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class WWWLoader : Loader, IDisposable
	{
		public static int DEFAULT_MAX_ATTEMPTS = 2;

		public static float DEFAULT_TIMEOUT_SECONDS = 30f;

		private WWW www;

		private int restartAttempts = DEFAULT_MAX_ATTEMPTS;

		private float timeoutSeconds = DEFAULT_TIMEOUT_SECONDS;

		private float lastProgress;

		private float lastProgressTime = Time.time;

		private string errorMessage = string.Empty;

		private static LinkedList<WWWLoader> activeLoaders = new LinkedList<WWWLoader>();

		private ILog Log;

		public int MaxRestartAttempts
		{
			get
			{
				return restartAttempts;
			}
			set
			{
				restartAttempts = value;
			}
		}

		public float TimeoutSeconds
		{
			get
			{
				return timeoutSeconds;
			}
			set
			{
				timeoutSeconds = value;
			}
		}

		public byte[] Bytes
		{
			get
			{
				return www.bytes;
			}
		}

		public float Progress
		{
			get
			{
				return www.progress;
			}
		}

		public WWW WWW
		{
			get
			{
				return www;
			}
		}

		public bool IsDone
		{
			get
			{
				if (www.isDone)
				{
					if (!string.IsNullOrEmpty(www.error) && restartAttempts > 0)
					{
						RestartLoad();
						return false;
					}
					return true;
				}
				float time = Time.time;
				if (Math.Abs(www.progress - lastProgress) > float.Epsilon)
				{
					lastProgress = www.progress;
					lastProgressTime = time;
					return false;
				}
				if (time - lastProgressTime > timeoutSeconds)
				{
					if (restartAttempts > 0)
					{
						RestartLoad();
						return false;
					}
					Log.InfoFormat("Fail URL: {0}", URL);
					errorMessage = "Pause of loading was too long";
					return true;
				}
				return false;
			}
		}

		public string URL
		{
			get
			{
				return www.url;
			}
		}

		public string Error
		{
			get
			{
				return (!string.IsNullOrEmpty(www.error)) ? www.error : errorMessage;
			}
		}

		public WWWLoader(WWW www)
		{
			this.www = www;
			Log = LoggerProvider.GetLogger(this);
			Log.InfoFormat("Loading {0}", www.url);
			activeLoaders.AddLast(this);
		}

		public static void DisposeActiveLoaders()
		{
			while (activeLoaders.Count > 0)
			{
				activeLoaders.First.Value.Dispose();
			}
		}

		public void RestartLoad()
		{
			restartAttempts--;
			string url = www.url;
			Log.InfoFormat("RestartLoad URL: {0} restartAttempts: {1}", url, DEFAULT_MAX_ATTEMPTS - restartAttempts);
			www.Dispose();
			www = new WWW(url);
			lastProgress = 0f;
			lastProgressTime = Time.time;
			errorMessage = string.Empty;
		}

		public void Dispose()
		{
			www.Dispose();
			activeLoaders.Remove(this);
		}

		public override string ToString()
		{
			return string.Format("[WWWLoader URL={0}]", URL);
		}

		public static int GetResponseCode(WWW request)
		{
			int result = 0;
			if (request.isDone && request.responseHeaders != null && request.responseHeaders.ContainsKey("STATUS"))
			{
				string[] array = request.responseHeaders["STATUS"].Split(' ');
				if (array.Length >= 3)
				{
					int.TryParse(array[1], out result);
				}
			}
			return result;
		}
	}
}
