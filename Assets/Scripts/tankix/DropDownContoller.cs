using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownContoller : MonoBehaviour {
	public TextMesh textMesh;
	// Use this for initialization
	void Start () {
        Dropdown drop = this.gameObject.GetComponent<Dropdown>();
        Dropdown.OptionData optionData = new Dropdown.OptionData("ЕБАТЬ");
		drop.AddOptions(new List<Dropdown.OptionData> { optionData });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
