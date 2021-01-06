using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class CurvedUIInputModule : StandaloneInputModule
{
	public enum CUIControlMethod
	{
		MOUSE = 0,
		GAZE = 1,
		WORLD_MOUSE = 2,
		CUSTOM_RAY = 3,
		VIVE = 4,
		OCULUS_TOUCH = 5,
		GOOGLEVR = 7,
	}

	public enum Hand
	{
		Both = 0,
		Right = 1,
		Left = 2,
	}

	[SerializeField]
	private CUIControlMethod controlMethod;
	[SerializeField]
	private string submitButtonName;
	[SerializeField]
	private bool gazeUseTimedClick;
	[SerializeField]
	private float gazeClickTimer;
	[SerializeField]
	private float gazeClickTimerDelay;
	[SerializeField]
	private Image gazeTimedClickProgressImage;
	[SerializeField]
	private float worldSpaceMouseSensitivity;
	[SerializeField]
	private Hand usedHand;
}
