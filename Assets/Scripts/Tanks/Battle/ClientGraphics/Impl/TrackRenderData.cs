namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TrackRenderData
	{
		public TrackRenderData(int maxSectorCountPerTrack, int firstSectorToHide, float baseAlpha, int parts)
		{
		}

		public int maxSectorCountPerTrack;
		public int lastSectorIndex;
		public int sectorCount;
		public int firstSectorToHide;
		public float baseAlpha;
		public int parts;
		public float texturePart;
		public int currentPart;
	}
}
