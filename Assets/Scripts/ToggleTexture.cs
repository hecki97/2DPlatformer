using UnityEngine;
using System.Collections;

public class ToggleTexture : MonoBehaviour {
	
	public Texture2D outsideTexture;
	public Texture2D insideTexture;
	
	void Awake()
	{
		gameObject.transform.parent.renderer.material.mainTexture = outsideTexture;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		gameObject.transform.parent.renderer.material.mainTexture = insideTexture;
	}

	void OnTriggerExit(Collider other)
	{
		gameObject.transform.parent.renderer.material.mainTexture = outsideTexture;
	}
}
