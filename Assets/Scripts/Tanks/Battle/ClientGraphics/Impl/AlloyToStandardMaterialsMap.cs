using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AlloyToStandardMaterialsMap : MonoBehaviour
	{
		[SerializeField]
		private List<Material> alloyMaterials;
		[SerializeField]
		private List<Material> standardMaterials;
		[SerializeField]
		private List<Material> usedMaterials;
	}
}
