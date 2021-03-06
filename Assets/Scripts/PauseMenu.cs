﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	private bool isPause = false;
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	private SceneFader sceneFader;

	//hecki97
	bool SoundOn = true;
	bool VolumeMenu = false;	
	private BlurEffect blurEffect;
	private AudioSource bgMusic;
	
	void Awake()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
		
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();

		blurEffect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BlurEffect>();
	}

	//hecki97
	void OnMouseUp()
	{
		//ToggleTimeScale();
		Debug.Log("klick!!");
	}

	// Use this for initialization
	void OnGUI () {

		if (isPause)
		{
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;



			if (GUI.Button (butRect,"Weiter"))
				ToggleTimeScale();
			
			//hecki97
			butRect.y += ctrlHeight + 20;
			if(GUI.Button(butRect,"Mute"))
			{
				if (SoundOn)
				{
					//bgMusic.Stop();
					bgMusic.mute = true;
					SoundOn = false;
				}
				else
				{
					//bgMusic.Play();
					SoundOn = true;
					bgMusic.mute = false;
				}	
				
			}
						
			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect,"Spiel beenden"))
			{
				ToggleTimeScale();
				sceneFader.SwitchScene(0);
			}
		}
	}
	

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			ToggleTimeScale();
		}

	void ToggleTimeScale()
	{
		if (!isPause)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
		isPause = !isPause;
		blurEffect.enabled = !blurEffect.enabled;
	}

}
