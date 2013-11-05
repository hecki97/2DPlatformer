using UnityEngine;
using System.Collections;

public class ControlsMenu : MonoBehaviour {
	
	private SceneFader sceneFader;
	
	
	void Awake()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();	
	}
	
	
	
	void OnGUI()
	{
		GUI.Label(new Rect((Screen.width - 80)/2,(Screen.height - 30)/4,80,30),"Controls");
		
		GUI.Label(new Rect((Screen.width - 80)/3,(Screen.height - 30)/2,400,60),"STRG / LMB 							| 							Attack");
		GUI.Label(new Rect((Screen.width - 80)/3,(Screen.height - 70)/2,400,60),"SPACE 								| 							Jump");
		GUI.Label(new Rect((Screen.width - 80)/3,(Screen.height - 110)/2,400,60),"WASD / ARROWKEYS			| 							Move");
	
		if(GUI.Button(new Rect(380,(Screen.height - 160),160,60),"Back to Menu"))
		{
			//Application.LoadLevel(1);
			sceneFader.SwitchScene(0);
		}	
	}
}
