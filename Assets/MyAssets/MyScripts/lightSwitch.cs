using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lightSwitch : MonoBehaviour {

	private Light light;
	public bool isActivated = false;

	// Use this for initialization
	void Awake () {
		light = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActivated)
			light.enabled = true;
		else
			light.enabled = false;
	}
}
