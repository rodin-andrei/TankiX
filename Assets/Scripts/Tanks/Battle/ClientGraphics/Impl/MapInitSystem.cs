using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.API;
using Tanks.Lobby.ClientSettings.API;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapInitSystem : ECSSystem
	{
		public class CameraNode : Node
		{
			public BattleCameraComponent battleCamera;

			public CameraComponent camera;

			public CameraTransformDataComponent cameraTransformData;

			public CameraOffsetConfigComponent cameraOffsetConfig;

			public BezierPositionComponent bezierPosition;

			public CameraESMComponent cameraEsm;
		}

		[OnEventFire]
		public void SetMaterialsQuality(NodeAddedEvent e, SingleNode<MapInstanceComponent> map, [JoinAll] SingleNode<MaterialsSettingsComponent> materialsSettings)
		{
			Shader.globalMaximumLOD = materialsSettings.component.GlobalShadersMaximumLOD;
		}

		[OnEventFire]
		public void SetGrassQuality(NodeAddedEvent e, SingleNode<MapInstanceComponent> map, SingleNode<CameraComponent> cameraNode)
		{
			Tanks.Lobby.ClientSettings.API.GraphicsSettings iNSTANCE = Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE;
			if (iNSTANCE.CurrentGrassFarDrawDistance > 0.1f)
			{
				ShadowCastingMode mode = (iNSTANCE.CurrentGrassCastsShadow ? ShadowCastingMode.On : ShadowCastingMode.Off);
				GrassGenerator[] componentsInChildren = map.component.SceneRoot.GetComponentsInChildren<GrassGenerator>();
				GrassGenerator[] array = componentsInChildren;
				foreach (GrassGenerator grassGenerator in array)
				{
					grassGenerator.SetCulling(iNSTANCE.CurrentGrassFarDrawDistance, iNSTANCE.CurrentGrassNearDrawDistance, iNSTANCE.CurrentGrassFadeRange, iNSTANCE.CurrentGrassDensityMultiplier);
					grassGenerator.Generate();
					SetShadowCastingMode(grassGenerator.transform, mode);
				}
			}
			map.component.SceneRoot.AddComponent<ShadowCasterCreatorBehaviour>();
		}

		[OnEventFire]
		public void SetPostProcessing(NodeAddedEvent e, SingleNode<MapInstanceComponent> map, SingleNode<CameraComponent> cameraNode, SingleNode<PostProcessingQualityVariantComponent> settings)
		{
			Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE.customSettings = settings.component.CustomSettings;
			Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE.currentAmbientOcclusion = settings.component.AmbientOcclusion;
			Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE.currentBloom = settings.component.Bloom;
			Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE.currentChromaticAberration = settings.component.ChromaticAberration;
			Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE.currentGrain = settings.component.Grain;
			Tanks.Lobby.ClientSettings.API.GraphicsSettings.INSTANCE.currentVignette = settings.component.Vignette;
		}

		[OnEventFire]
		public void SetWaterQuality(NodeAddedEvent e, SingleNode<WaterComponent> water, [JoinAll] SingleNode<WaterSettingsComponent> waterSettings)
		{
			if (!waterSettings.component.HasReflection)
			{
				water.component.DisableReflection();
			}
			water.component.EdgeBlend = waterSettings.component.EdgeBlend;
		}

		private void SetShadowCastingMode(Transform root, ShadowCastingMode mode)
		{
			MeshRenderer[] componentsInChildren = root.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.shadowCastingMode = mode;
			}
		}
	}
}
