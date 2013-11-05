using UnityEngine;
using System.Collections;

public class MenuShop : MonoBehaviour {

	string butText = "Shop (test)";
	private SceneFader sceneFader;
	
	
	void Awake()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();	
	}
	
	void OnGUI()
	{
		
		//if(GUI.Button(new Rect(10, 10, 100, 50), "Start"))
		if(GUI.Button(new Rect(720, 10,160,60),butText))
		{
			//Application.LoadLevel(1);
			sceneFader.SwitchScene(4);
		}
	}
}
