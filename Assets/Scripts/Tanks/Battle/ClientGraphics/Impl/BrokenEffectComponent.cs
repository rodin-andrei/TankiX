using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BrokenEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject brokenEffect;

		[SerializeField]
		private string trackObjectNamePrefix = "track";

		[SerializeField]
		private string trackMaterialNamePrefix = "Track";

		private Rigidbody rigidbody;

		private Rigidbody parentRigidbody;

		public GameObject effectInstance;

		private Rigidbody[] partRigidbodies;

		private Renderer[] renderers;

		private List<Material> materials;

		private string[] materialNames;

		private float lastAlpha = -1f;

		private bool[] rendererIsTrack;

		private List<Vector3> partPositions;

		private List<Quaternion> partRotations;

		private bool inited;

		private float effectStartTime;

		private float effectLifeTime;

		private float fadeTime = 2f;

		public float partDetachProbability = 0.7f;

		public float LifeTime = 6f;

		private Dictionary<string, Material> nameToMaterial;

		private void Awake()
		{
			base.enabled = false;
		}

		public void StartEffect(GameObject root, Rigidbody parentRigidbody, Renderer parentRenderer, Shader overloadShader, float maxDepenetrationVelocity)
		{
			if (!inited || !effectInstance)
			{
				Init();
			}
			this.parentRigidbody = parentRigidbody;
			effectInstance.transform.SetParent(root.transform);
			effectInstance.transform.position = rigidbody.transform.position;
			effectInstance.transform.rotation = rigidbody.transform.rotation;
			UpdateMaterialsFromParentMaterials(parentRenderer, overloadShader);
			RecoverTransforms();
			SetVelocityFromParent(maxDepenetrationVelocity);
			effectStartTime = Time.timeSinceLevelLoad;
			effectLifeTime = LifeTime;
			Enable();
		}

		public void Init()
		{
			rigidbody = GetComponent<Rigidbody>();
			effectInstance = Object.Instantiate(brokenEffect);
			PhysicsUtil.SetGameObjectLayer(effectInstance, Layers.MINOR_VISUAL);
			partRigidbodies = effectInstance.GetComponentsInChildren<Rigidbody>();
			renderers = effectInstance.GetComponentsInChildren<Renderer>();
			nameToMaterial = new Dictionary<string, Material>();
			SaveTransforms();
			Disable();
			inited = true;
		}

		public void Update()
		{
			if (!FadeAlpha())
			{
				Disable();
			}
		}

		private void UpdateMaterialsFromParentMaterials(Renderer parentRenderer, Shader overloadShader)
		{
			materials = new List<Material>();
			Material[] sharedMaterials = parentRenderer.sharedMaterials;
			CacheMaterials(sharedMaterials);
			for (int i = 0; i < renderers.Length; i++)
			{
				Renderer renderer = renderers[i];
				Material source = sharedMaterials[0];
				if (nameToMaterial.ContainsKey(materialNames[i]))
				{
					source = nameToMaterial[materialNames[i]];
				}
				Material material = new Material(source);
				if ((bool)overloadShader)
				{
					material.shader = overloadShader;
				}
				renderer.material = material;
				if (!materials.Contains(material))
				{
					materials.Add(material);
				}
			}
		}

		private void CacheMaterials(Material[] materials)
		{
			if (nameToMaterial.Count > 0)
			{
				return;
			}
			foreach (Material material in materials)
			{
				string key = material.name.Replace("(Instance)", string.Empty).Replace(" ", string.Empty);
				if (!nameToMaterial.ContainsKey(key))
				{
					nameToMaterial.Add(key, material);
				}
			}
			materialNames = new string[renderers.Length];
			for (int j = 0; j < materialNames.Length; j++)
			{
				Material sharedMaterial = renderers[j].sharedMaterial;
				materialNames[j] = sharedMaterial.name.Replace("(Instance)", string.Empty).Replace(" ", string.Empty);
			}
		}

		private void SaveTransforms()
		{
			partPositions = new List<Vector3>(partRigidbodies.Length);
			partRotations = new List<Quaternion>(partRigidbodies.Length);
			Rigidbody[] array = partRigidbodies;
			foreach (Rigidbody rigidbody in array)
			{
				partPositions.Add(rigidbody.transform.localPosition);
				partRotations.Add(rigidbody.transform.localRotation);
			}
		}

		private void RecoverTransforms()
		{
			for (int i = 0; i < partRigidbodies.Length; i++)
			{
				Rigidbody rigidbody = partRigidbodies[i];
				rigidbody.transform.localPosition = partPositions[i];
				rigidbody.transform.localRotation = partRotations[i];
			}
		}

		private void SetVelocityFromParent(float maxDepenetrationVelocity)
		{
			Rigidbody[] array = partRigidbodies;
			foreach (Rigidbody rigidbody in array)
			{
				rigidbody.isKinematic = false;
				rigidbody.velocity = parentRigidbody.velocity;
				rigidbody.angularVelocity = parentRigidbody.angularVelocity;
				rigidbody.gameObject.SetActive(true);
				if (Random.value < partDetachProbability)
				{
					rigidbody.maxDepenetrationVelocity = maxDepenetrationVelocity;
				}
				else
				{
					rigidbody.maxDepenetrationVelocity = 1f;
				}
			}
		}

		private bool FadeAlpha()
		{
			float num = 1f - Mathf.Clamp01((Time.timeSinceLevelLoad - (effectStartTime + effectLifeTime - fadeTime)) / fadeTime);
			if (num != lastAlpha)
			{
				lastAlpha = num;
				foreach (Material material in materials)
				{
					TankMaterialsUtil.SetAlpha(material, num);
				}
			}
			return Time.timeSinceLevelLoad < effectStartTime + effectLifeTime;
		}

		private void Enable()
		{
			if ((bool)effectInstance)
			{
				effectInstance.gameObject.SetActive(true);
			}
			base.enabled = true;
		}

		private void Disable()
		{
			if ((bool)effectInstance)
			{
				effectInstance.SetActive(false);
			}
			base.enabled = false;
		}

		private void OnDestroy()
		{
			if ((bool)effectInstance)
			{
				Object.Destroy(effectInstance);
			}
		}
	}
}
