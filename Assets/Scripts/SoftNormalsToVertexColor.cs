using UnityEngine;

public class SoftNormalsToVertexColor : MonoBehaviour
{
	public enum Method
	{
		Simple = 0,
		AngularDeviation = 1,
	}

	public Method method;
	public bool generateOnAwake;
	public bool generateNow;
}
