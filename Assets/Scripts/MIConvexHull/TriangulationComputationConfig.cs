namespace MIConvexHull
{
	public class TriangulationComputationConfig : ConvexHullComputationConfig
	{
		public double ZeroCellVolumeTolerance
		{
			get;
			set;
		}

		public TriangulationComputationConfig()
		{
			ZeroCellVolumeTolerance = 1E-05;
		}
	}
}
