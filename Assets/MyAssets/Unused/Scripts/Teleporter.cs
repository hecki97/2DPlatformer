using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	
	public string tag = "Player";
	public int loadLevel = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (tag == "" || collider.gameObject.tag == tag)
		{
			Application.LoadLevel(loadLevel);
			
			Destroy(gameObject);
		}	
	}
}
