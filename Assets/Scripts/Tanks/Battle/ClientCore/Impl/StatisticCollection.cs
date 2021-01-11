using System;

namespace Tanks.Battle.ClientCore.Impl
{
	public class StatisticCollection
	{
		private readonly int maxValue;

		private int[] valueToCount;

		private int moda = -1;

		private float average = -1f;

		private float standardDeviation = -1f;

		private int totalCount;

		public int Moda
		{
			get
			{
				if (moda != -1)
				{
					return moda;
				}
				int num = 0;
				for (int i = 0; i < valueToCount.Length; i++)
				{
					int num2 = i;
					int num3 = valueToCount[i];
					if (num3 > num)
					{
						num = num3;
						moda = num2;
					}
				}
				return moda;
			}
		}

		public float Average
		{
			get
			{
				if (!average.Equals(-1f))
				{
					return average;
				}
				if (totalCount == 0)
				{
					return average;
				}
				int num = 0;
				for (int i = 0; i < valueToCount.Length; i++)
				{
					int num2 = i;
					int num3 = valueToCount[i];
					num += num3 * num2;
				}
				average = (float)num / (float)totalCount;
				return average;
			}
		}

		public float StandartDeviation
		{
			get
			{
				if (!standardDeviation.Equals(-1f))
				{
					return standardDeviation;
				}
				if (totalCount == 0)
				{
					return standardDeviation;
				}
				float num = 0f;
				for (int i = 0; i < valueToCount.Length; i++)
				{
					int num2 = i;
					int num3 = valueToCount[i];
					num += ((float)num2 - Average) * ((float)num2 - Average) * (float)num3;
				}
				standardDeviation = (int)Math.Sqrt(num / (float)totalCount);
				return standardDeviation;
			}
		}

		public int TotalCount
		{
			get
			{
				return totalCount;
			}
		}

		public StatisticCollection(int maxValue)
		{
			this.maxValue = maxValue;
			valueToCount = new int[maxValue];
		}

		public void Add(int value)
		{
			if (value >= maxValue)
			{
				value = maxValue - 1;
			}
			valueToCount[value]++;
			totalCount++;
			SetDirty();
		}

		public void Add(int value, int count)
		{
			if (count > 0)
			{
				if (value >= maxValue)
				{
					value = maxValue - 1;
				}
				valueToCount[value] += count;
				totalCount += count;
				SetDirty();
			}
		}

		public StatisticCollection Clone()
		{
			StatisticCollection statisticCollection = new StatisticCollection(maxValue);
			statisticCollection.valueToCount = new int[valueToCount.GetLength(0)];
			valueToCount.CopyTo(statisticCollection.valueToCount, 0);
			statisticCollection.moda = moda;
			statisticCollection.average = average;
			statisticCollection.standardDeviation = standardDeviation;
			statisticCollection.totalCount = totalCount;
			return statisticCollection;
		}

		private void SetDirty()
		{
			moda = -1;
			average = -1f;
			standardDeviation = -1f;
		}
	}
}
