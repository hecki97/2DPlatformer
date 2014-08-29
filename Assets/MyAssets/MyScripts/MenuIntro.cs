using UnityEngine;
using System.Collections;

public class MenuIntro : MonoBehaviour {

	private int toolbarInt = 0;
	private string[]  toolbarstrings =  {"Main","Settings","Credits"};
	public GUISkin skin;
	public string[] credits = {
		"2D Platformer [inDev]",
		""
	};
	public Texture[] crediticons;

	public enum Page {
		Main,Options,Credits
	}

	private Page currentPage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}

	void OnGUI() {
		if (skin != null) {
			GUI.skin = skin;
		}

		BeginPage(300,300);
		toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarstrings);
		switch (toolbarInt) {
		case 0: MainMenu(); break;
		case 1: Settings(); break;
		case 2: Credits(); break;
		}

	}

	void MainMenu() {

	}

	void Settings() {

	}

	void Credits() {
		BeginPage(300,300);
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		foreach( Texture credit in crediticons) {
			GUILayout.Label(credit);
		}
		EndPage();
	}

	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			//ShowBackButton();
		}
	}
}
