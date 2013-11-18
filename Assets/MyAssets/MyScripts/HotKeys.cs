using UnityEngine;
using System.Collections;

public class HotKeys : MonoBehaviour {

	private AudioSource bgMusic;
	public bool SoundOn = true;
	public float Volume;
	public GUIText VolumeText;

	void Awake()
	{
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
		VolumeText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
		VolumeText.text = Volume.ToString();	
		Volume = bgMusic.volume;

		if (Input.GetKeyDown(KeyCode.M))
			ToggleMute();
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
			ToggleVolumePlus();
		if (Input.GetKeyDown(KeyCode.Minus))
			ToggleVolumeMinus();
	}

	void ToggleVolumePlus()
	{
		if (bgMusic.volume <= 1)
			bgMusic.volume += 0.1F;
		else
			bgMusic.volume = 1;
	}

	void ToggleVolumeMinus()
	{
		if (bgMusic.volume >= 0)
			bgMusic.volume -= 0.1F;
		else
			bgMusic.volume = 0;
	}

	void ToggleMute()
	{
		Debug.Log("ToggleMute");
		//if (!bgMusic.mute)
		if (SoundOn)
		{
			bgMusic.mute = true;
		}
		else
		{
			bgMusic.mute = false;
		}	
		SoundOn = !SoundOn;
	}
}
