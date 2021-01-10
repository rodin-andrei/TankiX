using UnityEngine;
using Tanks.Tool.TankViewer.API.Params;
using tanks.modules.tool.TankViewer.Scripts.API.ColoringEditor.ParamView;
using UnityEngine.UI;

namespace Tanks.Tool.TankViewer.API
{
	public class CreatorView : MonoBehaviour
	{
		public ColorView colorView;
		public TextureView textureView;
		public NormalMapView normalMapView;
		public MetallicView metallicView;
		public SmoothnessView smoothnessView;
		public IntensityThresholdView intensityThresholdView;
		public Button saveButton;
		public Button cancelButton;
		public Button updateTexturesButton;
	}
}
