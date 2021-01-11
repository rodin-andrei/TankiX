using System;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public static class SmoothedTime
	{
		private static float MIN_FRAME_TIME;

		private static float MAX_FRAME_TIME;

		private static float LERP_FACTOR;

		private static int FRAME_COUNT;

		private static int NOISE_COUNT;

		private static float[] lastTimes;

		private static float[] sortedTimes;

		private static float lastFrameDeltaTime;

		private static int lastCalculatedFrame;

		static SmoothedTime()
		{
			MIN_FRAME_TIME = 0.01f;
			MAX_FRAME_TIME = 0.5f;
			LERP_FACTOR = 0.1f;
			FRAME_COUNT = 30;
			NOISE_COUNT = 5;
			lastTimes = new float[FRAME_COUNT];
			sortedTimes = new float[FRAME_COUNT];
			lastFrameDeltaTime = 0f;
			lastCalculatedFrame = 0;
			for (int i = 0; i < FRAME_COUNT; i++)
			{
				lastTimes[i] = MIN_FRAME_TIME;
			}
		}

		public static float GetSmoothDeltaTime()
		{
			if (Time.frameCount == lastCalculatedFrame)
			{
				return lastFrameDeltaTime;
			}
			if (lastFrameDeltaTime == 0f)
			{
				lastFrameDeltaTime = Time.deltaTime;
				return lastFrameDeltaTime;
			}
			float num = Time.deltaTime;
			if (num > MIN_FRAME_TIME)
			{
				for (int i = 0; i < FRAME_COUNT - 1; i++)
				{
					lastTimes[FRAME_COUNT - i - 1] = lastTimes[FRAME_COUNT - i - 2];
				}
				lastTimes[0] = num;
				for (int j = 0; j < FRAME_COUNT; j++)
				{
					sortedTimes[j] = lastTimes[j];
				}
				Array.Sort(sortedTimes);
				float num2 = 0f;
				int num3 = 0;
				for (int k = NOISE_COUNT; k < FRAME_COUNT - NOISE_COUNT; k++)
				{
					num2 += sortedTimes[k];
					num3++;
				}
				if (num3 > 0)
				{
					float num4 = num2 / (float)num3;
					num4 = LERP_FACTOR * num4 + (1f - LERP_FACTOR) * lastFrameDeltaTime;
					num = num4;
				}
			}
			lastFrameDeltaTime = num;
			lastCalculatedFrame = Time.frameCount;
			return lastFrameDeltaTime;
		}
	}
}
