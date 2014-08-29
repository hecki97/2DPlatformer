using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	private bool isPause = false;
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
    private SceneFader sceneFader;

    private GameObject[] flags;

	/*hecki97
	public Joystick joystickPauseGame;
	public bool inputPauseGamePressed = false;*/

	void Awake()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);

        flags = GameObject.FindGameObjectsWithTag("flag");
	}

	// Use this for initialization
	void OnGUI () {

		if (isPause)
		{
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;

			if (GUI.Button (butRect,"Weiter"))
				ToggleTimeScale();
				
			//Nur für Leveltest!
			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect,"Level neustarten"))
			{
				ToggleTimeScale();
				sceneFader.SwitchScene(Application.loadedLevel);
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

		/*if (joystickPauseGame.isPressed && !inputPauseGamePressed && !isPause)
		{
			ToggleTimeScale();
		}

		if (!joystickPauseGame.isPressed)
			inputPauseGamePressed = false;*/

		if (Input.GetKeyDown(KeyCode.Escape))
			ToggleTimeScale();
		}

	void ToggleTimeScale()
	{
		if (!isPause)
		{
            foreach (GameObject flag in flags)
            {
                InteractiveCloth cloth = flag.GetChild("InteractiveCloth").GetComponent<InteractiveCloth>();
                cloth.enabled = false;
            }

            Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;

            foreach (GameObject flag in flags)
            {
                InteractiveCloth cloth = flag.GetChild("InteractiveCloth").GetComponent<InteractiveCloth>();
                cloth.enabled = true;
            }
		}
		isPause = !isPause;
		//blurEffect.enabled = !blurEffect.enabled;
	}

}
