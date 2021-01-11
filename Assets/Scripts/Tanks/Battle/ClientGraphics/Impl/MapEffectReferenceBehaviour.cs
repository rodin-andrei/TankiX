using Platform.Library.ClientResources.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapEffectReferenceBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AssetReference mapEffect;

		public AssetReference MapEffect
		{
			get
			{
				return mapEffect;
			}
		}
	}
}
