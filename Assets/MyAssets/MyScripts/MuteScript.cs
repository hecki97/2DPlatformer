using UnityEngine;
using System.Collections;

public class MuteScript : MonoBehaviour {
	
	private AudioSource bgMusic;
	bool SoundOn = true; 
	
	void Awake()
	{
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();	
	}
	
	void OnGUI()
	{
		
		if(GUI.Button(new Rect((Screen.width - 160),(Screen.height - 80),160,60),"Mute"))
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
	}
}
