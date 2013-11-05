using UnityEngine;
using System.Collections;

public class PauseMenu1 : MonoBehaviour {

	private AudioSource bgMusic;
	bool SoundOn = true; 
	bool isPaused = false;
	private SceneFader sceneFader;
	private Color currentColor;

	void Awake()
	{
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();	
	}
	
	void OnGUI()
	{
		if (isPaused)
		{
			if(GUI.Button(new Rect((Screen.width - 160)/2,190,160,60),"Back to Game"))
			{
				isPaused = false;	
			}	
			
			if(GUI.Button(new Rect((Screen.width - 160)/2,290,160,60),"Mute"))
			{
				if (SoundOn)
				{
					bgMusic.Stop();
					SoundOn = false;
				}
				else
				{
					bgMusic.Play();
					SoundOn = true;
				}	
				
			}
		
			if(GUI.Button(new Rect((Screen.width - 160)/2,390,160,60),"Exit Level"))
				{
					sceneFader.SwitchScene(0);
				}	
		}
		else
		{
			currentColor = Color.clear;
			
			if(GUI.Button(new Rect((Screen.width - 160)/2,(Screen.height - 80),160,60),"||"))
			{
				if (!isPaused)
				{
					currentColor = Color.clear;
					
					isPaused = true;	
				}
				
			}	
		}		
	}
	
	
}
