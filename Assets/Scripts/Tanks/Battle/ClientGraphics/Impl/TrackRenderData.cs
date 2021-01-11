namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TrackRenderData
	{
		public TrackSector[] sectors;

		public int maxSectorCountPerTrack;

		public int lastSectorIndex;

		public int sectorCount;

		public int firstSectorToHide;

		public float baseAlpha;

		public int parts;

		public float texturePart;

		public int currentPart;

		public TrackRenderData(int maxSectorCountPerTrack, int firstSectorToHide, float baseAlpha, int parts)
		{
			this.maxSectorCountPerTrack = maxSectorCountPerTrack;
			this.firstSectorToHide = firstSectorToHide;
			this.baseAlpha = baseAlpha;
			this.parts = parts;
			texturePart = 1f / (float)parts;
			sectors = new TrackSector[maxSectorCountPerTrack];
			Reset();
		}

		public void Reset()
		{
			lastSectorIndex = -1;
			sectorCount = 0;
			currentPart = 0;
		}
	}
}
