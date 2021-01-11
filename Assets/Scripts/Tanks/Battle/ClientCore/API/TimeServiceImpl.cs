using System;
using log4net;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Battle.ClientCore.API
{
	public class TimeServiceImpl : TimeService
	{
		public static float SMOOTH_RATE = 0.1f;

		public static long MAX_DELTA_DIFF_TO_SERVER = 5000L;

		private long diffToServer;

		private bool serverTimeInited;

		private long initServerTime;

		private float initUnityRealTime;

		private bool smoothing;

		private float smoothBeginTime;

		private long smoothedDiffToServer;

		private long deltaDiffToServer;

		private long absDeltaDiffToServer;

		private ILog log;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		public long DiffToServer
		{
			get
			{
				CheckInited();
				UpdateSmoothing();
				return smoothedDiffToServer;
			}
			set
			{
				CheckInited();
				log.InfoFormat("SetDiffToServer: {0}", value);
				smoothing = false;
				diffToServer = value;
			}
		}

		public TimeServiceImpl()
		{
			log = LoggerProvider.GetLogger(this);
		}

		public void InitServerTime(long serverTime)
		{
			initServerTime = serverTime;
			initUnityRealTime = UnityTime.realtimeSinceStartup;
			diffToServer = initServerTime - (long)(initUnityRealTime * 1000f);
			serverTimeInited = true;
			log.InfoFormat("InitServerTime: serverTime={0} unityRealTime={1} diffToServer={2}", serverTime, initUnityRealTime, diffToServer);
		}

		private void CheckInited()
		{
			if (!serverTimeInited)
			{
				throw new Exception("Server time not inited");
			}
		}

		public void SetDiffToServerWithSmoothing(long newDiffToServer)
		{
			UpdateSmoothing();
			deltaDiffToServer = newDiffToServer - smoothedDiffToServer;
			absDeltaDiffToServer = Math.Abs(deltaDiffToServer);
			if (absDeltaDiffToServer > MAX_DELTA_DIFF_TO_SERVER)
			{
				log.ErrorFormat("Delta too large: {0}", absDeltaDiffToServer);
				deltaDiffToServer = ((deltaDiffToServer <= 0) ? (-MAX_DELTA_DIFF_TO_SERVER) : MAX_DELTA_DIFF_TO_SERVER);
				absDeltaDiffToServer = MAX_DELTA_DIFF_TO_SERVER;
			}
			diffToServer = smoothedDiffToServer + deltaDiffToServer;
			log.InfoFormat("Begin smoothing: deltaDiffToServer={0} wasSmoothing={1}", deltaDiffToServer, smoothing);
			if (deltaDiffToServer != 0)
			{
				smoothing = true;
				smoothBeginTime = UnityTime.realtimeSinceStartup;
			}
		}

		public void UpdateSmoothing()
		{
			if (smoothing)
			{
				float num = UnityTime.realtimeSinceStartup - smoothBeginTime;
				float num2 = (float)absDeltaDiffToServer / 1000f / SMOOTH_RATE;
				if (num >= num2)
				{
					log.InfoFormat("End smoothing: diffToServer={0}", diffToServer);
					smoothedDiffToServer = diffToServer;
					smoothing = false;
				}
				else
				{
					float num3 = num / num2;
					long num4 = diffToServer - deltaDiffToServer;
					smoothedDiffToServer = num4 + (long)(num3 * (float)deltaDiffToServer);
				}
			}
			else
			{
				smoothedDiffToServer = diffToServer;
			}
		}
	}
}
