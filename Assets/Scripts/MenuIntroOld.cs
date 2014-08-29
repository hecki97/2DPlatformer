using UnityEngine;
using System.Collections;

public class MenuIntroOld : MonoBehaviour {
	
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	private SceneFader sceneFader;
	private AudioSource bgMusic;
	
	string butText = "Start Game";
	
	public string version = "0.17";
	
	private Color currentColor;
	
	bool menuIntro = true;
	bool controlsMenu = false;
	bool optionsMenu = false;

	bool SoundOn = true;
	
	//NewLevelMenu
	bool levelMenu = false;

	//hecki97
	public GUISkin mobileSkin;
	public GUISkin skin;
	
	public bool isMobile;
	
	
	void Awake()
	{
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);

		//hecki97
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.MetroPlayerX64)
			isMobile = true;
	}

	void OnGUI()
	{
		//hecki97
		if (skin != null && !isMobile) {
			GUI.skin = skin;
		}
		
		if (mobileSkin != null && isMobile) {
			GUI.skin = mobileSkin;
		}

		currentColor = Color.clear;

		if (menuIntro)
		{
			controlsMenu = false;

			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;

			if (GUI.Button(butRect,butText))
			{
				//Application.LoadLevel(1);
				sceneFader.SwitchScene(1);
			}
			
			//hecki97
			butRect.y += ctrlHeight + 20;
			if(GUI.Button(butRect,"Level (test)"))
			{
				levelMenu = true;
				menuIntro = false;
			}
			
			butRect.y += ctrlHeight + 20;
			if(GUI.Button(butRect,"Options"))
			{
				optionsMenu = true;
				menuIntro = false;
			}

			butRect.y += ctrlHeight + 20;
			if(GUI.Button(butRect,"MiniGame: Quasar"))
			{
				sceneFader.SwitchScene(5);
			}

			butRect.y += ctrlHeight + 40;
			if (GUI.Button(butRect,"Schlie" + (char)223 +"en"))
			{
				//Application.LoadLevel(1);
				Application.Quit();
			}

			
			butRect.y += ctrlHeight + 80;
			GUI.Label(butRect,"			InDev v." + version);
			butRect.y += ctrlHeight - 10;
			GUI.Label(butRect," 			by hecki97");
		}
	
		if (optionsMenu)
		{	
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
			GUI.Label(butRect,"			  Options");
			
			//hecki97
			butRect.y += ctrlHeight + 20;
			if(GUI.Button(butRect,"Controls"))
			{		
				controlsMenu = true;
				optionsMenu = false;
			}
			
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
			
			butRect.y += ctrlHeight + 40;
			if(GUI.Button(butRect,"Back to Menu"))
			{
				optionsMenu = false;
				menuIntro = true;
			}	
		
			butRect.y += ctrlHeight + 20;
			GUI.Label(butRect,"			InDev v." + version);
			butRect.y += ctrlHeight - 10;
			GUI.Label(butRect," 			by hecki97");
		}
		
		if (controlsMenu)
		{
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
			GUI.Label(butRect,"			  Controls");
			
			butRect.y += ctrlHeight + 20;
			GUI.Label(butRect,"	 STRG / LMB | Attack");
			butRect.y += ctrlHeight - 10;
			GUI.Label(butRect,"	 SPACE	  		| Jump");
			butRect.y += ctrlHeight - 10;
			GUI.Label(butRect,"	 WASD		  	| Move");
			
			butRect.y += ctrlHeight + 50;
			if(GUI.Button(butRect,"Back to Menu"))
			{
				controlsMenu = false;
				optionsMenu = true;
			}	
			
			butRect.y += ctrlHeight + 20;
			GUI.Label(butRect,"			InDev v." + version);
			butRect.y += ctrlHeight - 10;
			GUI.Label(butRect," 			by hecki97");
		}
		
		if (levelMenu)
		{
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
			//GUI.Label(butRect,"			  Levels");
			
			//butRect.y += ctrlHeight + 10;
			if(GUI.Button(butRect,"Level 1"))
			{
				sceneFader.SwitchScene(1);
				levelMenu = true;
				menuIntro = false;
			}
			butRect.y += ctrlHeight + 10;
			if(GUI.Button(butRect,"Level 2"))
			{
				sceneFader.SwitchScene(2);
				levelMenu = true;
				menuIntro = false;
			}
			butRect.y += ctrlHeight + 10;
			if(GUI.Button(butRect,"Level - Boss"))
			{
				sceneFader.SwitchScene(3);
				levelMenu = true;
				menuIntro = false;
			}
			/*butRect.y += ctrlHeight + 10;
			if(GUI.Button(butRect,"Level 4"))
			{
				levelMenu = true;
				menuIntro = false;
			}
			butRect.y += ctrlHeight + 10;
			if(GUI.Button(butRect,"Level 5"))
			{
				levelMenu = true;
				menuIntro = false;
			}*/
			butRect.y += ctrlHeight + 20;
			if(GUI.Button(butRect,"Back to Menu"))
			{
				levelMenu = false;
				menuIntro = true;
			}	
		}
	}
}
