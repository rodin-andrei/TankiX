using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Platform.System.Data.Statics.ClientYaml.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientLoading.Impl
{
	public class BattleHintsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public string hintsConfig;

		private Text text;

		private List<string> hints;

		private int currentHintIndex;

		private int updateTimeInSec;

		private float lastChangeHintTime;

		[Inject]
		public static ConfigurationService ConfigurationService
		{
			get;
			set;
		}

		private void Awake()
		{
			text = GetComponent<Text>();
			ParseConfig();
			currentHintIndex = -1;
			SetNextHintText();
		}

		private void OnEnable()
		{
			lastChangeHintTime = Time.realtimeSinceStartup;
		}

		private void OnDisable()
		{
			if (Time.realtimeSinceStartup - lastChangeHintTime > 2f)
			{
				SetNextHintText();
			}
		}

		private void Update()
		{
			if (hints != null && hints.Count > 1 && Time.realtimeSinceStartup - lastChangeHintTime >= (float)updateTimeInSec)
			{
				SetNextHintText();
				lastChangeHintTime = Time.realtimeSinceStartup;
			}
		}

		private void SetNextHintText()
		{
			currentHintIndex = Random.Range(0, hints.Count);
			text.text = hints[currentHintIndex];
		}

		private void ParseConfig()
		{
			YamlNode config = ConfigurationService.GetConfig(hintsConfig);
			YamlNode childNode = config.GetChildNode("battleHints");
			hints = childNode.GetChildListValues("collection");
			for (int i = 0; i < hints.Count; i++)
			{
				hints[i] = hints[i].TrimEnd('\n');
			}
			updateTimeInSec = int.Parse(childNode.GetStringValue("updateTimeInSec"));
		}
	}
}
