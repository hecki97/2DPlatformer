using UnityEngine;
using System.Collections;

public class GuiVersionText : MonoBehaviour {

	public GUIText guiVersionText;
	public string gameVersion = "Indev v.0.13";

	// Use this for initialization
	void Start () {
		guiVersionText.text = gameVersion;
	}
}
