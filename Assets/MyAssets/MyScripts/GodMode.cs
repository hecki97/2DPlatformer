using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour {

	public bool toggleTimeScale = false;
	public bool toggleGodMode = false;
	private HealthController playerHealth;
	public float currentHealth;
	private PlayerController playerController;

	// Use this for initialization
	void Awake() {
		toggleTimeScale = false;
		toggleGodMode = false;
	}
		
	void Start()
	{
//		currentHealth = playerHealth.currentHealth;
	}

	// Update is called once per frame
	void Update () {



		if (Input.GetKeyDown("1"))
			ToggleTimeScale();
		//if (Input.GetKeyDown("2"))
		//	ToggleGodMode();

	}


	void ToggleTimeScale()
	{
		toggleTimeScale = !toggleTimeScale;
		if (toggleTimeScale)
			Time.timeScale = 0.5F;
		else
			Time.timeScale = 1F;
	}
	/*
	void ToggleGodMode()
	{
		toggleGodMode = !toggleGodMode;
		if (toggleGodMode)
			playerHealth.currentHealth = 5;
		else
			playerHealth.currentHealth = currentHealth;
	}*/
}
