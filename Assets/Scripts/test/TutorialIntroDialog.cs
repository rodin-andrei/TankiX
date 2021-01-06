using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

public class TutorialIntroDialog : MonoBehaviour
{
	[SerializeField]
	protected AnimatedText animatedText;
	[SerializeField]
	private Button yesButton;
	[SerializeField]
	private Button noButton;
	[SerializeField]
	private Button sarcasmButton;
	[SerializeField]
	private Button startTutorial;
	[SerializeField]
	private Button skipTutorial;
	[SerializeField]
	private LocalizedField yesText;
	[SerializeField]
	private LocalizedField introText;
	[SerializeField]
	private LocalizedField introWithoutQuestionText;
	[SerializeField]
	private LocalizedField confirmText;
	[SerializeField]
	private LocalizedField tipText;
	[SerializeField]
	private LocalizedField sarcasmText;
}
