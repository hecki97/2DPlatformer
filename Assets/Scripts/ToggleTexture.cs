using UnityEngine;
using System.Collections;

public class ToggleTexture : MonoBehaviour {
	
	public Texture2D outsideTexture;
	public Texture2D insideTexture;
	public bool tag = false;
	
	void Awake()
	{
		gameObject.transform.parent.renderer.material.mainTexture = outsideTexture;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
			gameObject.transform.parent.renderer.material.mainTexture = insideTexture;

		//hecki97
		if (tag && other.gameObject.CompareTag("enemy"))
			gameObject.transform.parent.renderer.material.mainTexture = insideTexture;
	}

	void OnTriggerExit(Collider other)
	{
		gameObject.transform.parent.renderer.material.mainTexture = outsideTexture;
	}
}
