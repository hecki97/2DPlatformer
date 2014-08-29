using UnityEngine;
using System.Collections;

public class VolumeController : MonoBehaviour {

	public bool initValues = false;
	public GameObject musicPrefab;

	private Object musicManager;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("musicManager"))
		{
			if (PlayerPrefs.GetString("isPaused") == "true")
			{
				AudioListener.pause = true;
				AudioListener.volume = 0;
			}
            else
                AudioListener.pause = false;
			
			if (PlayerPrefs.GetFloat("Volume") != AudioListener.volume && PlayerPrefs.GetString("isPaused") == "false")
				AudioListener.volume = PlayerPrefs.GetFloat("Volume");

			if (PlayerPrefs.GetInt("loadedLevel") != Application.loadedLevel)
			{
				Destroy(GameObject.FindGameObjectWithTag("musicManager"));
				InstantiateMusicPrefab();
			}
		}
		else
		{
			AudioListener.pause = false;
			PlayerPrefs.SetString("isPaused", AudioListener.pause.ToString());
			AudioListener.volume = 0.5F;
			PlayerPrefs.SetFloat("Volume", AudioListener.volume);

			InstantiateMusicPrefab();
		}
	}

	void InstantiateMusicPrefab()
	{
		musicManager = Instantiate(musicPrefab, transform.position, Quaternion.identity);
		musicManager.name = musicPrefab.name;
		DontDestroyOnLoad(musicManager);

		PlayerPrefs.SetInt("loadedLevel", Application.loadedLevel);
	}

	// Update is called once per frame
	void Update () {
	
		if (AudioListener.volume <= 0)
			AudioListener.volume = 0;

		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			if (AudioListener.volume >= 0 && !AudioListener.pause && AudioListener.volume <= 1) 
			{
				AudioListener.volume += 0.1F;
				PlayerPrefs.SetFloat("Volume", AudioListener.volume);
			}

		}

		if (Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			if (AudioListener.volume > 0 && !AudioListener.pause)
			{
				AudioListener.volume -= 0.1F;
				PlayerPrefs.SetFloat("Volume", AudioListener.volume);
			}
			
		}

		if (Input.GetKeyDown(KeyCode.M))
		{
			if (!AudioListener.pause)
			{
				PlayerPrefs.SetFloat("Volume", AudioListener.volume);
				AudioListener.volume = 0;
				PlayerPrefs.SetString("isPaused", AudioListener.pause.ToString());
				AudioListener.pause = true;
			}
			else
			{
				AudioListener.volume = PlayerPrefs.GetFloat("Volume");
				PlayerPrefs.SetString("isPaused", AudioListener.pause.ToString());
				AudioListener.pause = false;
			}
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Cur. Vol.:" + AudioListener.volume.ToString("0.0"));
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
