using UnityEngine;
using System.Collections.Generic;

namespace MeshBrush
{
	public class MeshBrush : MonoBehaviour
	{
		public bool isActive;
		public GameObject brush;
		public Transform holderObj;
		public Transform brushTransform;
		public string groupName;
		public GameObject[] setOfMeshesToPaint;
		public List<GameObject> paintBuffer;
		public List<GameObject> deletionBuffer;
		public KeyCode paintKey;
		public KeyCode deleteKey;
		public KeyCode combineAreaKey;
		public KeyCode increaseRadiusKey;
		public KeyCode decreaseRadiusKey;
		public float hRadius;
		public Color hColor;
		public int meshCount;
		public bool useRandomMeshCount;
		public int minNrOfMeshes;
		public int maxNrOfMeshes;
		public float delay;
		public float meshOffset;
		public float slopeInfluence;
		public bool activeSlopeFilter;
		public float maxSlopeFilterAngle;
		public bool inverseSlopeFilter;
		public bool manualRefVecSampling;
		public bool showRefVecInSceneGUI;
		public Vector3 slopeRefVec;
		public Vector3 slopeRefVec_HandleLocation;
		public bool yAxisIsTangent;
		public bool invertY;
		public float scattering;
		public bool autoStatic;
		public bool uniformScale;
		public bool constUniformScale;
		public bool rWithinRange;
		public bool b_CustomKeys;
		public bool b_Slopes;
		public bool b_Randomizers;
		public bool b_AdditiveScale;
		public bool b_opt;
		public float rScaleW;
		public float rScaleH;
		public float rScale;
		public Vector2 rUniformRange;
		public Vector4 rNonUniformRange;
		public float cScale;
		public Vector3 cScaleXYZ;
		public float rRot;
		public bool autoSelectOnCombine;
	}
}
