using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AlloyToStandardMaterialsMap : MonoBehaviour
	{
		[SerializeField]
		private List<Material> alloyMaterials = new List<Material>();

		[SerializeField]
		private List<Material> standardMaterials = new List<Material>();

		[SerializeField]
		private List<Material> usedMaterials = new List<Material>();

		public List<Material> UsedMaterials
		{
			get
			{
				return usedMaterials;
			}
		}

		public List<Material> AlloyMaterials
		{
			get
			{
				return alloyMaterials;
			}
		}

		public List<Material> StandardMaterials
		{
			get
			{
				return standardMaterials;
			}
		}

		public bool HasStandardReplacement(Material alloy)
		{
			return alloyMaterials.Contains(alloy);
		}

		public Material GetStandardReplacement(Material alloy)
		{
			int index = alloyMaterials.IndexOf(alloy);
			return standardMaterials[index];
		}

		public void AddStandardReplacement(Material alloy, Material standard)
		{
			alloyMaterials.Add(alloy);
			standardMaterials.Add(standard);
		}
	}
}
