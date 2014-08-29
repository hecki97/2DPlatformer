using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public string loadLevel = "1";
	//public Texture2D outsideTexture;
	//public Texture2D insideTexture;
	public AudioClip sound;
	public bool QuitButton = false;

	/*void Awake()
	{
		gameObject.transform.parent.renderer.material.mainTexture = outsideTexture;
	}*/

	void OnMouseEnter()
	{
		audio.PlayOneShot(sound);
	}

	/*void OnMouseOver()
	{
		gameObject.transform.parent.renderer.material.mainTexture = insideTexture;
	}*/

	void OnMouseUp()
	{
		if (QuitButton)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(1);
		}
	}
}
