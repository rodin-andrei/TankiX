using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DecalsTestBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Material decalMaterial;
		[SerializeField]
		private float projectDistantion;
		[SerializeField]
		private float projectSize;
		[SerializeField]
		private int hTilesCount;
		[SerializeField]
		private int vTilesCount;
		[SerializeField]
		private float mouseWheelSenetivity;
		[SerializeField]
		private int[] surfaceAtlasPositions;
		[SerializeField]
		private bool updateEveryFrame;
	}
}
