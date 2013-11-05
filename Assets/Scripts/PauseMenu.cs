using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	private bool isPause = false;
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	private SceneFader sceneFader;
	
	//hecki97
	bool SoundOn = true;
	private AudioSource bgMusic;
	
	void Awake()
	{
		sceneFader = GetComponent<SceneFader>();
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
		
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
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
					bgMusic.Stop();
					SoundOn = false;
				}
				else
				{
					bgMusic.Play();
					SoundOn = true;
				}	
				
			}
			
			
			butRect.y += ctrlHeight + 40;
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
	}

}
