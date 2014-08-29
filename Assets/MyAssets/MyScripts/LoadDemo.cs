using UnityEngine;
using System.Collections;

public class LoadDemo : MonoBehaviour {
	
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	private SceneFader sceneFader;

	void Awake () {
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
	}

	void OnGUI () {
		GUILayout.Label("Unity player version "+Application.unityVersion);
		GUILayout.Label("Graphics: "+SystemInfo.graphicsDeviceName+ " " +
		                SystemInfo.graphicsMemorySize+"MB\n"+
		                SystemInfo.graphicsDeviceVersion+"\n"+
		                SystemInfo.graphicsDeviceVendor);

		butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;

		butRect.y += ctrlHeight + 20;
		if (GUI.Button (butRect,"Demo starten (WIP)"))
		{
			sceneFader.SwitchScene(1);
		}

        butRect.y += ctrlHeight + 20;
        if (GUI.Button(butRect, "Endlosmodus starten (WIP)"))
        {
            sceneFader.SwitchScene(3);
        }
		
		butRect.y += ctrlHeight + 20;
		if (GUI.Button (butRect,"Spiel beenden (NA)"))
		{
            //Application.Quit();
		}

	}
}
