using UnityEngine;
using System.Collections;

public class CraftingMenu : MonoBehaviour {

	public bool isActivated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		if (Input.GetKeyDown(KeyCode.C))
			ToggleTimeScale();
	}

	void ToggleTimeScale()
	{
		isActivated = !isActivated;

		if (isActivated)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
