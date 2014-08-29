using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {
	
	public Texture2D texture;
	public float fadeSpeed = 2;
	
	private int nextLevel = 1;
	private Rect screenRect;
	private Color currentColor;
	private bool isStarting = true;
	private bool isEnding = false;
	
	//hecki97
	private HealthController playerHealth;
	public bool lookForPlayer = true;

	void Awake()
	{
		screenRect = new Rect(0,0,Screen.width,Screen.height);
		currentColor = Color.black;

		//hecki97
		if (lookForPlayer)
			playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isStarting)
			FadeIn();
		if (isEnding)
			FadeOut();
	}
	
	void OnGUI()
	{
		if(isStarting || isEnding)
		{
			GUI.depth = 0;
			GUI.color = currentColor;
			GUI.DrawTexture (screenRect,texture,ScaleMode.StretchToFill);
		}
	}
	
	void FadeIn()
	{
		currentColor = Color.Lerp (currentColor,Color.clear,fadeSpeed * Time.deltaTime);
		
		if(currentColor.a <= 0.05F)
		{
			currentColor = Color.clear;
			isStarting = false;
		}
	}

	void FadeOut()
	{
		//hecki97
		if (lookForPlayer && playerHealth.currentHealth == 0 && playerHealth.lifePoints == 0)
			currentColor = Color.Lerp (currentColor,Color.red,fadeSpeed * Time.deltaTime);
		else
			currentColor = Color.Lerp (currentColor,Color.black,fadeSpeed * Time.deltaTime);
		
			if(currentColor.a >= 0.95F)
			{
				currentColor.a = 1;
				Application.LoadLevel(nextLevel);
				/* Benötigt Unity Pro */
				//Application.LoadLevelAsync(nextLevel); 
				
			}
	}

	public void SwitchScene (int nextSceneIndex)
	{
		nextLevel = nextSceneIndex;
		isEnding = true;
		isStarting = false;
	}
}