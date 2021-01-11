using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public static class InputMapping
	{
		private static readonly string HORIZONTAL = "Horizontal";

		private static readonly string VERTICAL = "Vertical";

		private static readonly string CANCEL = "Cancel";

		private static readonly string SUBMIT = "Submit";

		public static float Horizontal
		{
			get
			{
				return Input.GetAxis(HORIZONTAL);
			}
		}

		public static float Vertical
		{
			get
			{
				return Input.GetAxis(VERTICAL);
			}
		}

		public static bool Cancel
		{
			get
			{
				return Input.GetButtonDown(CANCEL);
			}
		}

		public static bool Submit
		{
			get
			{
				return Input.GetButtonDown(SUBMIT);
			}
		}
	}
}
