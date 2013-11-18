using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timer = 10.0F;
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer = 0;

		}
	}

	void OnGui()
	{
		GUI.Box(new Rect(10,10,50,20),"" + timer.ToString("0"));
	}
}
