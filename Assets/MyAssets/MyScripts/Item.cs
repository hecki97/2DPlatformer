using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	public int currentPlants = 0;
	//public int currentSticks = 0;
	//public int currentWoodPlanks = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{	
		//GUI
		GUI.Box(new Rect(5, 160, 120, 20), "Plants : x" + currentPlants);
	}



}
