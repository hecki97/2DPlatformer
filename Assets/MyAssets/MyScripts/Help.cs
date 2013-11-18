using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

	public GUITexture arrow;
	public bool helpEnabled = false;

	// Use this for initialization
	void Awake () {
		arrow.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H))
			ToggleHelp();
	}

	void ToggleHelp()
	{
		Debug.Log("ToggleHelp");
		if (!helpEnabled)
			arrow.enabled = true;
		else
			arrow.enabled = false;
		helpEnabled = !helpEnabled;
	}
}
