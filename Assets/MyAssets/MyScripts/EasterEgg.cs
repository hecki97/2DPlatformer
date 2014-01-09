using UnityEngine;
using System.Collections;

public class EasterEgg : MonoBehaviour {

	public AudioClip CorpsePartyOriginalIntro;
	private AudioSource bgMusic;

	// Use this for initialization
	void Awake () {
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKey(KeyCode.LeftAlt)) && (Input.GetKeyDown(KeyCode.C)))
		{
				bgMusic.Stop();
				AudioSource.PlayClipAtPoint(CorpsePartyOriginalIntro, transform.position, 1);
		}
	}
}
