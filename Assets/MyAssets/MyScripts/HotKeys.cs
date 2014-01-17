using UnityEngine;
using System.Collections;

public class HotKeys : MonoBehaviour {

	private AudioSource bgMusic;
	public bool SoundOn = true;
	public float currentVolume = 1;
	public GUIText VolumeText;

	private string soundVolumeText = "SoundVolume";

	void Awake()
	{
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
		VolumeText.text = "";
	}

	void Start()
	{
		bgMusic.volume = InventoryManager.inventory.GetItems(soundVolumeText);
		//if (bgMusic.volume == 0)
		//	currentVolume = InventoryManager.inventory.GetItems(soundVolumeText)
	}

	// Update is called once per frame
	void Update () {
	
		if (currentVolume != bgMusic.volume)
			InventoryManager.inventory.SetItems(soundVolumeText, currentVolume);


		VolumeText.text = bgMusic.volume.ToString("0.0");	
		if (SoundOn)
			currentVolume = bgMusic.volume;
			InventoryManager.inventory.SetItems(soundVolumeText, currentVolume);

		if (bgMusic.volume <= 0)
			VolumeText.text = "Muted";
		if (bgMusic.mute)
			VolumeText.text = "Muted";

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
		{
			bgMusic.mute = false;
			bgMusic.volume += 0.1F;
		}
		else
			bgMusic.volume = 1;
	}

	void ToggleVolumeMinus()
	{
		if (bgMusic.volume >= 0)
		{
			bgMusic.volume -= 0.1F;

		}
		else
		{
			bgMusic.volume = 0;
			bgMusic.mute = true;
			Debug.Log("Muted");
		}
	}

	void ToggleMute()
	{
		bgMusic.volume = 0;
		//if (!bgMusic.mute)
		if (SoundOn)
		{
			bgMusic.mute = true;
		}
		else
		{
			bgMusic.mute = false;
			bgMusic.volume = currentVolume;
		}	
		SoundOn = !SoundOn;
		InventoryManager.inventory.SetItems(soundVolumeText, currentVolume);
	}
}
